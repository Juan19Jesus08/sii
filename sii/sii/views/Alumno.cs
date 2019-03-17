using sii.ws;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;


namespace sii.views
{
    class Alumno : ContentPage
    {
        private ImageButton btnKardex;
        private ImageButton btnCargaAcademica;
        private ImageButton btnOrdenEntrada;
        private ImageButton btnDatosPersonales;
        private ImageButton btnEncuesta;
        private StackLayout stkLinea1;
        private StackLayout stkLinea2;
        private StackLayout stkLinea3;
        private StackLayout stkLinea4;
        private StackLayout stkLinea5;
       
        private StackLayout layout;
        private ScrollView scroll;
        private wsAlumno objWSAlumno;

        public Alumno(string nocont, string token)
        {
            objWSAlumno = new wsAlumno();
            crearGUI(nocont, token);
        }

        private void crearGUI(string nocont, string token)
        {
           // BackgroundColor = Color.FromHex("#428bca");
            Title = "Bienvenido :"+Settings.Settings.nombre;
            btnKardex = new ImageButton
            {
                Source = "kardex.png",
                Aspect = Aspect.Fill,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                WidthRequest = 200,
                HeightRequest = 200
            };
            btnKardex.Clicked += async (sender, args) => await Navigation.PushModalAsync(new DashBoardKardex(nocont, token));
            btnCargaAcademica = new ImageButton
            {
                Source = "carga_academica.png",
                Aspect = Aspect.Fill,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                WidthRequest = 200,
                HeightRequest = 200
            };
            btnCargaAcademica.Clicked += async (sender, args) => await Navigation.PushModalAsync(new DashBoardCargaAcademica(""));
            //btnCargaAcademica.Clicked += OnImageButtonClicked;
            btnOrdenEntrada = new ImageButton
            {
                Source = "orden_entrada.png",
                Aspect = Aspect.Fill,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                WidthRequest = 200,
                HeightRequest = 200
            };
            btnOrdenEntrada.Clicked += async (sender, args) => await Navigation.PushModalAsync(new DashBoardOrdenEntrada(""));
            btnDatosPersonales = new ImageButton
            {
                Source = "datos_personales.png",
                Aspect = Aspect.Fill,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                WidthRequest = 200,
                HeightRequest = 200
            };
            btnDatosPersonales.Clicked += async (sender, args) => await Navigation.PushModalAsync(new DashBoardDatosPersonales(""));
            btnEncuesta = new ImageButton
            {
                Source = "actividad_extraescolar.png",
                Aspect = Aspect.Fill,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                WidthRequest = 200,
                HeightRequest = 200,
                
            };
            btnEncuesta.Clicked += async (sender, args) => await Navigation.PushModalAsync(new DashBoardActividades(""));
            stkLinea1 = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.Center,
                Children = { btnKardex }
            };
            stkLinea2 = new StackLayout
            {

                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.Center,
                Children = { btnCargaAcademica }
            };
            stkLinea3 = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Children = { btnDatosPersonales }
            };
            stkLinea4 = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions=LayoutOptions.Center,
                Children = { btnEncuesta }
            };
            stkLinea5 = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.Center,
                Children = { btnOrdenEntrada }
            };
            layout = new StackLayout
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Orientation = StackOrientation.Vertical,
                Children = {
                    stkLinea1,
                    stkLinea2,
                    stkLinea3,
                    stkLinea4,
                    stkLinea5
                }
            };

            scroll = new ScrollView
            {
                Content = layout
            };
            Content = scroll;
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            try
            {
                var consumir = await objWSAlumno.listaAlumno();
            }
            catch (Exception e) { }
        }
    }
}
