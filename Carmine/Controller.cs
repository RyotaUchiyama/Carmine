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

        private MainWindowSetting jsonSetting;

        #region Initialize
        private void Initialize()
        {
            uriDictionary = new Dictionary<string, Uri>();
            jsonSetting = new MainWindowSetting();

            this.initializeSetting();
            this.InitializeUriDictionary();
        }

        private void initializeSetting()
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
            // 設定ファイル内が空の場合は設定ファイル再生成
            string readedText = string.Empty;
            if ((readedText = util.FileIO.TextFileReader(jsonSettingFileName)) == string.Empty)
            {
                if (!createJsonSettingFile())
                {
                    throw new Exception("CreateJsonFileError");
                }
            }

            jsonSetting = util.Json.JsonSerializer<MainWindowSetting>(readedText, Encoding.UTF8);
        }

        private void InitializeUriDictionary()
        {
            if(jsonSetting == null && jsonSetting.PageInfoList == null )
            {
                return;
            }

            foreach(PageInfo pi in jsonSetting.PageInfoList)
            {
                uriDictionary.Add(pi.MenuName, new Uri(pi.MenuUri, System.UriKind.RelativeOrAbsolute));
            }
        }
        #endregion

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

        private bool createJsonSettingFile()
        {
            // 各パラメータの初期値はSettingに記載する
            // 初期表示メニューを登録
            jsonSetting.PageInfoList.Add( new PageInfo(menuName, "/Benjamin;component/MenuPage.xaml"));

            // json文字列生成してファイル作成
            string jsonStr = util.Json.JsonDeserializer<MainWindowSetting>(jsonSetting);
            return util.FileIO.TextFileWriter(jsonStr,jsonSettingFileName);
        }
    }
}
