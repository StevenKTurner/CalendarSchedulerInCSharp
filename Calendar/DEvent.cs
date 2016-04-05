using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar
{
    public class DEvent:IComparable<DEvent>
    {
        private string name;
        private DateTime time;
        private string notes;

        public DEvent(String name, DateTime time, String notes)
        {
            this.name = name;
            this.time = time;
            this.notes = notes;
        }

        public void setName(String name)
        {
            this.name = name;
        }

        public void setTime(DateTime time)
        {
            this.time = time;
        }

        public void setNotes(String notes)
        {
            this.notes = notes;
        }

        public string getName()
        {
            return this.name;
        }

        public DateTime getTime()
        {
            return this.time;
        }

        public string getNotes()
        {
            return this.notes;
        }

        public int CompareTo(DEvent other)
        {
            return time.CompareTo(other.time);
        }
    }
}
