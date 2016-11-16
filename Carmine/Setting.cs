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
    public class Setting
    {

        [DataMember]
        public int width { set; get; }

        [DataMember]
        public int height { set; get; }

        [DataMember]
        public List<PageInfo> pageInfo { set; get; }

        public Setting()
        {
            pageInfo = new List<PageInfo>();
        }
    }

    [DataContract]
    public class PageInfo
    {
        [DataMember]
        public string MenuName { set; get; }

        [DataMember]
        public string MenuUri { set; get; }

        public PageInfo(string menuName,string menuUri)
        {
            MenuName = menuName;
            MenuUri = menuUri;
        }

    }
}
