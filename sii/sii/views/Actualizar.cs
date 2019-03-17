using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using sii.ws;

namespace sii.views
{
    class Actualizar : ContentPage
    {
        private Entry txtemail, txttelefono,txtdireccion;
        private Button btnEnviar;
        private StackLayout stk;


        public Actualizar()
        {
            Title = "Actualizar Datos";

            txtemail = new Entry()
            {
                Placeholder="email",
                PlaceholderColor=Color.Gray,
                HorizontalTextAlignment = TextAlignment.Center,
                Text =Settings.Settings.email,
                TextColor = Color.Black,
                HorizontalOptions = LayoutOptions.Center,
                WidthRequest = 400,
                Keyboard=Keyboard.Email

            };
            txttelefono = new Entry()
            {
                Placeholder = "telefono",
                PlaceholderColor = Color.Gray,
                HorizontalTextAlignment = TextAlignment.Center,
                Text = Settings.Settings.telefono,
                TextColor = Color.Black,
                HorizontalOptions = LayoutOptions.Center,
                WidthRequest = 400,
                Keyboard=Keyboard.Telephone
                

            };
            txtdireccion = new Entry()
            {
                Placeholder = "direccion",
                PlaceholderColor = Color.Gray,
                HorizontalTextAlignment = TextAlignment.Center,
                Text = Settings.Settings.direccion,
                TextColor = Color.Black,
                HorizontalOptions = LayoutOptions.Center,
                WidthRequest = 400

            };
            btnEnviar = new Button()
            {
                Text = "Aceptar",
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

                    txtemail,
                    txttelefono,
                    txtdireccion,
                    btnEnviar,
                   }
            };
            Content = stk;

        }
        private async void Btn_Cliked(object sender, EventArgs e)
        {
            

            wsAlumno objAlumno = new wsAlumno();
            try
            {
                bool resultado = await objAlumno.putAlumno(txttelefono.Text, txtdireccion.Text,txtemail.Text);
                if (resultado)
                {


                    await DisplayAlert("Exito", "Datos Actualizados", "Aceptar");
                    await Navigation.PushModalAsync(new SplashPage());

                }
            }
            catch (Exception) { await DisplayAlert("Error", "Al Envio no Exitoso", "Aceptar"); }

        }
    }
}
