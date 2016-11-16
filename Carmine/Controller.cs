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

        private Setting jsonSetting;


        private void Initialize()
        {
            uriDictionary = new Dictionary<string, Uri>();
            jsonSetting = new Setting();

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


        private void initializeJson()
        {
            // settingファイルが存在しない場合はファイルを生成する
            // 生成に失敗した場合はExceptionを投げる
            if (!File.Exists(jsonSettingFileName))
            {
                if (!createJsonSettingFile())
                {
                    throw new Exception("CreateJsonFileError");
                }
            }

            // 設定ファイル読み込み
            // 設定ファイル内が空の場合は
            string readedText = string.Empty;
            if((readedText = util.FileIO.TextFileReader(jsonSettingFileName)) == string.Empty)
            {
                if (!createJsonSettingFile())
                {
                    throw new Exception("CreateJsonFileError");
                }
            }

            Setting s = util.Json.JsonSerializer<Setting>(readedText, Encoding.UTF8);


        }

        private bool createJsonSettingFile()
        {
            jsonSetting.width = 800;
            jsonSetting.height = 600;

            jsonSetting.pageInfo.Add( new PageInfo(menuName, "/Benjamin;component/MenuPage.xaml"));

            string jsonStr = util.Json.JsonDeserializer<Setting>(jsonSetting);

            return util.FileIO.TextFileWriter(jsonStr,jsonSettingFileName);
        }
    }
}
