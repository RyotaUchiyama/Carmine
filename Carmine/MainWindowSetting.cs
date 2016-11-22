using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace Carmine
{

    [DataContract]
    public class MainWindowSetting : Setting
    {
        [DataMember(Name = "PageInfo")]
        public List<PageInfo> PageInfoList { set; get; }

        public MainWindowSetting()
        {
            // Page関連
            PageInfoList = new List<PageInfo>();
        }
    }

    [DataContract]
    public class PageInfo
    {
        [DataMember(Name = "MenuName")]
        public string MenuName { set; get; }

        [DataMember(Name = "MenuUri")]
        public string MenuUri { set; get; }

        [DataMember(Name = "IsVisible")]
        public bool IsVisible { set; get; } = false;

        public PageInfo(string menuName, string menuUri,bool isVisible)
        {
            MenuName = menuName;
            MenuUri = menuUri;
            IsVisible = isVisible;
        }
    }
}
