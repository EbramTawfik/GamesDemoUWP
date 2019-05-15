using Newtonsoft.Json;
using System.Collections.Generic;

namespace GamesDemo.Infrastructure.Model
{
	public class API_Response
	{

		[JsonProperty("data")]
		public Data Data { get; set; }
	}

	public class Data
	{
		[JsonProperty("games")]
		public Games Games { get; set; }
	}

	public class Games
	{
		[JsonProperty("game")]
		public List<Game> Game { get; set; }
	}

	public class Game
	{
		[JsonProperty("location")]
		public string Location { get; set; }

		[JsonProperty("away_time")]
		public string AwayTime { get; set; }

		[JsonProperty("home_time")]
		public string HomeTime { get; set; }


		[JsonProperty("home_team_city")]
		public string HomeTeamCity { get; set; }

		[JsonProperty("away_team_city")]
		public string AwayTeamCity { get; set; }


		[JsonProperty("video_thumbnails")]
		public VideoThumbnails VideoThumbnails { get; set; }
	}

	public class VideoThumbnails
	{
		[JsonProperty("thumbnail")]
		public List<Thumbnail> Thumbnail { get; set; }

	}


	public class Thumbnail
	{
		[JsonProperty("content")]
		public string Content { get; set; }

		[JsonProperty("scenario")]
		public string scenario { get; set; }

		[JsonProperty("height")]
		public string Height { get; set; }

		[JsonProperty("width")]
		public string Width { get; set; }
	}
}
