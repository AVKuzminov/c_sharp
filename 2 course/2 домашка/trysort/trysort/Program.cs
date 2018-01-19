using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trysort
{


    class Program
    {
        static void Main(string[] args)
        {
            List<ScheduledEvent> _listOfScheduledEvents = new List<ScheduledEvent>();
            {
                DateTime date1 = new DateTime(2016,10,14);
                var c1 = new ScheduledEvent("Иголки1", date1, "игра", "441 комната");
                _listOfScheduledEvents.Add(c1);
                DateTime date2 = new DateTime(2016, 10, 13);
                var c2 = new ScheduledEvent("Иголки2", date2, "игра", "441 комната");
                _listOfScheduledEvents.Add(c2);
                DateTime date3 = new DateTime(2016, 10, 15);
                var c3 = new ScheduledEvent("Иголки3", date3, "игра", "441 комната");
                _listOfScheduledEvents.Add(c3);


                Console.WriteLine("Before Sort ");

                foreach (var item in _listOfScheduledEvents)
                {
                    Console.WriteLine("{0} {1}", item.Name, item.DateTime);
                }

                _listOfScheduledEvents.Sort(delegate (ScheduledEvent x, ScheduledEvent y)
                    {
                        return x.DateTime.CompareTo(y.DateTime);
                    }
                );

                Console.WriteLine("After Sort");

                foreach (var item in _listOfScheduledEvents)
                {
                    Console.WriteLine("{0} {1}",item.Name,item.DateTime);
                }
                Console.ReadLine();
            }
        }
    }

    public class ScheduledEvent
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            private set
            {
                if (value == null)
                    throw new ArgumentNullException("You cannot leave the NAME field blank");
                else
                    if (String.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("You cannot fill this field only with spaces");
                else
                    _name = value;
            }
        }
        private DateTime _datetime;

        public DateTime DateTime
        {
            get { return _datetime; }
            private set
            {
                if (value < DateTime.Now)
                    throw new ArgumentOutOfRangeException("You cannot set the dete earlier than now");
                else
                    _datetime = value;
            }
        }
        private string _description;

        public string Description
        {
            get { return _description; }
            private set { _description = value; }
        }
        private string _place;

        public string Place
        {
            get { return _place; }
            private set { _place = value; }
        }



        public ScheduledEvent(string name, DateTime datetime, string descripton, string place)
        {
            Name = name;
            DateTime = datetime;
            Description = descripton;
            Place = place;
        }
    }
}
