using System;
using System.Collections.Generic;

namespace Repository {
	public class EmployeeRepository
    {
        List<Employee> _data = new List<Employee>();

		public event Action<Employee> OnEmployeeAdded;
		public event Action<Employee> OnEmployeeRemoved;

		public event Action<string> OnLog;

        public void Add(Employee e)
        {
            if (!e.IsValid())
                throw new ArgumentException("Item is not valid");

			_data.Add(e);

			// Old syntax
			if (OnEmployeeAdded != null)
				OnEmployeeAdded(e);

			// New C# 6.0 syntax
			OnLog?.Invoke(e.Name + " added");
        }

        public void Remove(Employee e)
        {
            _data.Remove(e);

			OnEmployeeRemoved?.Invoke(e);
			OnLog?.Invoke(e.Name + " removed");
		}
    }
}
