using System;
using System.IO;
using System.Threading;
using System.ServiceProcess;
using System.Security.Cryptography;
using ClassFileRoutineLibrary;


namespace FileWatcherService
{
    public partial class MyService : ServiceBase
    {
        Logger logger;
        public MyService()
        {
            InitializeComponent();
            this.CanStop = true;
            this.CanPauseAndContinue = true;
            this.AutoLog = true;
        }

        protected override void OnStart(string[] args)
        {
            logger = new Logger();
            Thread loggerThread = new Thread(new ThreadStart(logger.Start));
            loggerThread.Start();
        }

        protected override void OnStop()
        {
            logger.Stop();
            Thread.Sleep(1000);
        }
    }

    class Logger
    {
        const string sourceDir = @"D:\SourceDirectory", targetDir = @"D:\TargetDirectory";

        private void RootDirectoriesCheck()
        {
            DirectoryInfo dirInfo = new DirectoryInfo(sourceDir);
            if (!dirInfo.Exists)
                dirInfo.Create();
            dirInfo = new DirectoryInfo(targetDir);
            if (!dirInfo.Exists)
                dirInfo.Create();
        }

        FileSystemWatcher watcher;
        object obj = new object();
        bool enabled = true;
        public Logger()
        {
            RootDirectoriesCheck();
            watcher = new FileSystemWatcher(sourceDir);
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
                    myAes.GenerateIV();
                    myAes.GenerateKey();

                    //зашифровываем
                    string pathEncrypted = Path.Combine(sourceDir, fileName + "Enc");
                    EncryptFile(filePath, pathEncrypted, myAes.Key, myAes.IV);

                    //архивируем
                    string compressedFile = Path.Combine(sourceDir, fileName + ".gz");
                    GZipCompress(pathEncrypted, compressedFile);
                    File.Delete(pathEncrypted);  //удаляем временный файл

                    //проверяем наличие каталога archive в TargetDirectory. Если такого там нет - создаем
                    string archivePath = Path.Combine(targetDir, "archive");
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
                    string decompressedFile = Path.Combine(targetDir, fileName);
                    GZipDecompress(newPath, decompressedFile);

                    //расшифровываем
                    string pathDecrypted = Path.Combine(targetDir, fileName + "Dec" + fileExtension);
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
                string path = Path.Combine(targetDir, DateTime.Now.ToString("yyyy"),
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
                using (StreamWriter writer = new StreamWriter("D:\\ERRORS.txt", true))
                {
                    writer.WriteLine(String.Format("{0} файл {1} {2}",
                        DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"), filePath, fileEvent));
                    writer.Flush();
                }
            }
        }
    }
}