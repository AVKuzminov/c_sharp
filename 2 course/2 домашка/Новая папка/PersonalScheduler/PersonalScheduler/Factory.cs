using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalScheduler.Notifiers;

namespace PersonalScheduler
{
    public class Notification<T> where T : INotifier 
    {

    }

    public class EmailNotification : Notification<EmailNotifier>
    {
        public EmailNotification()
        {

        }
    }

    public class SoundNotification : Notification<SoundNotifier>
    {
        public SoundNotification()
        {

        }
    }
    public class VisualNotification : Notification<VisualNotifier>
    {
        public VisualNotification()
        {
            
        }
    }

    public class Factory
    {
        private Factory() { }

        static Factory _default;

        public static Factory Default
        {
            get
            {
                if (_default == null)
                    _default = new Factory();
                return _default;
            }
        }
        EmailNotifier _emailnotifier = new EmailNotifier();
        SoundNotifier _soundnotifier = new SoundNotifier();
        VisualNotifier _visualnotifier = new VisualNotifier();

        public INotifier GetNotificatonType<T>()
        {
            if (typeof(T) == typeof(Notifiers.SoundNotifier))
                return (INotifier)_soundnotifier;
            if (typeof(T) == typeof(Notifiers.EmailNotifier))
                return (INotifier)_emailnotifier;
            else
                return (INotifier)_visualnotifier;
        }
    }
}
