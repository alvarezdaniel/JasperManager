using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JasperManager
{
    public class JrxmlFile
    {
        public string Label { get; set; }

        public string Type { get; set; }

        public string Content { get; set; }

        public JrxmlFile(string Label, string Type)
        {
            // TODO: Complete member initialization
            this.Label = Label;
            this.Type = Type;
        }

        public void ContentFile(byte[] Data)
        {
            string Base64Text = Convert.ToBase64String(Data);

            this.Content = Base64Text;
        }

        public void ContentFile(string file)
        {
            byte[] reportFile = null;
            using (System.IO.StreamReader read = new System.IO.StreamReader
                (file))
            {
                reportFile = new byte[read.BaseStream.Length];
                read.BaseStream.Read(reportFile, 0, (int)read.BaseStream.Length);
            }

            string Base64Text = Convert.ToBase64String(reportFile);

            this.Content = Base64Text;
        }

        public override string ToString()
        {
            return "{ \"jrxmlFile\": {\"type\":\"" + Type + "\", \"label\": \"" + Label + "\", \"content\": \"" + Content + "\" } }";
        }
    }
}
