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
using System.Windows.Shapes;

namespace Calendar
{
    /// <summary>
    /// Interaction logic for editWindow.xaml
    /// </summary>
    public partial class editWindow : Window
    {
        MainWindow main;
        DEvent de;
        public editWindow(MainWindow main)
        {
            InitializeComponent();
            this.main = main;
            de = null;
        }

        public editWindow(MainWindow main, DEvent de)
        {
            InitializeComponent();
            this.main = main;
            this.de = de;

            if (de.getTime().Hour == 0)
            {
                hourEntry.Text = "12";
                ampmSelecter.SelectedIndex = 0; //sets to AM
            } else if (de.getTime().Hour > 12)
            {
                hourEntry.Text = (de.getTime().Hour - 12).ToString();
                ampmSelecter.SelectedIndex = 1; //sets to PM
            } else
            {
                hourEntry.Text = de.getTime().Hour.ToString();
                ampmSelecter.SelectedIndex = 0; //sets to AM
            }

            minuteEntry.Text = de.getTime().Minute.ToString();
            datePicker.SelectedDate = de.getTime();
            nameEntry.Text = de.getName();
            noteEntry.Text = de.getNotes();

        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            main.editToggle = false;
            this.Close();
        }

        private void saveButtonClick(object sender, RoutedEventArgs e)
        {
            TimeSpan time;
            int hours;
            int minutes;
            DateTime date;
            string eventName;
            string eventNotes;

            string errorMessage = "Please enter an Event Name and a valid time: hours(between 1 and 12):minutes(between 0 and 59).  Also, no reason, but don't use the sequence '<<@>>' anywhere.  No reason, just don't.";

            try {
                if (minuteEntry.Text.ToString() == "") minuteEntry.Text = "00"; //we default to 0 minutes

                hours = int.Parse(hourEntry.Text.ToString());
                minutes = int.Parse(minuteEntry.Text.ToString());
                date = (DateTime)datePicker.SelectedDate;
                eventName = nameEntry.Text;
                eventNotes = noteEntry.Text;

                if (eventName == "" || eventName.Contains("<<@>>") || eventNotes.Contains("<<@>>")) throw new FormatException();

                //This checks to see if the time has been entered in a proper format
                if ((hours < 1) || (hours > 12) || (minutes < 0) || (minutes > 59)) throw new FormatException();

                //since we're entering time by adding hours and minutes to a date stamp, we need to correct the hours to military time
                if (hours == 12) hours = 0;

                //same as above, we add 12 hours if the event is in the evening to convert to military time
                if (ampmSelecter.SelectedValue.ToString() == "PM") hours += 12;

                //this is the timespan that will be added to the date
                time = new TimeSpan(hours, minutes, 0);

                date = date.Add(time);

                //Console.Out.WriteLine(date.ToString());
                //Console.Out.WriteLine(eventName);
                //Console.Out.WriteLine(eventNotes);

                if (de == null)
                {
                    main.addEventToList(new DEvent(eventName, date, eventNotes));
                } else
                {
                    de.setName(eventName);
                    de.setTime(date);
                    de.setNotes(eventNotes);
                    main.updateView();
                }

                main.editToggle = false;
                Close();

            } catch (FormatException)
            {
                MessageBox.Show(errorMessage);
                return;
            } catch (OverflowException)
            {
                MessageBox.Show(errorMessage);
                return;
            } catch (InvalidOperationException)
            {
                MessageBox.Show("Please select a Date");
            }
        }

        private void onClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            main.editToggle = false;
        }
    }
}
