using GalaSoft.MvvmLight;
using GamesDemo.Infrastructure.Model;

namespace GamesDemo.Infrastructure.ViewModels
{
	public class GameViewModel : ViewModelBase
	{
		#region Properties

		private Game _gameModel;
		public Game GameModel
		{
			get { return _gameModel; }
			set
			{
				_gameModel = value;
				RaisePropertyChanged(() => GameModel);
			}
		}

		private bool _isGameSelected;
		public bool IsGameSelected
		{
			get { return _isGameSelected; }
			set
			{
				_isGameSelected = value;
				RaisePropertyChanged(() => IsGameSelected);
			}
		}
		#endregion
	}
}
