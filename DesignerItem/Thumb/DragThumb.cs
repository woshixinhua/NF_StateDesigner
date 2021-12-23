using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Controls.Primitives;

namespace DesignerItem
{
    public class DragThumb : Thumb
    {
        public DragThumb()
        {
            DragDelta += new DragDeltaEventHandler(this.DragDeltaHandler);
        }

        private void DragDeltaHandler(object sender, DragDeltaEventArgs e)
        {
            UserControl item = this.DataContext as UserControl;
            DesignerCanvas canvas = item.DataContext as DesignerCanvas;

            if ((item != null) && (canvas != null))
            {
                Vector delta = new Vector(e.HorizontalChange, e.VerticalChange);
                Point pos = new Point(Canvas.GetLeft(item), Canvas.GetTop(item));

                canvas.MoveDesignerItem(item, pos + delta);

                //canvas.MoveDesignerItem(item, Mouse.GetPosition(canvas));
            }
        }
    }
}
