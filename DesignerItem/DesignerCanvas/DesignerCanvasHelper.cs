using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;

namespace DesignerItem
{
    public class DesignerCanvasStyle : DesignerItemProperty
    {
        public DesignerCanvasStyle(DesignerCanvas canvas)
        {
            this.Canvas = canvas;
        }

        public DesignerCanvas Canvas;

        private uint grid = 20;
        public uint Grid
        {
            get { return grid; }
            set { grid = value; half_grid = grid / 2; PropertyChange(); }
        }

        private uint half_grid = 10;
        public uint HalfGrid
        {
            get { return grid; }
            set { PropertyChange(); }
        }


        private Brush grid_color = Brushes.Black;
        public Brush GridColor
        {
            get { return grid_color; }
            set { grid_color = value; PropertyChange(); }
        }


        private Brush back_ground_Color = Brushes.White;
        public Brush BackGroundColor
        {
            get { return back_ground_Color; }
            set { back_ground_Color = value; PropertyChange(); }
        }


        public enum DesignerMode
        {
            Select,
            State,
            Translation
        };

        private DesignerMode mode;
        public DesignerMode Mode
        {
            get { return mode; }
            set { mode = value; PropertyChange(); }
        }

    }
}
    