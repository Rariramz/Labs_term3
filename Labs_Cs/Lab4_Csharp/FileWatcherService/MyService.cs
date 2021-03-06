﻿using System;
using Logger;
using System.IO;
using System.Threading;
using System.ServiceProcess;
using System.Security.Cryptography;
using ClassFileRoutineLibrary;
using System.Diagnostics;

namespace FileWatcherService
{
    public partial class MyService : ServiceBase
    {
        ConfigurationManager.ConfigurationManager<Models.Options> manager;
        Watcher watcher;
        public MyService()
        {
            InitializeComponent();
            this.CanStop = true;
            this.CanPauseAndContinue = true;
            this.AutoLog = true;
        }

        protected override void OnStart(string[] args)
        {
            string dir = AppDomain.CurrentDomain.BaseDirectory;
            manager = new ConfigurationManager.ConfigurationManager<Models.Options>($"{dir}\\appsettings.json",
                                                                                    $"{dir}\\config.xml",
                                                                                    new JsonXMLParser.JsonParser(),
                                                                                    new JsonXMLParser.XMLParser());
            watcher = new Watcher(manager);
            Thread loggerThread = new Thread(new ThreadStart(watcher.Start));
            loggerThread.Start();
        }

        protected override void OnStop()
        {
            watcher.Stop();
            Thread.Sleep(1000);
        }
    }

    class Watcher
    {
        Models.DirectoryOptions DirectoryOptions;
        Models.EncryptionOptions EncryptionOptions;
        Logger.Logger logger;

        private void RootDirectoriesCheck()
        {
            DirectoryInfo dirInfo = new DirectoryInfo(DirectoryOptions.SourceDir);
            if (!dirInfo.Exists)
                dirInfo.Create();
            dirInfo = new DirectoryInfo(DirectoryOptions.TargetDir);
            if (!dirInfo.Exists)
                dirInfo.Create();
        }

        FileSystemWatcher watcher;
        object obj = new object();
        bool enabled = true;
        public Watcher(ConfigurationManager.ConfigurationManager<Models.Options> manager)
        {
            DirectoryOptions = manager.GetOptions<Models.DirectoryOptions>();
            EncryptionOptions = manager.GetOptions<Models.EncryptionOptions>();
            logger = new Logger.Logger(manager.GetOptions<DataAccessLayer.Options.ConnectionOptions>());
            RootDirectoriesCheck();
            watcher = new FileSystemWatcher(DirectoryOptions.SourceDir);
            watcher.Created += Watcher_Created;
        }

        public void Start()
        {
            watcher.EnableRaisingEvents = true;
            while (enabled)
                Thread.Sleep(1000);
        }

        public void Stop()
        {
            watcher.EnableRaisingEvents = false;
            enabled = false;
        }

        //в SourceDirectory был добавлен файл..
        private void Watcher_Created(object sender, FileSystemEventArgs e)
        {
            string filePath = e.FullPath;
            Routine(filePath);
        }

        private void Routine(string filePath)
        {
            if (!File.Exists(filePath))
                return;

            try
            {
                string fileName = Path.GetFileNameWithoutExtension(filePath);
                string fileExtension = Path.GetExtension(filePath);

                if (fileExtension != ".gz" && fileExtension != "")
                {
                    Wait(filePath);
                    //создаем экземпляр класса AesManaged, просто чтобы сгенерировать вектор и ключ :)
                    AesManaged myAes = new AesManaged();
                    if(!EncryptionOptions.RandomKey)
                    {
                        myAes.Key = Convert.FromBase64String(EncryptionOptions.Key);
                        myAes.IV = Convert.FromBase64String(EncryptionOptions.IV);
                    }
                    else
                    {
                        myAes.GenerateIV();
                        myAes.GenerateKey();
                    }
                    
                    //зашифровываем
                    string pathEncrypted = Path.Combine(DirectoryOptions.SourceDir, fileName + "Enc");
                    EncryptFile(filePath, pathEncrypted, myAes.Key, myAes.IV);

                    //архивируем
                    string compressedFile = Path.Combine(DirectoryOptions.SourceDir, fileName + ".gz");
                    GZipCompress(pathEncrypted, compressedFile);
                    File.Delete(pathEncrypted);  //удаляем временный файл

                    //проверяем наличие каталога archive в TargetDirectory. Если такого там нет - создаем
                    string archivePath = Path.Combine(DirectoryOptions.TargetDir, "archive");
                    DirectoryInfo dirInfo = new DirectoryInfo(archivePath);
                    if (!dirInfo.Exists)
                        dirInfo.Create();

                    //перемещаем архивированный файл в каталог archive в TargetDirecory
                    //перезаписываем, если там уже есть такой файл
                    string newPath = Path.Combine(archivePath, fileName + ".gz");
                    if (File.Exists(compressedFile))
                    {
                        if (File.Exists(newPath))
                            File.Delete(newPath);
                        File.Move(compressedFile, newPath);
                    }

                    //разархивируем
                    string decompressedFile = Path.Combine(DirectoryOptions.TargetDir, fileName);
                    GZipDecompress(newPath, decompressedFile);

                    //расшифровываем
                    string pathDecrypted = Path.Combine(DirectoryOptions.TargetDir, fileName + "Dec" + fileExtension);
                    DecryptFile(decompressedFile, pathDecrypted, myAes.Key, myAes.IV);
                    File.Delete(decompressedFile);  //подчищаем временные файлы

                    //перемещаем уже разархивированный и расшифрованный файл в соответствующий по дате_времени каталог
                    string dirPath = Path.Combine(CreateDirectories(), fileName + "_"
                        + DateTime.Now.ToString("yyy_MM_dd_hh_mm_ss") + fileExtension);
                    if (File.Exists(pathDecrypted))
                        File.Move(pathDecrypted, dirPath);
                    Wait(dirPath);
                }
            }
            catch
            {
                string fileEvent = ": произошел сбой";
                RecordError(fileEvent, filePath);
            }
        }

        private void EncryptFile(string sourcePath, string targetPath, byte[] key, byte[] iv)
        {
            if (!File.Exists(sourcePath))
                return;

            try
            {
                FileRoutine.Encrypt(sourcePath, targetPath, key, iv);
            }
            catch
            {
                string fileEvent = "не удалось зашифровать";
                RecordError(fileEvent, sourcePath);
            }
        }

        private void DecryptFile(string sourcePath, string targetPath, byte[] key, byte[] iv)
        {
            if (!File.Exists(sourcePath))
                return;

            try
            {
                FileRoutine.Decrypt(sourcePath, targetPath, key, iv);
            }
            catch
            {
                string fileEvent = "не удалось расшифровать";
                RecordError(fileEvent, sourcePath);
            }
        }

        private void GZipCompress(string sourceFile, string compressedFile)
        {
            try
            {
                FileRoutine.Compress(sourceFile, compressedFile);
            }
            catch
            {
                string fileEvent = "не удалось заархивировать";
                RecordError(fileEvent, sourceFile);
            }
        }

        private void GZipDecompress(string compressedFile, string targetFile)
        {
            try
            {
                FileRoutine.Decompress(compressedFile, targetFile);
            }
            catch
            {
                string fileEvent = "не удалось разархивировать";
                RecordError(fileEvent, compressedFile);
            }
        }

        private string CreateDirectories()
        {
            try
            {
                string path = Path.Combine(DirectoryOptions.TargetDir, DateTime.Now.ToString("yyyy"),
                    DateTime.Now.ToString("MM"), DateTime.Now.ToString("dd"));

                DirectoryInfo dirInfo = new DirectoryInfo(path);
                if (!dirInfo.Exists)
                    dirInfo.Create();

                return path;
            }
            catch
            {
                string fileEvent = "не удалось создать необходимые директории";
                RecordError(fileEvent, null);
                return null;
            }
        }

        private void Wait(string path)
        {
            while (true)
            {
                try
                {
                    using (FileStream fs = File.Open(path, FileMode.Open,
                          FileAccess.ReadWrite, FileShare.ReadWrite))
                        return;
                }
                catch { }
            }
        }

        private void RecordError(string fileEvent, string filePath)
        {
            lock (obj)
            {
                logger.Log(fileEvent, filePath);
            }
        }
    }
}