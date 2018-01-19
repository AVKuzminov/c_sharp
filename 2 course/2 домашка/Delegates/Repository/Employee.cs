using System;

namespace Repository
{
	public class Employee
    {
        public string Name { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Department { get; set; }

        public bool IsValid()
        {
            return !string.IsNullOrWhiteSpace(Name) && BirthDate != null && !string.IsNullOrWhiteSpace(Department);
        }
    }
}
