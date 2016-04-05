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
    /// Interaction logic for LoadedEventObject.xaml
    /// </summary>
    public partial class EventView : UserControl
    {
        DEvent de;
        TimeSpan timespan;

        public EventView(DEvent de)
        {
            this.de = de;

            InitializeComponent();

            updateElements();
        }

        public void updateElements()
        {
            eventName.Text = de.getName();
            eventNotes.Text = de.getNotes();
            dateText.Text = de.getTime().ToShortDateString();
            timeText.Text = de.getTime().ToShortTimeString();
            updateRelativeDueTime(DateTime.Now);
        }

        public void updateRelativeDueTime(DateTime now)
        {
            timespan = de.getTime() - now;
            relativeDueText.Text = "Due in: " + timespan.Days.ToString() + " Days, " + timespan.Hours.ToString() + " Hours and " + timespan.Minutes.ToString() + " minutes";
        }

        public DEvent getDEvent()
        {
            return de;
        }

        public void setDEvent(DEvent de)
        {
            this.de = de;
        }
    }
}
