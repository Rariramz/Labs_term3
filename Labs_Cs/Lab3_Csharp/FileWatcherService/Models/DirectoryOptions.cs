using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileWatcherService.Models
{
    public class DirectoryOptions
    {
        public string SourceDir { get; set; } = @"D:\SourceDirectory";
        public string TargetDir { get; set; } = @"D:\TargetDirectory";

        public DirectoryOptions()
        {

        }
    }
}
