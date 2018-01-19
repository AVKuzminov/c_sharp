using GoogleSearch.DTO.Bing;
using GoogleSearch.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace GoogleSearch
{
	class BingService : ISearchService
	{
		private string _subscriptionKey = "";
		
		public async Task<List<SearchResult>> GetResultsAsync(string query)
		{
			using (var client = new HttpClient())
			{
				client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", _subscriptionKey);

				var result = await client.GetStringAsync($"https://api.cognitive.microsoft.com/bing/v5.0/search?q={query}");
				var data = JsonConvert.DeserializeObject<Response>(result);

				// Convertion from DTO to Domain Model
				return data.PageInfo.Items.Select(item => new SearchResult
				{
					Title = item.Name,
					Description = item.Snippet,
					Url = item.Url
				}).ToList();
			}
		}
	}
}
