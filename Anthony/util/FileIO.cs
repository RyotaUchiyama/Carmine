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

        public const string DEFAULT_ENCODING = "UTF-8";


        public static string TextFileReader(string fileName)
        {
            return TextFileReader(Directory.GetCurrentDirectory(),fileName, DEFAULT_ENCODING);
        }

        public static string TextFileReader(string folderPath,string fileName)
        {
            return TextFileReader(folderPath, DEFAULT_ENCODING);
        }

        public static string TextFileReader(string folderPath, string fileName, string encode)
        {
            string readedText = string.Empty;
            string absoluteFilePath = Path.Combine(folderPath,fileName);

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

            using (StreamWriter sw = new StreamWriter(fileFullPath,false,System.Text.Encoding.GetEncoding(DEFAULT_ENCODING)))
            {
                sw.Write(writeText);
            }
            return true;
        }


    }
}
