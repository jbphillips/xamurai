using Xamarin.Forms;

namespace Xamurai
{
	public class ScrollViewBehavior : Behavior<ScrollView>
	{
        double previousOffset;

        protected override void OnAttachedTo(ScrollView myScrollView)
        {
            myScrollView.Scrolled += MyScrollView_Scrolled;

            base.OnAttachedTo(myScrollView);
        }

        private async void MyScrollView_Scrolled(object sender, ScrolledEventArgs e)
        {
            ScrollView scrollView = (ScrollView)sender;

            var x = scrollView.ScrollX;
            var y = scrollView.ScrollY;

            if (e.ScrollX == 0)
                return;

            if (previousOffset >= e.ScrollX)
            {
                // left direction  
                await scrollView.ScrollToAsync(x - 180, y, false);
            }
            else
            {
                //Down direction 
                await scrollView.ScrollToAsync(x + 180, y, false);
            }

            previousOffset = e.ScrollX;
        }
    }
}

