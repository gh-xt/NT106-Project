using System;
using System.Collections.Generic;

namespace Werewolf.Network.Events
{
    public class EventManager : EventManager<EventArgs> { }

    public class EventManager<TBaseEventArgs> where TBaseEventArgs : EventArgs
    {
        private readonly Dictionary<Type, Event> _events;

        public EventManager()
        {
            _events = new Dictionary<Type, Event>();
        }

        private Event<TEventArgs> GetEvent<TEventArgs>() where TEventArgs : TBaseEventArgs
        {
            Type type = typeof(TEventArgs);

            if (!_events.ContainsKey(type))
                _events.Add(type, new Event<TEventArgs>());

            return (Event<TEventArgs>)_events[type];
        }

        public void Add_Listener<TEventArgs>(EventHandler<TEventArgs> listener) where TEventArgs : TBaseEventArgs
        {
            GetEvent<TEventArgs>().Add_Listener(listener);
        }

        public void Raise_Event<TEventArgs>(TEventArgs e) where TEventArgs : TBaseEventArgs
        {
            GetEvent<TEventArgs>().Raise_Event(e);
        }

        public void Raise_Event<TEventArgs>(object sender, TEventArgs e) where TEventArgs : TBaseEventArgs
        {
            GetEvent<TEventArgs>().Raise_Event(sender, e);
        }
    }
}
