using System;
using System.Text.RegularExpressions;

namespace Phonebook.Console
{
    public delegate void PhoneChangeDelegate(string i, string j);

    public class Contact
    {        
        public event PhoneChangeDelegate PhoneChangeEvent;

        private string firstname;

        public string FirstName
        {
            get { return firstname; }
            set {
                if ((value == null) || (value == ""))
                    throw new ArgumentException("Wrong 'firstname' field format");
                else
                    firstname = value; }
        }

        private string lastname;

        public string LastName
        {
            get { return lastname; }
            set {
                if ((value == null) || (value == ""))
                    throw new ArgumentException("Wrong 'lastname' field format");
                else
                    lastname = value; }
        }

        private DateTime birthdate;

        public DateTime BirthDate
        {
            get { return birthdate; }
            set {DateTime date = new DateTime(1900, 01, 01);
                if ((value <= date) || (value == null))
                    throw new ArgumentException("Wrong 'birthdate' field format, this person must be dead now");
                else
                    birthdate = value; }
        }
        private string phone;

        public string Phone
        {
            get { return phone; }
            set
            {
                PhoneChangeEvent?.Invoke(value, phone);
                if (value == null)
                    phone = value;
                else
                {
                    foreach (char symbol in value)
                        if ((Char.IsLetter(symbol)) || (symbol == '-'))
                            throw new ArgumentException("Wrong 'phone' field format");
                    if (!(value[0] == '+') || (value.Length <= 4) || (value.Length >= 15))
                        throw new ArgumentException("Wrong 'phone' field format");
                    else
                        phone = value;                   
                }
                
            }
        }

        public bool ValidEmail(string inputemail)
        {          
            string regular_expression = "[.\\-_a-z0-9]+@([a-z0-9][\\-a-z0-9]+\\.)+[a-z]{2,6}";
            Match matcher;
            matcher = Regex.Match(inputemail, regular_expression, RegexOptions.IgnoreCase);
            return matcher.Success;
        }


        private string email;

        public string Email
        {
            get { return email; }
            set {
                if (value == null)
                    email = value;
                else
                   if (value == "" || !(ValidEmail(value)))
                       throw new ArgumentException("Wrong 'email' field format");
                    else
                        email = value.ToLower(); }
        }

        public Contact(string firstname, string lastname, DateTime birthdate, string phone, string email)
        {
            FirstName = firstname;
            LastName = lastname;
            BirthDate = birthdate;
            Phone = phone;
            Email = email;     
        }

        public Contact(string firstname, string lastname, DateTime birthdate)
        {
            FirstName = firstname;
            LastName = lastname;
            BirthDate = birthdate;
            Phone = null;
            Email = null;
        }
    }
}
