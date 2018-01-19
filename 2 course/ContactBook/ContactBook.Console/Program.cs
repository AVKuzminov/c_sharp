using System;
using static System.Console;

namespace Phonebook.Console
{
	class Program
	{
		static void Main(string[] args)
		{
			
			// **** BLOCK 1 ****
			var c1 = new Contact("Andrew", "Higgins", new DateTime(1980, 01, 23));
			var c2 = new Contact("Emily", "Watson", new DateTime(1992, 02, 10), "+441341235", "ewatson@gmail.com");
			var c3 = new Contact("Jack", "Simpkins", new DateTime(1983, 07, 12), "+441341235", "simpkins@yahoo.com");
			var c4 = new Contact("John", "Thompson", new DateTime(1984, 06, 11), "+4479132421", "jthompson@hotmail.com");
			var c5 = new Contact("Emily", "McFarell", new DateTime(1974, 06, 11), "+444321232", null);

			// Check that properties are accessible
			WriteLine("{0} {1} {2} {3} {4}", c2.FirstName, c2.LastName, c2.BirthDate.ToShortDateString(),
				c2.Phone, c2.Email);

			// the following should result in an ArgumentException, comment out after verifying
			//var cIncorrect = new Contact("", "", new DateTime());
			
			// ***** END OF BLOCK 1*****
			


			
			// **** BLOCK 2 ****
			var contactBook = new ContactBook();
			contactBook.AddContact(c1);
			contactBook.AddContact(c2);
			contactBook.AddContact(c4);
			contactBook.AddContact(c5);

			// The following should result in an argument exception (same phone number)
			// comment out after verifying
			//contactBook.AddContact(c3);

			var contacts = contactBook.AllContacts;
			// ***** END OF BLOCK 2*****
			


			
			// **** BLOCK 3 ****

			// Should return a list containing Emily Watson and Emily McFarell
			var cSearchList = contactBook.SearchByName("emily");
			// Should return an empty list, not null!
			cSearchList = contactBook.SearchByName("Andy");
			

			// The following line should return John Thompson
			var cSearch = contactBook.SearchByPhone("+4479132421");
			cSearch.Phone = "+712334234";

			// before adding events the following line should return null
			// after adding events it should return the same contact
			cSearch = contactBook.SearchByPhone("+712334234");

			// The following should throw an exception, comment out after verifying
			//с2.Phone = "+712334234";
			// ***** END OF BLOCK 3*****
			




			
			// **** BLOCK 4 ****
			contactBook.RemoveAll(c => c.FirstName == "Emily");
			// The following should NOT throw an exception
			c2.Phone = "+712334234";
            // ***** END OF BLOCK 4*****

        }
	}
}
