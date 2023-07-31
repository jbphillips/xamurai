using Xamarin.Forms;

namespace Xamurai
{
    /// <summary>
    /// Catch scrollView scrolled event. Do something cool
    /// </summary>
	public class ScrollViewBehavior : Behavior<ScrollView>
	{
        // hang onto the previous val
        double previousOffset;
        public double ScreenWidth { get; set; }

        // attach to my scrollview object
        protected override void OnAttachedTo(ScrollView myScrollView)
        {
            myScrollView.Scrolled += MyScrollView_Scrolled;

            base.OnAttachedTo(myScrollView);
        }

        /// <summary>
        /// Scrolled event. Handle child positions to show two columns on each swipe
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void MyScrollView_Scrolled(object sender, ScrolledEventArgs e)
        {
            ScrollView scrollView = (ScrollView)sender;

            ScreenWidth = MainPage.Constant.ScreenWidth;

            var x = scrollView.ScrollX;
            var y = scrollView.ScrollY;

            if (e.ScrollX == 0)
                return;

            if (previousOffset >= e.ScrollX)
            {
                // left direction
                // scroll left the width of a child element
                await scrollView.ScrollToAsync(x - (ScreenWidth / 2), y, false);
            }
            else
            {
                // right direction
                // scroll right the width of a child element
                await scrollView.ScrollToAsync(x + (ScreenWidth / 2), y, false);
            }

            // hang onto val
            previousOffset = e.ScrollX;
        }
    }
}

