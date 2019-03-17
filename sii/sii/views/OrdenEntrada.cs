using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using sii.ws;

namespace sii.views
{
    class OrdenEntrada:ContentPage
    {
        private StackLayout stk;
        private StackLayout stk2;
        private StackLayout stk3;
        private StackLayout stk4;
        private Label lbfecha;
        private Label lbtitulo;
        private Label lbmens1;
        private Label lbmens2;
        private Label lbinstitucion;
        private Image imgFoto, imginst;
        private wsOrden objwsOrden;

        public OrdenEntrada()
        {
           
            crearGui();
            

        }

        private void crearGui()
        {
            lbtitulo = new Label()
            {
                Text = "Orden de Entrada",
                FontSize = 30,
                TextColor = Color.Black,
                HorizontalTextAlignment = TextAlignment.Center



            };
            lbfecha = new Label()
            {
                Text = "Fecha de inscripcion : ",
                FontSize = 20,
                TextColor = Color.Black,
                HorizontalTextAlignment = TextAlignment.Center

            };
            lbmens1 = new Label()
            {

                Text = Settings.Settings.fecha_ins,
                FontSize = 20,
                TextColor = Color.Black,
                HorizontalTextAlignment = TextAlignment.Center

            };
            lbmens2 = new Label()
            {
                Text = "Nota: Para la generación de la orden de entrada no se contempla actividades extraescolares ni complementarias (ej. Tutorías). : ",
                FontSize = 20,
                TextColor = Color.Black,
                HorizontalTextAlignment = TextAlignment.Center

            };
            stk3 = new StackLayout()
            {
                Orientation = StackOrientation.Vertical,
                
                Padding = new Thickness(0, 70, 0, 0),
                HorizontalOptions = LayoutOptions.Start,
                Children =
                {
                    lbmens1,
                    lbmens2

                }

            };
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
            stk4 = new StackLayout()
            {
                Orientation = StackOrientation.Horizontal,

                VerticalOptions = LayoutOptions.Center,
                Padding = new Thickness(0, 180, 0, 0),
                HorizontalOptions = LayoutOptions.CenterAndExpand,

                Children =
                {
                    imginst,lbinstitucion

                }

            };
            stk2 = new StackLayout()
            {
                Orientation = StackOrientation.Vertical,
                

                HorizontalOptions = LayoutOptions.Center,
                Children =
                {
                    lbfecha,
                    stk3
                  
                }

            };
            stk = new StackLayout()
            {
                Orientation = StackOrientation.Vertical,
               
                
                HorizontalOptions = LayoutOptions.Fill,
                Children=
                {
                    lbtitulo,
                      stk2,
                      stk4

                }
              
            };
            Content = stk;
        }
        protected override async void OnAppearing()
        {
            objwsOrden = new wsOrden();
            base.OnAppearing();
            try
            {
                var consumir = await objwsOrden.listaAlumno();
            }
            catch (Exception e) { }
        }

    }
}