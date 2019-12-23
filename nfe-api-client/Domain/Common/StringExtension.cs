using Newtonsoft.Json;
using ServiceInvoice.Domain.Models;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace System
{
    public static class StringExtension
    {
        // It is not OK yet!!
        public static ServiceInvoiceResource XmlToInvoiceResource(this string xml)
        {
            var serializer = new XmlSerializer(typeof(ServiceInvoiceResource));
            var rdr = new StringReader(xml);
            return (ServiceInvoiceResource)serializer.Deserialize(rdr);
        }

        public static byte[] GetBytesFromString(this string value)
        {
            return Encoding.UTF8.GetBytes(value);
        }

        public static T JsonToObject<T>(this string json) where T : class
        {
            return JsonConvert.DeserializeObject<T>(json);
        }

        public static string ToJson<T>(this object value)
        {
            return JsonConvert.SerializeObject(value);
        }
    }
}
