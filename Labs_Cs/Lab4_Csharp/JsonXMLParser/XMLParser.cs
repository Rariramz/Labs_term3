using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace JsonXMLParser
{
    public class XMLParser
    {
        public T ParseFromXML<T>(string xml) where T : new()
        {
            T obj = new T();
            Type type = typeof(T);
            if(xml[0] == '<')
            {
                xml = Trim(xml);
            }
            Dictionary<string, string> dict = Parse(xml);
            foreach(KeyValuePair<string, string> keyValue in dict)
            {
                PropertyInfo info = type.GetProperty(keyValue.Key);
                if(keyValue.Value.Contains("<"))
                {
                    info.SetValue(obj, typeof(XMLParser)
                                       .GetMethod("ParseFromXML", BindingFlags.Public | BindingFlags.Instance)
                                       .MakeGenericMethod(new Type[] { info.PropertyType })
                                       .Invoke(this, new object[] { keyValue.Value }));
                }
                else
                {
                    info.SetValue(obj, Convert.ChangeType(keyValue.Value, info.PropertyType));
                }
            }
            return obj;
        }

        public Dictionary<string, string> Parse(string xml)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            string[] rows = xml.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            string key = "", value = "";
            for(int i = 0; i < rows.Length; i++)
            {
                if(key == "" && !rows[i].Trim(new char[] { '<', '>', '\t', ' ' }).Contains("<"))
                {
                    key = rows[i].Trim(new char[] { '<', '>', '\t', ' ' });
                }
                else if(key == rows[i].Trim(new char[] { '<', '>', '/', '\t' }))
                {
                    dict.Add(key, value);
                    key = "";
                    value = "";
                }
                else if(key == "" && rows[i].Contains("<"))
                {
                    value = Trim(rows[i]);
                    key = rows[i].Trim(new char[] { ' ', '\n', '\t' });
                    key = key.Substring(1, key.IndexOf('>') - 1);
                    dict.Add(key, value);
                    key = "";
                    value = "";
                }
                else
                {
                    value += rows[i] + '\n';
                }
            }
            return dict;
        }
   
        public string ParseXML(object obj)
        {
            Type type = obj.GetType();
            StringBuilder xml = new StringBuilder($"<{type.Name}>\n");
            PropertyInfo[] propertyInfos = type.GetProperties();
            foreach(PropertyInfo info in propertyInfos)
            {
                Type propertyType = info.PropertyType;
                if(propertyType.IsPrimitive || propertyType == typeof(string) || propertyType == typeof(DateTime) || propertyType == typeof(Guid))
                {
                    xml.Append($"\t<{info.Name}>{info.GetValue(obj)}</{info.Name}>\n");
                }
                else
                {
                    //xml.Append($"\t<{info.Name}>\n");
                    string value = ParseXML(info.GetValue(obj));
                    string[] values = value.Split('\n');
                    for(int i = 0; i < values.Length; i++)
                    {
                        values[i] = '\t' + values[i];
                    }
                    xml.AppendLine(string.Join("\n", values));
                }
            }
            xml.Append($"</{ type.Name}>");
            return xml.ToString();
        }
        string Trim(string xml)
        {
            xml = xml.Substring(xml.IndexOf('>') + 1);
            int index = xml.Length - 1;
            while(xml[index] != '<')  
            {
                index--;
            }
            return xml.Remove(index);
        }
    }
}
