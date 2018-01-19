using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleChat
{
    public class ChatManager
    {
        List<User> _activeUsers = new List<User>();
        
        public void AddUser(User user)
        {
            if (_activeUsers.Contains(user))
                return;

            // YOUR CODE GOES HERE (Add connections)

            _activeUsers.Add(user);
        }

        public void RemoveUser(User user)
        {
            if (!_activeUsers.Contains(user))
                return;

            // YOUR CODE GOES HERE (Delete connections)

            _activeUsers.Remove(user);
        }
    }
}
