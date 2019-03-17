using sii.models;
using sii.ws;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace sii.views
{
    class Complementaria : ContentPage
    {
        private ListView lv_inst;
        private StackLayout st_inst, stk1;
        private List<models.Complementaria> list_inst;
        private wsComplementaria objWSComplemento;
        private Label lblNombre;
        private Label lblClave;
        private Label lbCalificacion;
       
        public Complementaria()
        {
            Title = "Actividades Complementarias";
            list_inst = new List<models.Complementaria>();
            objWSComplemento = new wsComplementaria();
            CrearGUIAsync();
        }
        public void CrearGUIAsync()
        {
            lblNombre = new Label()
            {
                Text = "Actividad Complementaria",
                FontSize = 15,
                TextColor = Color.White,
            };
            lblClave = new Label()
            {
                Text = "Creditos",
                FontSize = 15,
                TextColor = Color.White
            };
            lbCalificacion = new Label()
            {
                Text = "Situacion",
                FontSize = 15,
                TextColor = Color.White
            };
            

            stk1 = new StackLayout()
            {

                Orientation = StackOrientation.Horizontal,
                BackgroundColor = Color.FromHex("#008A17"),
                HorizontalOptions = LayoutOptions.Fill,

                Children =
                {
                    lblNombre,lblClave,lbCalificacion
                }

            };

            lv_inst = new ListView()
            {
                HasUnevenRows = true, //Estandarizar items


                ItemTemplate = new DataTemplate(typeof(ResultCell4))
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
            Content = st_inst;
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            try
            {
                lv_inst.IsVisible = false;
                list_inst = await objWSComplemento.listaKardex();
                lv_inst.ItemsSource = list_inst;
                lv_inst.IsVisible = true;
            }
            catch (Exception e) { await DisplayAlert("", e.StackTrace, ""); }

        }
    }
    class ResultCell4 : ViewCell
    {


        public ResultCell4()
        {
            int width = 100, heigh = 35;




            var lblcvemat = new Label()
            {
                HorizontalTextAlignment = TextAlignment.Start,
                FontSize = 14,
                HeightRequest = heigh,
                WidthRequest = 50,
                TextColor = Color.Black,
                FontFamily = "Roboto"
            };
            lblcvemat.SetBinding(Label.TextProperty, "actividad_complementaria");
            var lblNombre_mat = new Label
            {
                HorizontalTextAlignment = TextAlignment.Start,
                FontSize = 14,
                HeightRequest = heigh,
                WidthRequest = 50,
                TextColor = Color.Black,
                FontFamily = "Roboto"
            };
            lblNombre_mat.SetBinding(Label.TextProperty, "creditos");
            var lb_mat_calif = new Label
            {
                HorizontalTextAlignment = TextAlignment.Start,
                FontSize = 14,
                HeightRequest = heigh,
                WidthRequest = 50,
                TextColor = Color.Black,
                FontFamily = "Roboto",
                FontAttributes = FontAttributes.Bold
            };
            lb_mat_calif.SetBinding(Label.TextProperty, "situacion");

            

            var stackList = new StackLayout
            {
                Padding = new Thickness(10),
                Orientation = StackOrientation.Horizontal,
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Children =
                {
                    lblcvemat,
                    lblNombre_mat,
                    lb_mat_calif,
                    

                }
            };
            View = stackList;
        }

    }



}
