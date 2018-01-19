using System;
using System.Collections.Generic;

namespace PersonalScheduler
{
	public enum NotificationType
	{
		Email,
		Sound,
		Visual
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
            private set { _place= value; }
        }

        private List<NotificationType> _notifications;

        public List<NotificationType> Notifications
        {
            get { return _notifications; }
            private set
            {
                if (value.Count == 0)
                    throw new ArgumentException("You should choose at least one type of notification");
                else
                    _notifications = value;
            }
        }

        private string _email;

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        private string _password;

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        private string _senderEmail;

        public string SenderEmail
        {
            get { return _senderEmail; }
            set { _senderEmail = value; }
        }
        
        public ScheduledEvent(string name, DateTime datetime, 
                              string descripton, string place, List<NotificationType> notifications,string email,string password, string senderemail)
        {
            Name = name;
            DateTime = datetime;
            Description = descripton;
            Place = place;
            Notifications = notifications;
            Email = email;
            Password = password;
            SenderEmail = senderemail;
        }

    }

    public class RegularEvent : ScheduledEvent
    {

        private TimeSpan _repeatInterval;

        public TimeSpan RepeatInterval
        {
            get { return _repeatInterval; }
            set
            {
                _repeatInterval = value;
            }
        }

        public RegularEvent(string name, DateTime datetime,
                              string descripton, string place, List<NotificationType> notifications,string email, string password, string senderemail,TimeSpan repeatInterval) : base(name, datetime,
                              descripton, place, notifications,email,password,senderemail)
        { 
            if (notifications.Contains(NotificationType.Email))
            {
                TimeSpan ts = new TimeSpan(0, 0, 5,0);
                var a = notifications.Find(item => item == NotificationType.Email);
                if (repeatInterval <= ts)
                {
                   throw new ArgumentException("This email messages may be treated as spam");
                }
            }
            RepeatInterval = repeatInterval;
        }
    }
}
