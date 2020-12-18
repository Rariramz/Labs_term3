using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileWatcherService.Models
{
    public class Options
    {
        public DirectoryOptions DirectoryOptions { get; set; } = new DirectoryOptions();
        public EncryptionOptions EncryptionOptions { get; set; } = new EncryptionOptions();

        public Options()
        {

        }
    }
}
