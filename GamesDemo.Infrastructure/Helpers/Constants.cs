using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesDemo.Infrastructure.Helpers
{
	class Constants
	{
		public static string GetGamesUri(int day = 20)
		{
			string GamesUri = $"http://gdx.mlb.com/components/game/mlb/year_2016/month_05/day_{day}/master_scoreboard.json";
			return GamesUri;
		}

	}
}
