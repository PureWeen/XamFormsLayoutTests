using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamLayout13
{
    public class LayoutHost : Layout<View>
    {
        protected override bool ShouldInvalidateOnChildAdded(View child)
        {
            return false; // stop pestering me
        }

        protected override bool ShouldInvalidateOnChildRemoved(View child)
        {
            return false; // go away and leave me alone
        }

        protected override void OnChildMeasureInvalidated()
        {
            // I'm ignoring you.  You'll take whatever size I want to give
            // you.  And you'll like it.
        }


        Rectangle theRectangle;
        protected override void LayoutChildren(double x, double y, double width, double height)
        {
            theRectangle = new Rectangle(x, y, width, height);
            LayoutTheThings();
        }

        void LayoutTheThings()
        {
            var theWidth = theRectangle.Width / Children.Count();
            var theX = theRectangle.X;

            foreach (View v in Children)
            {
                Rectangle r = new Rectangle(theX, theRectangle.Y, theWidth, theRectangle.Height);
                v.Layout(r);

                theX += theWidth;
            }
        }
    }
}
