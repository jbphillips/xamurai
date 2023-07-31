using Prism.Commands;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Xamurai
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			OpenListViewCommand = new DelegateCommand(OpenListView);
			OpenCollectionViewCommand = new DelegateCommand(OpenCollectionView);
			OpenCarouselViewCommand = new DelegateCommand(OpenCarouselView);
			OpenFlexLayoutViewCommand = new DelegateCommand(OpenFlexLayoutView);
			OpenPagedCollectionViewCommand = new DelegateCommand(OpenPagedCollectionView);

			BindingContext = this;
			InitializeComponent();

            // Get Metrics
            var mainDisplayInfo = DeviceDisplay.MainDisplayInfo;

            // Width (in pixels)
            var width = mainDisplayInfo.Width;

            // Height (in pixels)
            var height = mainDisplayInfo.Height;
        }

        public struct Constant
        {
            public static double ScreenWidth = (DeviceDisplay.MainDisplayInfo.Width / DeviceDisplay.MainDisplayInfo.Density) / 2;
            public static double ScreenHeight = DeviceDisplay.MainDisplayInfo.Height / DeviceDisplay.MainDisplayInfo.Density;
        }

        public ICommand OpenListViewCommand { get; }

		public ICommand OpenCollectionViewCommand { get; }

		public ICommand OpenCarouselViewCommand { get; }

		public ICommand OpenPagedCollectionViewCommand { get; }

		public ICommand OpenFlexLayoutViewCommand { get; }

		private void OpenListView()
		{
			Navigation.PushAsync(new ListViewPage());
		}

		private void OpenCollectionView()
		{
			Navigation.PushAsync(new CollectionViewPage());
		}

		private void OpenCarouselView()
		{
			Navigation.PushAsync(new CarouselViewPage());
		}

		private void OpenFlexLayoutView()
		{
			Navigation.PushAsync(new FlexLayoutPage());
		}

		private void OpenPagedCollectionView()
		{
			Navigation.PushAsync(new PagedCollectionPage());
		}


	}
}
