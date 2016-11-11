using System;
using System.Drawing;
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
    /// DrawGifControll.xaml の相互作用ロジック
    /// </summary>
    public partial class DrawGifControll : UserControl
    {
        System.Drawing.Image m_animatedImage;


        public DrawGifControll()
        {
            InitializeComponent();
            m_animatedImage = new Bitmap(@"C:\private\source\Carmine\bin\Debug\09.gif");
        }

        protected override void OnRender(DrawingContext p_drawingContext)
        {

            //Get the next frame ready for rendering.
            ImageAnimator.UpdateFrames(m_animatedImage);
           
        }
    }
}
