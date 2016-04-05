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
using System.Timers;
using System.IO;
using System.Text.RegularExpressions;

namespace Calendar
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public bool editToggle;
        private Timer Dtimer;
        private List<DateView> dateViewList;
        private List<DEvent> eventList;
        private List<EventView> eventViewList;
        private int daysInFuture;
        private string ioFile;


        public MainWindow()
        {
            ioFile = "events.txt";
            daysInFuture = 30;
            dateViewList = new List<DateView>();
            eventList = new List<DEvent>();
            eventViewList = new List<EventView>();
            editToggle = false;

            InitializeComponent();

            readEvents();

            generateDates(daysInFuture, DateTime.Now);

            populateIncoming(DateTime.Now);

            timeView.Text = DateTime.Now.ToShortDateString() + ": " + DateTime.Now.ToShortTimeString();

            ///Dtimer = new Timer(60000);
            Dtimer = new Timer((60 - DateTime.Now.Second) * 1000 - DateTime.Now.Millisecond);
            Dtimer.Elapsed += new ElapsedEventHandler(timerAction);
            Dtimer.Start();
        }

        private void readEvents()
        {

            //need to test for ioFile existing here, create it if it doesn't.
            try {
                string[] stringEvents = File.ReadAllLines(ioFile);

                foreach (string line in stringEvents)
                {
                    string[] tempInfo = Regex.Split(line, "<<@>>");
                    try {
                        DEvent tempEvent = new DEvent(tempInfo[0], DateTime.Parse(tempInfo[1]), tempInfo[2]);
                        if (tempEvent.getTime() > DateTime.Now)
                        {
                            eventList.Add(tempEvent);
                        }
                    } catch (System.FormatException)
                    {
                        MessageBox.Show("events.txt Data file has been corrupted.  Please erase or fix file and restart program");
                        Close();
                    } catch (System.IndexOutOfRangeException)
                    {
                        MessageBox.Show("events.txt Data file has been corrupted.  Please erase or fix file and restart program");
                        Close();
                    }
                }
                eventList.Sort();
            }
            catch (FileNotFoundException)
            {
                StreamWriter sw = new StreamWriter(ioFile);
                sw.Close();
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void writeEvents()
        {
            try {
                StreamWriter sw = new StreamWriter(ioFile);
                foreach (DEvent de in eventList)
                {
                    string temp = de.getName() + "<<@>>" + de.getTime() + "<<@>>" + de.getNotes();
                    sw.WriteLine(temp);
                }
                sw.Close();
            } catch (IOException ex)
            {
                MessageBox.Show("Could not create event file, nothing will be saved this session.  Error: " + ex.Message);
            }
        }

        private void generateDates(int amount, DateTime now)
        {
            for (int i = 0; i <= amount; i++)
            {
                DateView tempDate = new DateView(now.ToShortDateString());
                tempDate.Width = 250;
                dateViewList.Add(tempDate);
                eventView.Children.Add(tempDate);

                foreach(DEvent de in eventList)
                {
                    if (de.getTime().ToShortDateString() == now.ToShortDateString())
                    {
                        EventView tempEventView = new EventView(de);
                        tempEventView.editButton.Click += (object sender, RoutedEventArgs e) =>
                        {
                            if (!editToggle)
                            {
                                editWindow w = new editWindow(this, de);
                                w.Show();
                                editToggle = true;
                            }
                        };
                        tempEventView.deleteButton.Click += (object sender, RoutedEventArgs e) =>
                        {
                            eventList.Remove(de);
                            updateView();
                        };
                        tempDate.itemPanel.Children.Add(tempEventView);
                        eventViewList.Add(tempEventView);
                    }
                }

                now = now.AddDays(1);
            }
            Button moreDaysButton = new Button();
            moreDaysButton.Content = "More days...";
            moreDaysButton.Click += MoreDaysButton_Click;
            eventView.Children.Add(moreDaysButton);
            
        }

        private void MoreDaysButton_Click(object sender, RoutedEventArgs e)
        {
            daysInFuture += 30;
            updateView();
        }

        private void populateIncoming(DateTime now)
        {
            if (eventList.Count() > 0) dueListView.Children.Add(new IncomingView(eventList[0]));
            if (eventList.Count() > 1) dueListView.Children.Add(new IncomingView(eventList[1]));

        }

        private void timerAction(object source, ElapsedEventArgs e)
        {
            try {
                timeView.Dispatcher.Invoke(timerUpdate);
            } catch (TaskCanceledException)
            {

            }
        }

        private void timerUpdate()
        {
            DateTime now = DateTime.Now;
            timeView.Text = now.ToShortDateString() + ": " + now.ToShortTimeString();
            //foreach (EventView ev in eventViewList)
            //{
            //    ev.updateRelativeDueTime(now);
            //}
            //foreach (IncomingView iv in dueListView.Children)
            //{
            //    iv.updateRelativeDueTime(now);
            //}
            updateView();
        }

        private void timerIntervalUpdate()
        {
            Dtimer.Interval = (60 - DateTime.Now.Second) * 1000 - DateTime.Now.Millisecond;
            //Console.Out.WriteLine(Dtimer.Interval);
        }

        private void addEventButton_Click(object sender, RoutedEventArgs e)
        {
            if (!editToggle)
            {
                editWindow w = new editWindow(this);
                w.Show();
                editToggle = true;
            }
        }

        public void addEventToList(DEvent ev)
        {
            if (ev.getTime() > DateTime.Now) {
                eventList.Add(ev);
                //eventList.Sort();
                //writeEvents();
                updateView();
            }
            else
            {
                MessageBox.Show("Cannot add events before current date-time");
            }
        }

        public void updateView()
        {
            Dtimer.Stop();
            eventViewList.Clear();
            dateViewList.Clear();
            eventView.Children.Clear();
            dueListView.Children.Clear();

            clearPastEvents();
            eventList.Sort();
            writeEvents();

            generateDates(daysInFuture, DateTime.Now);
            populateIncoming(DateTime.Now);
            timerIntervalUpdate();
            Dtimer.Start();
        }

        private void clearPastEvents()
        {
            for (int i = eventList.Count - 1; i >= 0; i--)
            {
                if (eventList[i].getTime() < DateTime.Now)
                {
                    eventList.RemoveAt(i);
                } 
            }
        }

        private void printButton_Click(object sender, RoutedEventArgs e)
        {
            //try {
            //    StreamWriter sw = new StreamWriter("EventReport.txt", true);
            //    sw.WriteLine("Event Report as of " + DateTime.Now.ToLongDateString());
            //    sw.WriteLine("");
            //    foreach (DEvent de in eventList)
            //    {
            //        //string temp = de.getName() + "<<@>>" + de.getTime() + "<<@>>" + de.getNotes();
            //        //sw.WriteLine(temp);
            //        sw.WriteLine("Event: " + de.getName());
            //        sw.WriteLine("Occurs: " + de.getTime().ToLongDateString() + " " + de.getTime().ToLongTimeString());
            //        sw.WriteLine("Notes: " + de.getNotes());
            //        sw.WriteLine("");
            //    }
            //    sw.Close();
            //    MessageBox.Show("File EventReport.txt saved to same directory as program.");
            //} catch (IOException ex)
            //{
            //    MessageBox.Show("Cound not write file.  Error:" + ex.Message);
            //}

            String printMessage = "";
            printMessage += "Event Report as of " + DateTime.Now.ToLongDateString();
            printMessage += "\r\n";
            foreach (DEvent de in eventList)
            {
                //string temp = de.getName() + "<<@>>" + de.getTime() + "<<@>>" + de.getNotes();
                //sw.WriteLine(temp);
                printMessage += "Event: " + de.getName();
                printMessage += "\r\n";
                printMessage += "Occurs: " + de.getTime().ToLongDateString() + " " + de.getTime().ToLongTimeString();
                printMessage += "\r\n";
                printMessage += "Notes: " + de.getNotes();
                printMessage += "\r\n";
                printMessage += "\r\n";
            }

            FlowDocument fd = new FlowDocument(new Paragraph(new Run(printMessage)));
            fd.PagePadding = new Thickness(100);
            IDocumentPaginatorSource idpSource = fd;

            PrintDialog dialog = new PrintDialog();

            dialog.ShowDialog();
            dialog.PrintDocument(idpSource.DocumentPaginator, "Event Report");

            //Console.Out.WriteLine("Print Pressed");
        }
    }
}
