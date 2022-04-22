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
using System.Diagnostics;

namespace Lab3_4
{
    public class ObjGetters
    {
        public static TextBox getTextBoxObject(Grid grid, String objName)
        {
            var data = grid.FindName(objName) as TextBox;
            return data;

        }
        public static Label getLabelObject(Grid grid, String objName)
        {
            var data = grid.FindName(objName) as Label;
            return data;
        }

        public static T getObject<T>(Grid grid, String objName)
        {
            return (T)grid.FindName(objName);
        }
    }
}
