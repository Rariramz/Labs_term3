using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace JsonXMLParser
{
    public class JsonParser
    {
        public T ParseFromJson<T>(string json) where T : new()
        {
            T obj = new T();
            Type type = typeof(T);
            Dictionary<string, string> dict = Parse(json);
            foreach(KeyValuePair<string, string> keyValue in dict)
            {
                PropertyInfo info = type.GetProperty(keyValue.Key);
                if(keyValue.Value.Contains("{"))
                {
                    info.SetValue(obj, typeof(JsonParser)
                                       .GetMethod("ParseFromJson", BindingFlags.Public | BindingFlags.Instance)
                                       .MakeGenericMethod(new Type[] { info.PropertyType })
                                       .Invoke(this, new object[] { keyValue.Value} ));
                }
                else
                {
                    info.SetValue(obj, Convert.ChangeType(keyValue.Value, info.PropertyType));
                }
            }
            return obj;
        }

        public string ParseJson(object obj)
        {
            StringBuilder json = new StringBuilder("{\n");
            Type type = obj.GetType();
            PropertyInfo[] propertyInfos = type.GetProperties();
            foreach(PropertyInfo info in propertyInfos)
            {
                Type propertyType = info.PropertyType;
                if(propertyType.IsPrimitive || propertyType == typeof(string))
                {
                    json.Append('\t');
                    json.Append($"{info.Name} : {info.GetValue(obj)},\n");
                }
                else
                {
                    json.Append('\t');
                    json.Append($"{info.Name} : \n");
                    string value = ParseJson(info.GetValue(obj));
                    string[] values = value.Split('\n');
                    for(int i = 0; i < values.Length; i++)
                    {
                        values[i] = '\t' + values[i];
                    }
                    json.Append(string.Join("\n", values));
                    json.Append(",\n");
                }
            }
            json.Append('}');
            return json.ToString().TrimEnd(new char[] { ',', '\n' });
        }

        private Dictionary<string, string> Parse(string json)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            json = json.Trim(new char[] { '{', '}', ' ', '\n' });
            string key = "";
            string value = "";
            int deep = 0;
            bool isKey = true;
            for(int i = 0; i < json.Length; i++)
            {
                char c = json[i];
                if(char.IsLetterOrDigit(c) || char.IsPunctuation(c) || char.IsSymbol(c))
                {
                    if(c == ':' && deep == 0 && isKey)
                    {
                        isKey = false;
                        continue;
                    }
                    else if(c == '{')
                    {
                        deep++;
                    }
                    else if(c == '}')
                    {
                        deep--;
                    }
                    else if(c == ',' && deep == 0)
                    {
                        dict.Add(key, value);
                        key = "";
                        value = "";
                        isKey = true;
                        continue;
                    }
                    if(isKey)
                    {
                        key += c;
                    }
                    else
                    {
                        value += c;
                    }
                }
            }
            return dict;
        }
    }
}
