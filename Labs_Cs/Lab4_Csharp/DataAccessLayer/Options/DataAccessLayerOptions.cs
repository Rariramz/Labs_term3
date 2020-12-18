using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Options
{
    public class DataAccessLayerOptions
    {
        public ConnectionOptions ConnectionOptions { get; set; } = new ConnectionOptions();
        public DirectoryOptions DirectoryOptions { get; set; } = new DirectoryOptions();
    }
}
