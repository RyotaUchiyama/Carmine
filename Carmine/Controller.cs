using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carmine
{
    public class Controller
    {
        #region シングルトン
        private static Controller instance;
        private Controller()
        {
            Initialize();
        }

        public static Controller Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Controller();
                }
                return instance;
            }
        }
        #endregion

        private string menuName = "Mainmenu";
        private const string jsonSettingFileName = "setting.json";

        private Dictionary<string, Uri> uriDictionary;
        private Dictionary<string, Type> jsonParamDictionary;

        private void Initialize()
        {
            uriDictionary = new Dictionary<string, Uri>();
            jsonParamDictionary = new Dictionary<string, Type>();


            this.initializeJson();


            // 初期表示メニューを追加
            uriDictionary.Add(menuName, new Uri("/Benjamin;component/MenuPage.xaml", System.UriKind.Relative));
        }

        public Uri Mainmenu 
        {
            get
            {
                if (uriDictionary.ContainsKey(menuName))
                {
                    return uriDictionary[menuName];
                }
                else
                {
                    return null;
                }
            }           
        }

        public bool AddPage(string key,Uri addUri)
        {
            if(uriDictionary.ContainsKey(key))
            {
                return false;
            }

            uriDictionary.Add(key, addUri);
            return true;
        }

        public Uri GetPageUri(string key)
        {
            if (!uriDictionary.ContainsKey(key))
            {
                return null;
            }
            return uriDictionary[key];
        }

        private void initializeJsonParamDictionary()
        {
            if(jsonParamDictionary == null)
            {
                jsonParamDictionary = new Dictionary<string, Type>();
            }

            jsonParamDictionary.Add("width", typeof(int));
            jsonParamDictionary.Add("height", typeof(int));
            jsonParamDictionary.Add("width", typeof(int));
            jsonParamDictionary.Add("width", typeof(int));
            jsonParamDictionary.Add("width", typeof(int));
        }

        private void initializeJson()
        {
            if (!File.Exists(jsonSettingFileName))
            {
                if (createJsonSettingFile())
                {
                    throw new Exception("CreateJsonFileError");
                }
            }

            string readedText = string.Empty;
            if((readedText = util.FileIO.TextFileReader(jsonSettingFileName)) == string.Empty)
            {
                if (createJsonSettingFile())
                {
                    throw new Exception("CreateJsonFileError");
                }
            }

            dynamic jsonObj = util.Json.JsonParse(readedText);

            int width = (int)jsonObj.width;
            int height = (int)jsonObj.height;
            bool isFullScreen = (bool)jsonObj.isFullScreen;


        }
        private bool createJsonSettingFile()
        {
            var obj = new
            {
                width = 800,
                height = 600,
                isFullScreen = false
            };

            string jsonStr = Carmine.util.Json.CreateJsonString(obj);

            return util.FileIO.TextFileWriter(jsonStr, jsonSettingFileName);
        }

    }
}
