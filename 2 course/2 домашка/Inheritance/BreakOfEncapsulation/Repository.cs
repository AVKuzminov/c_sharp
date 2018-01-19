using System;

namespace BreakOfEncapsulation
{
	class Repository
	{
		public Repository()
		{
			LoadData();
		}

		public virtual void LoadData()
		{

		}
	}

	class FileRepository : Repository
	{
		private readonly string _fileName;

		public FileRepository(string fileName)
		{
			// We are calling the base class constructor first
			// which makes the call to LoadData, the _fileName is not yet set
			_fileName = fileName;
		}

		public override void LoadData()
		{
			Console.WriteLine(_fileName);
		}
	}

}
