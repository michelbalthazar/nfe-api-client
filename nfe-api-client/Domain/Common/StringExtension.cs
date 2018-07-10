using ServiceInvoice.Domain.Models;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace System
{
    public static class StringExtension
    {
        // It is not OK yet!!
        public static InvoiceResource XmlToInvoiceResource(this string xml)
        {
            var serializer = new XmlSerializer(typeof(InvoiceResource));
            var rdr = new StringReader(xml);
            return (InvoiceResource)serializer.Deserialize(rdr);
        }

        public static byte[] GetBytesFromString(this string value)
        {
            return Encoding.UTF8.GetBytes(value);
        }
    }
}
