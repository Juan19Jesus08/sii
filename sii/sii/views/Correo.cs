using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using sii.ws;

namespace sii.views
{
    class Correo : ContentPage
    {
        private Entry txtCorreo, txtContenido,txtAsunto;
        private Button btnEnviar;
        private StackLayout stk;


        public Correo()
        {
            Title = "Correo";

           
            txtAsunto = new Entry()
            {
                Placeholder = "Asunto",
                PlaceholderColor = Color.Black,
                HorizontalTextAlignment = TextAlignment.Center,
                TextColor = Color.Black,
                HorizontalOptions = LayoutOptions.Center,
                WidthRequest = 400

            };
            txtContenido = new Entry()
            {
                Placeholder ="Mensaje",
                HorizontalTextAlignment = TextAlignment.Center,
                TextColor = Color.Black,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                WidthRequest = 400,
                HeightRequest = 200

            };
            btnEnviar = new Button()
            {
                Text = "Enviar Correo",
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

                  
                    txtAsunto,
                    txtContenido,
                    btnEnviar,
                   }
            };
            Content = stk;

        }
        private async void Btn_Cliked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtAsunto.Text))
            {
                await DisplayAlert("Error", "Debes Introducir el asunto", "Aceptar");
                txtAsunto.Focus();
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
                Services.ServicioCorreo.EnviarCorreo(Settings.Settings.correo, txtAsunto.Text, txtContenido.Text);
                //DisplayAlert("Correcto", "Correo Enviado Exitosamente", "Aceptar");
            }
            catch (Exception) { await DisplayAlert("Error", "Al Envio no Exitoso", "Aceptar"); }

        }
    }
}
