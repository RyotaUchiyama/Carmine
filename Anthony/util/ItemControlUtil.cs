using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Carmine.util
{
    public class ItemControlUtil
    {
        /// <summary>
        /// 指定アイテムを所有するコンテナを取得する。
        /// </summary>
        public static FrameworkElement GetItemContainer(ItemsControl itemsControl, DependencyObject item)
        {
            if ((itemsControl == null) || (item == null))
            {
                return null;
            }
            return itemsControl.ContainerFromElement(item) as FrameworkElement;
        }

        /// <summary>
        /// 指定アイテムのデータを取得する。
        /// </summary>
        public static object GetItemData(ItemsControl itemsControl, DependencyObject item)
        {
            var container = GetItemContainer(itemsControl, item);
            return (container == null) ? null : container.DataContext;
        }

        /// <summary>
        /// 指定アイテムデータのItemsControl内でのインデックスを取得する。
        /// </summary>
        public static int GetItemIndex(ItemsControl itemsControl, object data)
        {
            if(itemsControl == null || data == null)
            {
                return -1;
            }
            var items = itemsControl.ItemsSource as IList;
            return items.IndexOf(data);
        }
    }
}
