using System;
using System.Collections.Generic;
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

        private Dictionary<string, Uri> uriDictionary;

        private void Initialize()
        {
            uriDictionary = new Dictionary<string, Uri>();

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
    }
}
