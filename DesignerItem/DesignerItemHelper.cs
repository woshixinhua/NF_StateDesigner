using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DesignerItem
{
    public class DesignerItemProperty
    {
        public delegate void ChangeHandler(DesignerItemPropertyChangedEventArg e);

        public event ChangeHandler Changed;

        public class DesignerItemPropertyChangedEventArg
        {
            public DesignerItemProperty PropertyObject;

            public DesignerItemPropertyChangedEventArg(DesignerItemProperty prop)
            {
                this.PropertyObject = prop;
            }
        }

        public void PropertyChange()
        {
            if(this.Changed != null)
            {
                this.Changed(new DesignerItemPropertyChangedEventArg(this));
            }
        }
    }
}
