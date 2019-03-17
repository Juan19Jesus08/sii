using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace sii.views
{
    class DatosPersonales:ContentPage
    {
        private StackLayout stk,stk1,stk2,stk3;
        private Label lbtitulo;
        private Label lbnombre;
        private Image imgFoto,imginst;
        private Label lbcarrera, lbnocont, lbsexo,lbemail,lbtelefono,lbdireccion;
        private Label lbinstitucion;
        private Button btnActualizar;

        public DatosPersonales(string alumno)
        {
            crearGui();

        }

        private void crearGui()
        {
            Title = "Datos Personales";
            imgFoto = new Image
            {
                Source = "alumno_" + Settings.Settings.nocont + ".png",
                WidthRequest = 200,
                HeightRequest = 200,
                HorizontalOptions=LayoutOptions.CenterAndExpand,
                

            };
            lbnombre = new Label()
            {
                Text = Settings.Settings.nombre,
                FontSize = 15,
                TextColor = Color.Black,
                HorizontalOptions = LayoutOptions.Center,
                


            };
            lbtitulo = new Label()
            {
                Text = "Informacion Academica",
                FontSize = 30,
                TextColor = Color.Black,
                HorizontalOptions = LayoutOptions.Center,


            };
             lbcarrera = new Label()
             {
                 Text = "Especialidad: " + Settings.Settings.especialidad,
                 FontSize = 15,
                 TextColor = Color.Black,
                 HorizontalOptions = LayoutOptions.Start,


             };
            lbnocont = new Label()
            {
                Text = "Numero de control: " + Settings.Settings.nocont,
                FontSize = 15,
                TextColor = Color.Black,
                HorizontalOptions = LayoutOptions.Start,


            };
            lbemail = new Label()
            {
                Text = "Correo Electronico: " + Settings.Settings.email,
                FontSize = 15,
                TextColor = Color.Black,
                HorizontalOptions = LayoutOptions.Start,


            };
            lbsexo = new Label()
            {
                Text = "Sexo: "+ Settings.Settings.sexo,
                FontSize = 15,
                TextColor = Color.Black,
                HorizontalOptions = LayoutOptions.Start,


            };
            lbtelefono = new Label()
            {
                Text = "Telefono: " + Settings.Settings.telefono,
                FontSize = 15,
                TextColor = Color.Black,
                HorizontalOptions = LayoutOptions.Start,


            };
            lbdireccion = new Label()
            {
                Text = "Direccion: " + Settings.Settings.direccion,
                FontSize = 15,
                TextColor = Color.Black,
                HorizontalOptions = LayoutOptions.Start,


            };
            btnActualizar = new Button()
            {
                Text = "Actualizar Datos",
                HorizontalOptions = LayoutOptions.Center,
                BackgroundColor = Color.FromHex("#008A17"),
                TextColor = Color.White
            };
            btnActualizar.Clicked += Btn_Cliked;
            imginst = new Image
            {
                Source = "logo_itc.png",
                WidthRequest = 20,
                HeightRequest = 20,
                HorizontalOptions = LayoutOptions.CenterAndExpand,


            };
            lbinstitucion = new Label()
            {
                Text = "ITC | Instituto Tecnologico de celaya ",
                FontSize = 15,
                TextColor = Color.FromHex("#008A17"),
                HorizontalOptions = LayoutOptions.End,
            };
            stk3 = new StackLayout()
            {
                Orientation = StackOrientation.Vertical,
                HorizontalOptions = LayoutOptions.Center,
               

                VerticalOptions = LayoutOptions.Start,
                
                Children =
                {
                    imgFoto,lbnombre

                }

            };
            stk1 = new StackLayout()
            {
                Orientation = StackOrientation.Vertical,
                Padding=new Thickness(0,20,0,0),

                VerticalOptions = LayoutOptions.Start,
                Children =
                {
                    lbcarrera,
                    lbnocont,
                    lbemail,lbsexo,lbtelefono,lbdireccion,btnActualizar

                }

            };
            stk2 = new StackLayout()
            {
                Orientation = StackOrientation.Horizontal,

                VerticalOptions = LayoutOptions.Center,
                Padding = new Thickness(0,80,0,0),
                HorizontalOptions = LayoutOptions.CenterAndExpand,
               
                Children =
                {
                    imginst,lbinstitucion

                }

            };

            stk = new StackLayout()
            {
                Orientation = StackOrientation.Vertical,
               

                VerticalOptions = LayoutOptions.Start,
                Children =
                {
                    stk3,
                    lbtitulo,
                    stk1,
                    stk2

                }

            };
            Content = stk;
        }

        private async void Btn_Cliked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Actualizar());
        }
    }
}
