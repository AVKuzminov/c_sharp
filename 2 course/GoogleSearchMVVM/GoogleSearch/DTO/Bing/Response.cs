using Newtonsoft.Json;

namespace GoogleSearch.DTO.Bing
{
	class Response
	{
		[JsonProperty("webPages")]
		public WebPageInfo PageInfo { get; set; }
	}
}
