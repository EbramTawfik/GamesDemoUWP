using GamesDemo.Infrastructure.Model;
using GamesDemo.Infrastructure.RestClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesDemo.Infrastructure.Services
{
	class GamesService
	{
		public async Task<List<Game>> GetGamesAsync(string uri)
		{
			RestClient<API_Response> restClient = new RestClient<API_Response>();
			var apiResponse = await restClient.GetAsync(uri);
			var gamesList = apiResponse?.Data?.Games?.Game;
			return gamesList;
		}
	}
}
