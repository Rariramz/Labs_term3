using System;
using DataAccessLayer.Options;
using System.Collections.Generic;
using XMLGeneratorService;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Models;
using System.IO;

namespace DataManager
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            JsonXMLParser.XMLParser xmlParser = new JsonXMLParser.XMLParser();
            ConfigurationManager.ConfigurationManager<DataAccessLayerOptions> configurationManager = 
                new ConfigurationManager.ConfigurationManager<DataAccessLayerOptions>($"{path}\\appsettings.json",
                                                                                      $"{path}\\config.xml",
                                                                                      new JsonXMLParser.JsonParser(),
                                                                                      xmlParser);

            ServiceLayer.ServiceLayer SL = new ServiceLayer.ServiceLayer(configurationManager.GetOptions<ConnectionOptions>());
            List<Human> humen = SL.GetHumen();
            XMLGenerator generator = new XMLGenerator(xmlParser);
            string xml = generator.ParseHumanArray(humen);
            path = $"{configurationManager.GetOptions<DirectoryOptions>().TargetDir}\\database.xml";
            using(StreamWriter sw = new StreamWriter(path))
            {
                sw.Write(xml);
            }

        }
    }
}
