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

namespace Calendar
{
    /// <summary>
    /// Interaction logic for dueEvent.xaml
    /// </summary>
    public partial class IncomingView : UserControl
    {
        DEvent de;

        public IncomingView(DEvent dei)
        {
            InitializeComponent();
            de = dei;
            eventName.Text = de.getName();
            updateRelativeDueTime(DateTime.Now);
        }

        internal void updateRelativeDueTime(DateTime now)
        {
            TimeSpan timespan = de.getTime() - now;
            dueTime.Text = "Due: " + timespan.Days.ToString() + "d, " + timespan.Hours.ToString() + "h, " + timespan.Minutes.ToString() + "m";
        }
    }
}
