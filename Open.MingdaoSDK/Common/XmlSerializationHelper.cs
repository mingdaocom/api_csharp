using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Data;

namespace Open.MingdaoSDK.Common
{
    /// <summary>
    /// Provides utility methods for xml serialization.
    /// </summary>
    public static class XmlSerializationHelper
    {
        /// <summary>
        /// Deserializes an object (type indicated by <typeparamref name="T"/>) loaded from the specified <paramref name="location"/>. 
        /// </summary>
        /// <typeparam name="T">The type of the object.</typeparam>
        /// <param name="location">The file location.</param>
        /// <returns>The object deserialized.</returns>
        public static T LoadFromFile<T>(string location) where T : class
        {
            T result = null;
            using (XmlTextReader reader = new XmlTextReader(location))
            {
                XmlSerializer s = new XmlSerializer(typeof(T));

                result = s.Deserialize(reader) as T;
            }

            return result;
        }

        /// <summary>
        /// Serializes the <paramref name="target"/> object into xml and then saves it into the file specified by <paramref name="location"/>.
        /// </summary>
        /// <param name="target">The object to serialize.</param>
        /// <param name="location">The file location.</param>
        public static void SaveToFile(object target, string location)
        {
            using (StreamWriter writer = new StreamWriter(location))
            {
                XmlSerializer s = new XmlSerializer(target.GetType());

                s.Serialize(writer, target);
            }
        }

        /// <summary>
        /// Deserializes an object (type indicated by <typeparamref name="T"/>) from the specified <paramref name="xml"/>.
        /// </summary>
        /// <typeparam name="T">The type of the object.</typeparam>
        /// <param name="xml">The xml string.</param>
        /// <returns>The object deserialized.</returns>
        public static T XmlToObject<T>(string xml) where T : class
        {
            return XmlToObject(typeof(T), xml) as T;
        }

        /// <summary>
        /// Deserializes an object (type indicated by <paramref name="type"/>) from the specified <paramref name="xml"/>.
        /// </summary>
        /// <param name="type">The type of the object.</param>
        /// <param name="xml">The xml string.</param>
        /// <returns>The object deserialized.</returns>
        public static object XmlToObject(Type type, string xml)
        {
            object result = null;
            using (TextReader reader = new StringReader(xml))
            {
                //XmlDocument doc = new XmlDocument();
                //doc.LoadXml(xml);
                //doc.GetElementsByTagName("result");
                //return doc.GetElementById("error_code") ;
                XmlSerializer s = new XmlSerializer(type);

                result = s.Deserialize(reader);
            }

            return result;
        }
        /// <summary>
        /// 从XML字符串中反序列化对象
        /// </summary>
        /// <typeparam name="T">结果对象类型</typeparam>
        /// <param name="s">包含对象的XML字符串</param>
        /// <param name="encoding">编码方式</param>
        /// <returns>反序列化得到的对象</returns>
        public static T XmlDeserialize<T>(string s, Encoding encoding)
        {
            if (string.IsNullOrEmpty(s))
                throw new ArgumentNullException("s");
            if (null == encoding)
                throw new ArgumentNullException("encoding");

            XmlSerializer ser = new XmlSerializer(typeof(T));
            using (MemoryStream ms = new MemoryStream(encoding.GetBytes(s)))
            {
                using (StreamReader sr = new StreamReader(ms, encoding))
                {
                    try
                    {
                        return (T)ser.Deserialize(sr);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
        }
        /// <summary>
        /// Serializes the <paramref name="target"/> object into xml.
        /// </summary>
        /// <param name="target">The object to serialize.</param>
        /// <returns>The xml string.</returns>
        public static string ObjectToXml(object target)
        {
            string result = string.Empty;
            using (Stream stream = new MemoryStream())
            {
                XmlSerializer s = new XmlSerializer(target.GetType());
                s.Serialize(stream, target);

                stream.Position = 0;
                StreamReader sReader = new StreamReader(stream);
                result = sReader.ReadToEnd();
            }

            return result;
        }
        public static DataTable XmlToDataTable(Type type, string xml)
        {
            if (string.IsNullOrEmpty(xml)) { return null; }
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(new System.IO.MemoryStream(System.Text.Encoding.Default.GetBytes(xml)));
            return dataSet.Tables[0];
        }
    }
}
