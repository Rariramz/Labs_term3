using System;
using DataAccessLayer.Options;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public class Logger
    {
        DataAccessLayer.DataAccessLayer DAL;
        public Logger(ConnectionOptions options)
        {
            DAL = new DataAccessLayer.DataAccessLayer(options);
        }

        public void Log(string fileEvent, string filePath)
        {
            DAL.Log(DateTime.Now, fileEvent, filePath);
        }
    }
}
