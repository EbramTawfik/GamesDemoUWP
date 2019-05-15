using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GamesDemo.Infrastructure.Helpers;
using GamesDemo.Infrastructure.Services;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GamesDemo.Infrastructure.ViewModels
{
	public class GamesViewModel : ViewModelBase
	{

		#region Fields
		private ObservableCollection<GameViewModel> _gamesList;
		private GameViewModel _selectedGame;
		private ICommand _getGamesCommand;
		private ICommand _nextDayCommand;
		private ICommand _previousDayCommand;
		private bool _isbusy;
		private int _selectedDay = 20;
		#endregion

		#region Properties

		public ObservableCollection<GameViewModel> GamesList
		{
			get
			{
				if (_gamesList == null)
				{
					_gamesList = new ObservableCollection<GameViewModel>();
				}
				return _gamesList;
			}
			set
			{
				_gamesList = value;
				RaisePropertyChanged(() => GamesList);
			}
		}

		public GameViewModel SelectedGame
		{
			get
			{
				return _selectedGame;
			}
			set
			{
				_selectedGame = value;
				clearSelectedItemFlag();
				_selectedGame.IsGameSelected = true;
				RaisePropertyChanged(() => SelectedGame);
			}
		}

		public ICommand GetGamesCommand
		{
			get
			{
				return _getGamesCommand ?? (_getGamesCommand = new RelayCommand(async () => await GetGames()));
			}
		}

		public ICommand NextDayCommand
		{
			get
			{
				return _nextDayCommand ?? (_nextDayCommand = new RelayCommand(async () =>
				{
					_selectedDay++;
					await GetGames();
				}));
			}
		}

		public ICommand PreviousDayCommand
		{
			get
			{
				return _previousDayCommand ?? (_previousDayCommand = new RelayCommand(async () =>
				{
					_selectedDay--;
					await GetGames();
				}));
			}
		}


		public bool IsBusy
		{
			get { return _isbusy; }
			set
			{
				_isbusy = value;
				RaisePropertyChanged(() => IsBusy);
			}
		}
		#endregion



		#region Methods

		public async Task GetGames()
		{
			try
			{
				if (IsBusy)
				{
					return;
				}
				IsBusy = true;
				var gamesService = new GamesService();

				var games = await gamesService.GetGamesAsync(Constants.GetGamesUri(_selectedDay));
				GamesList.Clear();
				foreach (var game in games)
				{
					GamesList.Add(new GameViewModel() { GameModel = game });
				}
				int sI = GamesList.Count / 2;
				SelectedGame = GamesList[sI];

			}
			catch (Exception ex)
			{
				Debug.WriteLine("Error : " + ex.Message);
			}
			finally
			{
				IsBusy = false;
			}
		}

		private void clearSelectedItemFlag()
		{
			foreach (var g in GamesList)
			{
				g.IsGameSelected = false;
			}
		}

		#endregion
	}
}
