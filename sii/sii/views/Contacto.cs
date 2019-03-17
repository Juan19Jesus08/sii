using sii.models;
using sii.ws;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace sii.views
{
    class Contacto : ContentPage
    {
        private ListView lv_inst;
        private StackLayout st_inst, stk1;
        private List<models.Correo> list_inst;
        private wsCorreo objwsCorreo;
        private Label lblNombre;
       
        private ScrollView scroll;
        public Contacto()
        {
            list_inst = new List<models.Correo>();
            objwsCorreo = new wsCorreo();
            CrearGUIAsync();
        }
        public void CrearGUIAsync()
        {
            Title = "Profesores";
            lblNombre = new Label()
            {
                Text = "Contacto",
                FontSize = 18,
                TextColor = Color.White,
            };
           
            stk1 = new StackLayout()
            {

                Orientation = StackOrientation.Horizontal,
                BackgroundColor = Color.FromHex("#008A17"),
                HorizontalOptions = LayoutOptions.Fill,

                Children =
                {
                    lblNombre
                }

            };

            lv_inst = new ListView()
            {
                HasUnevenRows = true, //Estandarizar items


                ItemTemplate = new DataTemplate(typeof(ResultCellcorreo))
            };
            lv_inst.ItemSelected += async (sender, e) =>
            {

                models.Correo objCorreo = (models.Correo)e.SelectedItem;

                Settings.Settings.nombre_profe = objCorreo.nombre;
                Settings.Settings.correo = objCorreo.correo;


                // DisplayAlert("Actividad Extraescolar", Settings.Settings.actividad);// + "\n" +
                //  Settings.Settings.institucionShortName + "\n"
                //+ Settings.Settings.institucionLogo + "\n", "Aceptar");
                DisplayAlert("Correo", "Nombre del Profesor " + Settings.Settings.nombre_profe, "Aceptar");
                await Navigation.PushModalAsync(new Correo());


            };
            st_inst = new StackLayout()
            {

                Orientation = StackOrientation.Vertical,
                // Padding = new Thickness(20),
                Children =
                {
                    stk1,
                    lv_inst
                }
            };
            scroll = new ScrollView()
            {
                Orientation = ScrollOrientation.Horizontal,
                Content = st_inst
            };
            Content = scroll;
        }



        protected override async void OnAppearing()
        {
            base.OnAppearing();
            try
            {
                lv_inst.IsVisible = false;
                list_inst = await objwsCorreo.listacorreo();
                lv_inst.ItemsSource = list_inst;
                lv_inst.IsVisible = true;
            }
            catch (Exception e) { await DisplayAlert("", e.StackTrace, ""); }

        }
    }
    class ResultCellcorreo : ViewCell
    {


        public ResultCellcorreo()
        {
            int width = 100, heigh = 35;




            var lblcvemat = new Label()
            {
                HorizontalTextAlignment = TextAlignment.Center,
                FontSize = 14,
                HeightRequest = heigh,
                WidthRequest = 50,
                TextColor = Color.Black,
                FontFamily = "Roboto"
            };
            lblcvemat.SetBinding(Label.TextProperty, "nombre");
            

            var stackList = new StackLayout
            {
                Padding = new Thickness(10),
                Orientation = StackOrientation.Horizontal,
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Children =
                {
                    lblcvemat,
                   

                }
            };
            View = stackList;
        }

    }



}
