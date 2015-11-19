using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace CreatingAsyncController.Controllers
{
	public class NewsController 
		: ApiController
	{
		public async Task<HttpResponseMessage> Get(int storyId)
		{
			var topStoriesTask = new HttpClient().GetAsync(
				"http://api.madeupstories.com");
			var storyTask = new HttpClient().GetAsync(
				$"http://api.madeupstories.com/{storyId}");

			await Task.WhenAll(topStoriesTask, storyTask);

			var topStoriesResponse = topStoriesTask.Result;
			var storyResponse = storyTask.Result;

			var response = new HttpResponseMessage();
			// Fill in response here...

			return response;
		}
	}
}
