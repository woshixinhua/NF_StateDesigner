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
using System.ComponentModel;

namespace DesignerItem
{
    //public class DesignerItemMouseEventArgs
    //{
    //    MouseEventArgs Args;

    //}

    public class DesignerItemBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private DesignerCanvasStyle canvas_style;
        public DesignerCanvasStyle CanvasStyle
        {
            get { return canvas_style; }
            set { canvas_style = value; if (PropertyChanged != null) { PropertyChanged(this, new PropertyChangedEventArgs("CanvasStyle")); } }
        }


        public void UpdateCanvasProperty(DesignerItemProperty.DesignerItemPropertyChangedEventArg e)
        {
            DesignerCanvasStyle style = e.PropertyObject as DesignerCanvasStyle;
            if(style != null)
            {
                CanvasStyle = style;
            }
        }

        public DesignerItemBase()
        {
            
        }

        public MouseEventHandler MouseDownHandler = (sender, e) => { };
        public MouseEventHandler MouseMoveHandler = (sender, e) => { };
        public MouseEventHandler MouseUpHandler   = (sender, e) => { };

    }
}
