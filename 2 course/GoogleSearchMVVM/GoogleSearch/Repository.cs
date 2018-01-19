using GoogleSearch.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GoogleSearch
{
	class Repository
	{
		private string _engineId = "";
		private string _appKey = "";
		
		public async Task<List<SearchResult>> GetResults(string query)
		{
			using (var client = new HttpClient())
			{
				var result = await client.GetStringAsync($"https://www.googleapis.com/customsearch/v1?q={query}&cx={_engineId}&key={_appKey}");
				var data = JsonConvert.DeserializeObject<Result>(result);

				// Convertion from DTO to Domain Model
				return data.Items.Select(item => new SearchResult
				{
					Title = item.Title,
					Description = item.Snippet,
					Url = item.Link
				}).ToList();
			}
		}
	}
}
