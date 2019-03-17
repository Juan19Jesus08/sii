using sii.models;
using sii.ws;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace sii.views
{
    class Kardex: ContentPage
    {
        private ListView lv_inst;
        private StackLayout st_inst, stk1;
        private List<models.Kardex> list_inst;
        private WSKardex objWsKardex;
        private Label lblNombre;
        private Label lblClave;
        private Label lbCalificacion;
        private Label lbOportunidad;
        private Label lbCreditos;
        public Kardex()
        {
            Title = "Kardex";
            list_inst = new List<models.Kardex>();
            objWsKardex = new WSKardex();
            CrearGUIAsync();
        }
        public void CrearGUIAsync()
        {
            lblNombre = new Label()
            {
                Text = "Nombre",
                FontSize = 15,
                WidthRequest=100,
                HeightRequest=30,
                TextColor = Color.White,
             };
            lblClave = new Label()
            {
                Text = "Clave",
                FontSize = 15,
                TextColor = Color.White,
                WidthRequest = 100,
                HeightRequest = 30,
            };
            lbCalificacion = new Label()
            {
                Text = "Calif",
                FontSize = 15,
                TextColor = Color.White,
                WidthRequest = 100,
                HeightRequest = 30,
            };
            lbOportunidad = new Label()
            {
                Text = "Opor",
                FontSize = 15,
                TextColor = Color.White,
                WidthRequest = 100,
                HeightRequest = 30,
            };
            lbCreditos = new Label()
            {
                Text = "Creditos",
                FontSize = 15,
                TextColor = Color.White,
                WidthRequest = 100,
                HeightRequest = 30,
            };

            stk1 = new StackLayout()
            {
                
                Orientation = StackOrientation.Horizontal,
                BackgroundColor = Color.FromHex("#008A17"),
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions=LayoutOptions.Center,
                

                Children =
                {
                    lblClave,lblNombre,lbCalificacion,lbOportunidad,lbCreditos
                }

            };

            lv_inst = new ListView()
            {
                HasUnevenRows = true, //Estandarizar items
               

                ItemTemplate = new DataTemplate(typeof(ResultCell))
            };
            var stk_2 = new StackLayout()
            {

                Orientation=StackOrientation.Vertical,
                HorizontalOptions=LayoutOptions.CenterAndExpand,
                VerticalOptions=LayoutOptions.Center,
                Children =
                {
                    stk1,
                    lv_inst
                }
                 
            };

            st_inst = new StackLayout()
            {
                
                Orientation = StackOrientation.Vertical,
                HorizontalOptions=LayoutOptions.Center,
                VerticalOptions=LayoutOptions.Center,
               // Padding = new Thickness(20),
                Children =
                {
                    stk_2
                    
                    
                }
            };
            Content = st_inst;
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            try
            {
                lv_inst.IsVisible = false;
                list_inst = await objWsKardex.listaKardex();
                lv_inst.ItemsSource = list_inst;
                lv_inst.IsVisible = true;
            }
            catch (Exception e) { await DisplayAlert("", e.StackTrace, ""); }

        }
    }
    class ResultCell : ViewCell
    {
   

        public ResultCell()
        {
            int width = 100, heigh = 35;
           



            var lblcvemat = new Label()
            {
               
                FontSize = 10,
                HeightRequest = heigh,
                WidthRequest = 60,
                TextColor = Color.Black,
                FontFamily = "Roboto"
            };
            lblcvemat.SetBinding(Label.TextProperty, "cvemat");
            var lblNombre_mat = new Label
            {
                
                FontSize = 10,
                HeightRequest = heigh,
                WidthRequest = 60,
                TextColor = Color.Black,
                FontFamily = "Roboto"
            };
            lblNombre_mat.SetBinding(Label.TextProperty, "materia.nombre");
            var lb_mat_calif = new Label
            {
               
                FontSize = 10,
                HeightRequest = heigh,
                WidthRequest = 60,
                TextColor = Color.Black,
                FontFamily = "Roboto",
                FontAttributes = FontAttributes.Bold
            };
            lb_mat_calif.SetBinding(Label.TextProperty, "calificacion");

            var lbOportunidad_mat = new Label
            {
                
                FontSize = 10,
                HeightRequest = heigh,
                WidthRequest = 60,
                TextColor = Color.Black,
                FontFamily = "Roboto",

            };
            lbOportunidad_mat.SetBinding(Label.TextProperty, "oportunidad.descripcion");
            var lbCreditos_mat = new Label
            {
               
                FontSize = 10,
                HeightRequest = heigh,
                WidthRequest = 20,
                TextColor = Color.Black,
                FontFamily = "Roboto",

            };
            lbCreditos_mat.SetBinding(Label.TextProperty, "materia.creditos");

            var stackList = new StackLayout
            {
                Padding = new Thickness(10),
                Orientation = StackOrientation.Horizontal,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Children =
                {
                    lblcvemat,
                    lblNombre_mat,
                    lb_mat_calif,
                    lbOportunidad_mat,
                    lbCreditos_mat

                }
            };
            View = stackList;
        }

    }



}
