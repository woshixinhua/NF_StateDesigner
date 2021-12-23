using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace DesignerItem
{
    public interface IDesignerItemFocusOn
    {
        public delegate void DesignerItemFocusOnEventHandler(UserControl sender);
        public event DesignerItemFocusOnEventHandler FocusOn;
    }
}
