using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace DesignerItem
{
    /// <summary>
    /// DesignerCanvas.xaml 的交互逻辑       
    /// </summary>
    public partial class DesignerCanvas : Canvas
    {
        public DesignerCanvas()
        {
            InitializeComponent();

            CanvasStyle = new DesignerCanvasStyle(this);

            State item = new State();

            AddDesignerItem(item);

            FocusControl = item;

            item.Height = 200;
            item.Width = 200;

            CanvasStyle.Grid = 20;
        }

        public DesignerCanvasStyle CanvasStyle;

        static public Point GridAlign(Point p, UInt32 grid)
        {
            return new Point(GridAlign(p.X, grid), GridAlign(p.Y, grid));
        }

        static public double GridAlign(double pos, UInt32 grid)
        {
            double pos_on_grid = pos / grid;
            double pos_on_grid_decimal = pos_on_grid - Math.Floor(pos_on_grid);

            return (Math.Floor(pos_on_grid) + Math.Round(pos_on_grid_decimal)) * grid;
        }

        public void AddDesignerItem(UserControl item)
        {
            Children.Add(item);
            item.DataContext = this;

            CanvasStyle.Changed += (item as State).ItemBase.UpdateCanvasProperty;
            (item as IDesignerItemFocusOn).FocusOn += DesignerItemFocusOnEventHandler;
        }

        public void MoveDesignerItem(UserControl item, Point pos)
        {
            Point aligned_pos = DesignerCanvas.GridAlign(pos, this.CanvasStyle.Grid);

            Canvas.SetLeft(item, aligned_pos.X);
            Canvas.SetTop(item, aligned_pos.Y);
        }


        public UserControl FocusControl = null;

        private void DesignerItemFocusOnEventHandler(UserControl sender)
        {
            FocusControl = sender;
        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            (FocusControl as IDesignerItem).GetBase().MouseMoveHandler(FocusControl, e);
        }
    }
}
