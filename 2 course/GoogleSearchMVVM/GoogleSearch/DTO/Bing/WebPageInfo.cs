using Newtonsoft.Json;

namespace GoogleSearch.DTO.Bing
{
	public class WebPageInfo
	{
		[JsonProperty("value")]
		public Item[] Items { get; set; }
	}
}