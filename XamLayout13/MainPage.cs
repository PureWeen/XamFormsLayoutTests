using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace XamLayout13
{
    public class MainPage : ContentPage
    {
        Label theLabel;
        public MainPage()
        {
            Button clickMe = new Button()
            {
                Text = "Click Me"                
            };

            theLabel = new Label
            {
                XAlign = TextAlignment.Center,
                Text = "Welcome to Xamarin Forms!"
            };


            clickMe.Clicked += ClickMe_Clicked;
            Content = new LayoutHost
            {
                VerticalOptions = LayoutOptions.Center,
                Children = {
                        theLabel,
                        clickMe
                    }
            };
        }

        private void ClickMe_Clicked(object sender, EventArgs e)
        {
            theLabel.Text += "x";
        }

        protected override void LayoutChildren(double x, double y, double width, double height)
        {
            base.LayoutChildren(x, y, width, height);
            Debug.WriteLine("Layout Changed");
        }
    }
}
