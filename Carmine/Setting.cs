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
        #region バージョン関連
        [DataMember(Name = "MajorVersion")]
        public int MajorVersion { set; get; }

        [DataMember(Name = "MinorVersion")]
        public int MinorVersion { set; get; }

        [DataMember(Name = "Revision")]
        public int Revision { set; get; }

        [DataMember(Name = "Build")]
        public int Build { set; get; }

        #endregion

        #region Window関連設定
        [DataMember (Name = "WindowStyle")]
        public int WindowStyle { set; get; }

        [DataMember(Name = "WindowState")]
        public int WindowState { set; get; }

        [DataMember(Name = "Width")]
        public int Width { set; get; }

        [DataMember(Name = "MaxWidth")]
        public int MaxWidth { set; get; }

        [DataMember(Name = "MinWidth")]
        public int MinWidth { set; get; }

        [DataMember(Name = "Height")]
        public int Height { set; get; }

        [DataMember(Name = "MaxHeight")]
        public int MaxHeight { set; get; }

        [DataMember(Name = "MinHeight")]
        public int MinHeight { set; get; }

        [DataMember(Name = "TopMost")]
        public bool IsTopMost { set; get; }
        #endregion

        public Setting()
        {
            // バージョン関連
            MajorVersion = 1;
            MinorVersion = 0;
            Revision = 0;
            Build = 0;

            // Windows設定関連
            WindowStyle = (int)System.Windows.WindowStyle.ThreeDBorderWindow;
            WindowState = (int)System.Windows.WindowState.Normal;
            Width = 1200;
            MaxWidth = int.MaxValue;
            MinWidth = 0;
            Height = 800;
            MaxHeight = int.MaxValue;
            MinHeight = 0;
            IsTopMost = false;
        }

        public virtual void ApplySetting()
        {
            MainWindowViewModel.Instance.MainWindowStyle = (System.Windows.WindowStyle)this.WindowStyle;
            MainWindowViewModel.Instance.MainWindowState = (System.Windows.WindowState)this.WindowState;
            MainWindowViewModel.Instance.MainWindowWidth = this.Width;
            MainWindowViewModel.Instance.MainWindowMaxWidth = this.MaxWidth;
            MainWindowViewModel.Instance.MainWindowMinWidth = this.MinWidth;
            MainWindowViewModel.Instance.MainWindowHeight = this.Height;
            MainWindowViewModel.Instance.MainWindowMaxHeight = this.MaxHeight;
            MainWindowViewModel.Instance.MainWindowMinHeight = this.MinHeight;
            MainWindowViewModel.Instance.MainWindowTopmost = this.IsTopMost;
        }
    }

}
