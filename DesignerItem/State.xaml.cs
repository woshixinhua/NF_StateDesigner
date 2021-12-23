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
using System.Diagnostics;

namespace DesignerItem
{
    /// <summary>
    /// State.xaml 的交互逻辑
    /// </summary>
    public partial class State : UserControl, IDesignerItem, IDesignerItemFocusOn
    {
        public State()
        {
            InitializeComponent();

            ItemBase.MouseMoveHandler = MouseMoveHandler;
            ItemBase.MouseUpHandler   = MouseUpHandler;
        }

        DesignerItemBase IDesignerItem.GetBase()
        {
            return ItemBase;
        }

        enum DragMode
        {
            Right,
            Left,
            Top,
            Bottom,
            Move,

            None
        }

        DragMode ThenDragMode = DragMode.None;

        private DragMode GetDragMode(MouseEventArgs e)
        {
            Point pos = e.GetPosition(this);
            uint border_width = ItemBase.CanvasStyle.HalfGrid;

            bool on_right_border = (( this.Width - pos.X >= 0 ) && ( this.Width - pos.X <= border_width )) ? true : false;
            bool on_left_border = ( border_width - pos.X >= 0 ) ? true : false;
            bool on_top_border = ( border_width - pos.Y >= 0 ) ? true : false;
            bool on_bottom_border = ((this.Height - pos.Y >= 0)&&(this.Height - pos.Y <= border_width)) ? true : false;

            bool on_body = ((pos.X <= this.Width) && (pos.Y <= this.Height))
                && (!on_right_border) && (!on_left_border)
                && (!on_top_border) && (!on_bottom_border) ? true : false;

            if (on_right_border)
            {
                return DragMode.Right;
            }
            else if (on_left_border)
            {
                return DragMode.Left;
            }
            else if (on_top_border)
            {
                return DragMode.Top;
            }
            else if (on_bottom_border)
            {
                return DragMode.Bottom;
            }
            else if (on_body)
            {
                return DragMode.Move;
            }
            else
            {
                return DragMode.None;
            }
        }


        public event IDesignerItemFocusOn.DesignerItemFocusOnEventHandler FocusOn;

        private void UserControl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            FocusOn(this);

            DragMode mode = GetDragMode(e);
            ThenDragMode = mode;

            switch (mode)
            {
                case DragMode.Right: Cursor = Cursors.SizeWE; break;
                case DragMode.Left: Cursor = Cursors.SizeWE; break;
                case DragMode.Top: Cursor = Cursors.SizeNS; break;
                case DragMode.Bottom: Cursor = Cursors.SizeNS; break;
                case DragMode.Move: Cursor = Cursors.Hand; break;
                case DragMode.None: Cursor = Cursors.Arrow; break;
            }
        }

        public void MouseMoveHandler(object sender, MouseEventArgs e)
        {
            DragMode mode = GetDragMode(e);

            switch (mode)
            {
                case DragMode.Right: Cursor = Cursors.SizeWE; break;
                case DragMode.Left: Cursor = Cursors.SizeWE; break;
                case DragMode.Top: Cursor = Cursors.SizeNS; break;
                case DragMode.Bottom: Cursor = Cursors.SizeNS; break;
                case DragMode.Move: Cursor = Cursors.Hand; break;
                case DragMode.None: Cursor = Cursors.Arrow; break;
            }

            //Trace.WriteLine(mode.ToString() + e.LeftButton.ToString() + " " + e.GetPosition(this).ToString() + "\n");

            if (e.LeftButton == MouseButtonState.Pressed)
            {
                if(ThenDragMode == DragMode.Right)
                {
                    double x = DesignerCanvas.GridAlign(e.GetPosition(this).X, this.ItemBase.CanvasStyle.Grid);

                    if((x - this.Width < 0) && (x < 8 * this.ItemBase.CanvasStyle.Grid))
                    {
                        
                    }
                    else
                    {
                        this.Width = DesignerCanvas.GridAlign(x, this.ItemBase.CanvasStyle.Grid);
                    }
                    
                }
                else if(ThenDragMode == DragMode.Left)
                {
                    double x = DesignerCanvas.GridAlign(e.GetPosition(this).X, this.ItemBase.CanvasStyle.Grid);

                    if ((x > 0) && (this.Width < 8 * this.ItemBase.CanvasStyle.Grid))
                    {

                    }
                    else
                    {
                        this.Width -= x;
                        DesignerCanvas.SetLeft(this, DesignerCanvas.GridAlign(DesignerCanvas.GetLeft(this) + x, this.ItemBase.CanvasStyle.Grid));
                    }
                }
                
            }
        }

        public void MouseUpHandler(object sender, MouseEventArgs e)
        {
            ThenDragMode = DragMode.None;
        }
    }
}
