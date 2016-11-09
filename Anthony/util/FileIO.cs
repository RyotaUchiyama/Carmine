using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carmine.util
{
    class FileIO
    {

        public const string DEFAULT_ENCODING = "UTF-8";

        public static string TextFileReader(string absoluteFilePath)
        {
            return TextFileReader(absoluteFilePath, DEFAULT_ENCODING);
        }

        public static string TextFileReader(string absoluteFilePath,string encode)
        {
            string readedText = string.Empty;

            if (File.Exists(absoluteFilePath))
            {
                using (System.IO.StreamReader sr = new System.IO.StreamReader(
                    absoluteFilePath,
                    System.Text.Encoding.GetEncoding(encode)))
                {
                    //内容をすべて読み込む
                    readedText = sr.ReadToEnd();
                }
            }
            return readedText;
        }

    }
}
