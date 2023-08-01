using System.Drawing;
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
        private void MyScrollView_Scrolled(object sender, ScrolledEventArgs e)
        {
            ScrollView scrollView = (ScrollView)sender;

            Xamarin.Forms.Point point = scrollView.GetScrollPositionForElement(scrollView, ScrollToPosition.Start);

            double deviceViewWidth = MainPage.Constant.ScreenWidth;

            if (scrollView.ScrollX == 0)
                return;

            if (previousOffset >= scrollView.ScrollX)
            {
                // scroll left the width of a two child elements

                // Take 1
                // This scroll speed is fast. keeps up with content.
                //await scrollView.ScrollToAsync(mx - (ScreenWidth / 2), my, false);

                // Take 2
                // Trying again, I realize that if I only used the RelativeScrollX or ScrollX values,
                // the views translate as keeping pace with the content. I want them to scroll a little slower
                var animation = new Animation(
                    callback: x => scrollView.ScrollToAsync(x - (deviceViewWidth / 2), point.Y, animated: false),
                    start: scrollView.ScrollX,
                    end: point.X - (deviceViewWidth / 2));

                animation.Commit(
                    owner: scrollView,
                    name: "Scroll",
                    length: 10000,
                    easing: Easing.CubicIn);
            }
            else
            {
                // scroll right the width of a two child elements
                //await scrollView.ScrollToAsync(mx + (ScreenWidth / 2), my, false);

                var animation = new Animation(
                    callback: x => scrollView.ScrollToAsync(x + (deviceViewWidth / 2), point.Y, animated: false),
                    start: scrollView.ScrollX,
                    end: point.X + (deviceViewWidth / 2));

                animation.Commit(
                    owner: scrollView,
                    name: "Scroll",
                    length: 10000,
                    easing: Easing.CubicIn);
            }

            // hang onto val
            previousOffset = scrollView.ScrollX;
        }
    }
}

