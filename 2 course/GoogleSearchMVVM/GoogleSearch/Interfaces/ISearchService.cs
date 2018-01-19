using System.Collections.Generic;
using System.Threading.Tasks;

namespace GoogleSearch.Interfaces
{
	public interface ISearchService
	{
		Task<List<SearchResult>> GetResultsAsync(string query);
	}
}
