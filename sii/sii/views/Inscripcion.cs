using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using sii.ws;

namespace sii.views
{
    class Inscripcion : ContentPage
    {
       
        private Button btnEnviar;
        private StackLayout stk;


        public Inscripcion()
        {
            Title = "Inscripcions";

            btnEnviar = new Button()
            {
                Text = "Enviar",
                BackgroundColor = Color.FromHex("#008A17"),
                TextColor = Color.White

            };
            btnEnviar.Clicked += Btn_Cliked;
            stk = new StackLayout()
            {
                Orientation = StackOrientation.Vertical,
                HorizontalOptions = LayoutOptions.Center,
                Padding = new Thickness(0, 50, 0, 0),
                WidthRequest = 500,
                Children =
                {

                   
                    btnEnviar,
                   }
            };
            Content = stk;

        }
        private async void Btn_Cliked(object sender, EventArgs e)
        {
             

        }
    }
}
