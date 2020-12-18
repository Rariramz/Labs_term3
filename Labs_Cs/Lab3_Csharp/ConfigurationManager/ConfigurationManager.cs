using System.IO;
using System.Collections.Generic;
using System.Text;

namespace ConfigurationManager
{
    public class ConfigurationManager<T> where T : new()
    {
        JsonXMLParser.JsonParser JsonParser = null;
        JsonXMLParser.XMLParser XMLParser = null;

        T JsonOptions { get; set; }
        T XMLOptions { get; set; }

        public ConfigurationManager(string json, string xml, JsonXMLParser.JsonParser jsonParser, JsonXMLParser.XMLParser xmlParser)
        {
            JsonParser = jsonParser;
            XMLParser = xmlParser;
            try
            {
                using(StreamReader sr = new StreamReader(json))
                {
                    string val = sr.ReadToEnd();
                    JsonOptions = jsonParser.ParseFromJson<T>(val);
                }
            }
            catch
            {
                try
                {
                    using(StreamReader sr = new StreamReader(xml))
                    {
                        string val = sr.ReadToEnd();
                        XMLOptions = xmlParser.ParseFromXML<T>(val);
                    }
                }
                catch
                {
                    using(StreamWriter sw = new StreamWriter(json))
                    {
                        sw.Write(jsonParser.ParseJson(new T()));
                    }
                    using(StreamWriter sw = new StreamWriter(xml))
                    {
                        sw.Write(xmlParser.ParseXML(new T()));
                    }
                    JsonOptions = new T();
                }
            }
        }

        public T GetOptions<T>()
        {
            if(JsonOptions != null)
            {
                return (T)JsonOptions.GetType().GetProperty(typeof(T).Name).GetValue(JsonOptions);
            }
            else if(XMLOptions != null)
            {
                return (T)XMLOptions.GetType().GetProperty(typeof(T).Name).GetValue(XMLOptions);
            }
            else
            {
                throw new System.Exception("Error!");
            }
        }
    }
}
