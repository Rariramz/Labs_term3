using System.ComponentModel;
using System.ServiceProcess;
using System.Configuration.Install;

namespace FileWatcherService
{
    [RunInstaller(true)]
    public partial class MyInstaller : Installer
    {
        ServiceInstaller serviceInstaller;
        ServiceProcessInstaller processInstaller;

        public MyInstaller()
        {
            InitializeComponent();
            serviceInstaller = new ServiceInstaller();
            processInstaller = new ServiceProcessInstaller();

            processInstaller.Account = ServiceAccount.LocalSystem;
            serviceInstaller.StartType = ServiceStartMode.Manual;
            serviceInstaller.ServiceName = "FileWatcherService";
            serviceInstaller.Description = "A simple service";
            serviceInstaller.DisplayName = "SourceDirectory monitoring";
            Installers.Add(processInstaller);
            Installers.Add(serviceInstaller);
        }
    }
}
