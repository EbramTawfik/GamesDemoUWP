using GamesDemo.Infrastructure.ViewModels;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace GamesDemo
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class MainPage : Page
	{
		GamesViewModel _viewModel;
		public MainPage()
		{


			this.InitializeComponent();
			if (_viewModel == null)
			{
				_viewModel = new GamesViewModel();
				_viewModel.GetGamesCommand.Execute(null);
				DataContext = _viewModel;
			}

		}

		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
			DetailContentPresenter.ContentTransitions.Clear();
			DetailContentPresenter.ContentTransitions.Add(new EntranceThemeTransition());
		}



	}
}
