using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Carmine
{
    /// <summary>
    /// MenuIcon.xaml の相互作用ロジック
    /// </summary>
    public partial class MenuIcon : UserControl
    {
        // 依存プロパティの作成
        public static readonly DependencyProperty IconSourceProperty =
            DependencyProperty.Register("IconSource",
                                        typeof(string),
                                        typeof(MenuIcon),
                                        new FrameworkPropertyMetadata("IconSource", new PropertyChangedCallback(OnIconSourceChanged)));

        public static readonly DependencyProperty IconTextProperty =
            DependencyProperty.Register("IconText",
                                        typeof(string),
                                        typeof(MenuIcon),
                                        new FrameworkPropertyMetadata("IconText", new PropertyChangedCallback(OnIconContentChanged)));

        // CLI用プロパティを提供するラッパー
        public string IconSource
        {
            get { return (string)GetValue(IconSourceProperty); }
            set { SetValue(IconSourceProperty, value); }
        }

        public string IconText
        {
            get { return (string)GetValue(IconTextProperty); }
            set { SetValue(IconTextProperty, value); }
        }

        public MenuIcon()
        {
            InitializeComponent();

            this.HorizontalAlignment = HorizontalAlignment.Left;
            this.VerticalAlignment = VerticalAlignment.Top;           
        }

        // 依存プロパティが変更されたとき呼ばれるコールバック関数の定義
        private static void OnIconSourceChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            // オブジェクトを取得して処理する
            MenuIcon ctrl = obj as MenuIcon;
            if (ctrl != null)
            {
                ctrl.IconImage.Source = new BitmapImage( new Uri(ctrl.IconSource, UriKind.RelativeOrAbsolute));
                //ctrl.TitleTextBlock.Text = ctrl.Title;
            }
        }

        private static void OnIconContentChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            // オブジェクトを取得して処理する
            MenuIcon ctrl = obj as MenuIcon;
            if (ctrl != null)
            {
                ctrl.IconName.Text = ctrl.IconText;
            }
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
