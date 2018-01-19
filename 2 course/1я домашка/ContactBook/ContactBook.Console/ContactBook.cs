using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Phonebook.Console
{

    public class ContactBook
    {      
        public void PhoneChangeMethod(string newone,string oldone)
        {
            if (newone != oldone)
                if (newone != null)
                    if (oldone == null) //null => value
                    {
                        AllContacts.Find(Contact => Contact.Phone == oldone).Phone = newone;
                        phonesearch[newone] = AllContacts.Find(Contact => Contact.Phone == newone);
                    }
                    else //value1=>value2
                    {                       
                        phonesearch.Add(newone, AllContacts.Find(Contact => Contact.Phone == oldone));
                        phonesearch.Remove(oldone);
                    }
                else //value => null
                {
                    phonesearch.Remove(oldone);
                    AllContacts.Find(Contact => Contact.Phone == oldone).Phone = null;
                }
        }


        private List<Contact> allcontacts = new List<Contact>(); 

        public List<Contact> AllContacts
        {
            get { return allcontacts; }
        }

        private Dictionary<string, Contact> phonesearch = new Dictionary<string, Contact>();

        List<Contact> return_list = new List<Contact>();

        public void AddContact(Contact contact)
        {
            foreach (var item in AllContacts)
            {
                if (phonesearch.ContainsKey(contact.Phone))
                    if (item.Email == contact.Email)
                        throw new ArgumentException("This email already exists in the database");
                else
                    throw new ArgumentException("This phone already exists in the database");
            }
            AllContacts.Add(contact);
            if (!(contact.Phone == null))
            {
                phonesearch[contact.Phone] = contact;
            }

            contact.PhoneChangeEvent += PhoneChangeMethod;
            // Check that phone number and email are unique when provided
        }

        public List<Contact> SearchByName(string expression)
        {
            return_list.Clear();
            expression = expression.ToLower();
            foreach (var item in AllContacts)
            {
                if ((item.FirstName.ToLower() == expression) || (item.LastName.ToLower() == expression) || ((item.FirstName.ToLower() + " " + item.LastName.ToLower()) == expression) || ((item.LastName.ToLower() + " " + item.FirstName.ToLower()) == expression))
                {
                    return_list.Add(item);
                }
            }
            return return_list;
        }

        public Contact SearchByEmail(string email)
        {
            Contact return_one = null;
            foreach (var item in AllContacts)
            {
                if (item.Email == email)
                {
                    return item;
                }
            }
            return return_one;
        }

        public Contact SearchByPhone(string phone)
        {
            Contact return_one = null;
            foreach (var item in AllContacts)
            {
                if (phonesearch.ContainsKey(phone))
                {
                    return phonesearch[phone];
                }
            }
            return return_one;
        }

        public void RemoveAll(Predicate<Contact> predicate)
        {
            List<Contact> list = AllContacts.FindAll(predicate);
            foreach (Contact item in list)
            {
                if (item.Phone != null)
                    phonesearch.Remove(item.Phone);
                item.PhoneChangeEvent -= PhoneChangeMethod;                
                AllContacts.Remove(item);
            }
        }
    }
}
