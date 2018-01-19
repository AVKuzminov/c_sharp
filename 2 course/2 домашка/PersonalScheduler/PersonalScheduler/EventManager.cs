using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalScheduler
{
    public class EventManager
	{
        private List<ScheduledEvent> _listOfScheduledEvents = new List<ScheduledEvent>();

        public event Action<ScheduledEvent, int> Add;
        public event Action<ScheduledEvent> Remove;

        private void NotifyTime(ScheduledEvent item)
        {
            //не ссылается на нотифаеров - им фабрику можно

            //var a = Factory.Default.GetNotificatonType<EmailNotification>();

            if (item.Notifications.Contains(NotificationType.Email))
            {
                Notifiers.EmailNotifier en = new Notifiers.EmailNotifier();
                en.Notify(item);
            }
            if (item.Notifications.Contains(NotificationType.Sound))
            {
                Notifiers.SoundNotifier sn = new Notifiers.SoundNotifier();
                sn.Notify(item);
            }
            if (item.Notifications.Contains(NotificationType.Visual))
            {
                Notifiers.VisualNotifier vn = new Notifiers.VisualNotifier();
                vn.Notify(item);
            }
        }

		public void ProcessEvents()
		{
            List<ScheduledEvent> addinglist = new List<ScheduledEvent>();
            List<ScheduledEvent> removinglist = new List<ScheduledEvent>();
            foreach (var i in _listOfScheduledEvents)
            {
                if (i.DateTime <= DateTime.Now)
                {
                    NotifyTime(i);
                    if (i is RegularEvent)
                    {
                        RegularEvent o = (RegularEvent)i;
                        RegularEvent newi = new RegularEvent(o.Name, o.DateTime.Add(o.RepeatInterval), 
                            o.Description, o.Place, o.Notifications,o.Email,o.Password,o.SenderEmail, o.RepeatInterval);
                        addinglist.Add(newi);
                    }
                    removinglist.Add(i);
                }
            }
            foreach (var i in removinglist)
            {
                RemoveEvent(i);
            }
            foreach (var i in addinglist)
            {
                AddEvent(i);
            }
            addinglist.Clear();
            removinglist.Clear();
		}

		public void AddEvent(ScheduledEvent ev)
		{
            foreach (ScheduledEvent item in _listOfScheduledEvents)
            {
                if (item.Name == ev.Name)
                    throw new ArgumentException("You cannot set two different events with the same date(time)");
            }
            int _numberinlist = 0;
            foreach (ScheduledEvent item in _listOfScheduledEvents)
            {
                if (ev.DateTime <= item.DateTime)
                    _numberinlist = _listOfScheduledEvents.IndexOf(item);
            }
            _listOfScheduledEvents.Insert(_numberinlist, ev);
            Add?.Invoke(ev,_numberinlist);
		}

		public void RemoveEvent(ScheduledEvent ev)
		{
            _listOfScheduledEvents.Remove(ev);
            Remove?.Invoke(ev);
		}
	}
}
