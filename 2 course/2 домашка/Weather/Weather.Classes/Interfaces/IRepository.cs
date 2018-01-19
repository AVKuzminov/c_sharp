using System;
using System.Collections.Generic;

namespace Weather.Classes.Interfaces
{
	public interface IRepository<T>
	{
		IEnumerable<T> Items { get; }

		void AddItem(T item);
		void RemoveItem(T item);

		T Find(Predicate<T> predicate);

		event Action<T> ItemAdded;
	}
}
