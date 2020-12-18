using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileWatcherService.Models
{
    public class EncryptionOptions
    {
        public string Key { get; set; } = "qZglzpwgkTOOQ8Tw/PRphd6Ido0QsQbfcBclmROnLN4=";
        public string IV { get; set; } = "ZkcbKb6IRriB+DGOlOvBiA==";
        public bool RandomKey { get; set; } = false;

        public EncryptionOptions()
        {

        }
    }
}
