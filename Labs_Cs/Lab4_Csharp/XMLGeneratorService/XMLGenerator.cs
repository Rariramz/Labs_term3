using System;
using JsonXMLParser;
using DataAccessLayer.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLGeneratorService
{
    public class XMLGenerator
    {
        XMLParser XMLParser;
        public XMLGenerator(XMLParser xmlParser)
        {
            XMLParser = xmlParser;
        }

        public string ParseHumanArray(List<Human> humen)
        {
            StringBuilder sb = new StringBuilder("<ArrayOfHuman>\n");
            foreach(Human human in humen)
            {
                string[] rows = XMLParser.ParseXML(human).Split('\n');
                for(int i = 0; i < rows.Length; i++)
                {
                    rows[i] = '\t' + rows[i];
                }
                sb.AppendLine(string.Join("\n", rows));
            }
            return sb.Append("</ArrayOfHuman>").ToString();
        }
    }
}
