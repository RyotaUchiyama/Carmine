using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carmine.util
{
    public class FileIO
    {

        private static Encoding defaultEncoding = Encoding.UTF8;
        public static Encoding DefaultEncoding
        {
            get
            {
                return defaultEncoding;
            }
        }


        public static string TextFileReader(string fileName)
        {
            return TextFileReader(Directory.GetCurrentDirectory(),fileName, DefaultEncoding);
        }

        public static string TextFileReader(string folderPath, Encoding fileName)
        {
            return TextFileReader(folderPath, DefaultEncoding);
        }

        public static string TextFileReader(string folderPath, string fileName, Encoding encode)
        {
            string readedText = string.Empty;
            string absoluteFilePath = Path.Combine(folderPath,fileName);

            if (File.Exists(absoluteFilePath))
            {
                using (System.IO.StreamReader sr = new System.IO.StreamReader(
                    absoluteFilePath,
                    encode))
                {
                    //内容をすべて読み込む
                    readedText = sr.ReadToEnd();
                }
            }
            return readedText;
        }

        public static bool TextFileWriter(string writeText , string fileName)
        {
            return TextFileWriter(writeText, Directory.GetCurrentDirectory(), fileName, true);
        }

        public static bool TextFileWriter(string writeText, string folderPath,string fileName)
        {
            return TextFileWriter(writeText, folderPath, fileName, true);
        }

        public static bool TextFileWriter(string writeText, string folderPath, string fileName,bool isOverwrite)
        {
            string fileFullPath = Path.Combine(folderPath,fileName);

            // ディレクトリ存在チェック
            if (!Directory.Exists(folderPath))
            {
                return false;
            }

            // 上書きNG時のファイル存在チェック
            if (!isOverwrite && File.Exists(fileFullPath))
            {
                return false;
            }

            using (StreamWriter sw = new StreamWriter(fileFullPath,false,DefaultEncoding))
            {
                sw.Write(writeText);
            }
            return true;
        }


    }
}
