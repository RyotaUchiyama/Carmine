using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Carmine
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        #region ViewModel設定
        // 必須項目
        public event PropertyChangedEventHandler PropertyChanged;

        private void SetProperty<T>(ref T field, T value, [CallerMemberName]string propertyName = null)
        {
            field = value;
            var h = this.PropertyChanged;
            if (h != null) { h(this, new PropertyChangedEventArgs(propertyName)); }
        }
        #endregion

        #region シングルトン
        // シングルトンメソッド設定
        private static MainWindowViewModel instance;
        private MainWindowViewModel()
        {
            InitializeProperties();
        }

        public static MainWindowViewModel Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MainWindowViewModel();
                }
                return instance;
            }
        }
        #endregion

        #region プロパティ
        /// <summary>
        /// ウィンドウスタイル
        /// </summary>
        private System.Windows.WindowStyle mainWindowStyle;
        public System.Windows.WindowStyle MainWindowStyle
        {
            get { return this.mainWindowStyle; }
            set { this.SetProperty(ref this.mainWindowStyle, value); }
        }

        /// <summary>
        /// ウィンドウステータス
        /// </summary>
        private System.Windows.WindowState mainWindowState;
        public System.Windows.WindowState MainWindowState
        {
            get { return this.mainWindowState; }
            set { this.SetProperty(ref this.mainWindowState, value); }
        }

        /// <summary>
        /// ウィンドウ横幅
        /// </summary>
        private double mainWindowWidth;
        public double MainWindowWidth
        {
            get { return this.mainWindowWidth; }
            set { this.SetProperty(ref this.mainWindowWidth, value); }
        }

        private double mainWindowMaxWidth;
        public double MainWindowMaxWidth
        {
            get { return this.mainWindowMaxWidth; }
            set { this.SetProperty(ref this.mainWindowMaxWidth, value); }
        }

        private double mainWindowMinWidth;
        public double MainWindowMinWidth
        {
            get { return this.mainWindowMinWidth; }
            set { this.SetProperty(ref this.mainWindowMinWidth, value); }
        }

        /// <summary>
        /// ウィンドウ縦幅
        /// </summary>
        private double mainWindowHeight;
        public double MainWindowHeight
        {
            get { return this.mainWindowHeight; }
            set { this.SetProperty(ref this.mainWindowHeight, value); }
        }

        private double mainWindowMaxHeight;
        public double MainWindowMaxHeight
        {
            get { return this.mainWindowMaxHeight; }
            set { this.SetProperty(ref this.mainWindowMaxHeight, value); }
        }

        private double mainWindowMinHeight;
        public double MainWindowMinHeight
        {
            get { return this.mainWindowMinHeight; }
            set { this.SetProperty(ref this.mainWindowMinHeight, value); }
        }

        /// <summary>
        /// 最前面表示するか
        /// </summary>
        private bool mainWindowTopmost;
        public bool MainWindowTopmost
        {
            get { return this.mainWindowTopmost; }
            set { this.SetProperty(ref this.mainWindowTopmost, value); }
        }
        #endregion


        private void InitializeProperties()
        {
            MainWindowStyle = System.Windows.WindowStyle.ThreeDBorderWindow;
            MainWindowState = System.Windows.WindowState.Normal;

            MainWindowWidth = 1200;
            MainWindowMaxWidth = double.PositiveInfinity;
            MainWindowMinWidth = 0;

            MainWindowHeight = 800;
            MainWindowMaxHeight = double.PositiveInfinity;
            MainWindowMinHeight = 0;

            MainWindowTopmost = false;
        }
    }
}
