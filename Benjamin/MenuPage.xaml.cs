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
    /// MenuPage.xaml の相互作用ロジック
    /// </summary>
    public partial class MenuPage : BasePage
    {
        public MenuPage()
        {
            InitializeComponent();
            
        }

        public void AddMenu(MenuIcon menuIcon)
        {
            
        }

        #region ドラッグアンドドロップ操作
        /// <summary>
        /// ドラッグデータ
        /// </summary>
        private object DraggedData { set; get; }

        /// <summary>
        /// ドラッグアイテムのインデックス
        /// </summary>
        private int? DraggedItemIndex { set; get; }

        /// <summary>
        /// スタート位置取得
        /// </summary>
        private Point? StartPosition { set; get; }

        private void MenuPanel_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var itemsControl = sender as ItemsControl;
            var draggedItem = e.OriginalSource as FrameworkElement;

            if (itemsControl == null || draggedItem == null)
            {
                return;
            }

            DraggedData = util.ItemControlUtil.GetItemData(itemsControl,draggedItem);
            if (DraggedData == null)
            {
                return;
            }

            StartPosition = this.PointToScreen(e.GetPosition(this));
            DraggedItemIndex = util.ItemControlUtil.GetItemIndex(itemsControl,DraggedData);
        }

        /// <summary>
        /// ドラッグ開始とする距離を移動したか
        /// </summary>
        private bool IsDragStartable(Vector delta)
        {
            return (SystemParameters.MinimumHorizontalDragDistance < Math.Abs(delta.X)) ||
                   (SystemParameters.MinimumVerticalDragDistance < Math.Abs(delta.Y));
        }

        /// <summary>
        /// ドラッグ＆ドロップ関連データをクリーンアップする。
        /// </summary>
        private void CleanUpDragDropAndDropData()
        {
            DraggedData = null;
            DraggedItemIndex = null;
            StartPosition = null;
        }

        private void MenuPanel_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            var itemsControl = sender as ItemsControl;
            if(itemsControl == null || StartPosition == null)
            {
                return;
            }

            Point curPos = itemsControl.PointToScreen(e.GetPosition(itemsControl));
            Vector diff = curPos - (Point)StartPosition;
            if (IsDragStartable(diff))
            {
                DragDrop.DoDragDrop(itemsControl, DraggedData, DragDropEffects.Move);
                CleanUpDragDropAndDropData();
            }
        }

        private void MenuPanel_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            CleanUpDragDropAndDropData();
        }

        #endregion
    }
}
