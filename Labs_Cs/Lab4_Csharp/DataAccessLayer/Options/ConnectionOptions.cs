using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Options
{
    public class ConnectionOptions
    {
        public string DataSource { get; set; } = "Rariramz\\SQLEXPRESS";
        public string DataBase { get; set; } = "AdventureWorks2017";
        public string User { get; set; } = "Rariramz";
        public string Password { get; set; } = "123";
    }
}
