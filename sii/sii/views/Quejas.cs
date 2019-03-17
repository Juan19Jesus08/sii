using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using sii.ws;

namespace sii.views
{
    class Quejas:ContentPage
    {
        private Entry txtQuejas, txtContenido;
        private Button btnEnviar;
        private StackLayout stk;
        

        public Quejas()
        {
            Title = "Quejas y Sugerencias";

            txtQuejas = new Entry()
            {
                Placeholder = "Queja, Sugerencia,Agradecimiento,Asesoria,Pregunta",
                PlaceholderColor = Color.Black,
                HorizontalTextAlignment = TextAlignment.Center,
                TextColor = Color.Black,
                HorizontalOptions = LayoutOptions.Center,
                WidthRequest = 400

            };
            txtContenido = new Entry()
            {
                HorizontalTextAlignment = TextAlignment.Center,
                TextColor = Color.Black,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                WidthRequest = 400,
                HeightRequest=200
                
            };
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

                    txtQuejas,
                    txtContenido,
                    btnEnviar,
                   } 
            };
            Content = stk;

        }
        private async void Btn_Cliked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtQuejas.Text))
            {
                await DisplayAlert("Error", "Debes introducir Asunto", "Aceptar");
                txtQuejas.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtContenido.Text))
            {
                await DisplayAlert("Error", "Debes de introducir el mensaje", "Aceptar");
                txtContenido.Focus();
                return;
            }

            wsQuejas objQueja = new wsQuejas();
            try
            {
                bool resultado = await objQueja.putSubjects(txtQuejas.Text, txtContenido.Text);
                if (resultado)
                {
                    
                   
                    await DisplayAlert("Exito", "Envio Exitoso", "Aceptar");
                   
                }
            }
            catch (Exception) { await DisplayAlert("Error", "Al Envio no Exitoso", "Aceptar"); }
            
        }
    }
}
