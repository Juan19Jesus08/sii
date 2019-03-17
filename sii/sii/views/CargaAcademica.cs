using sii.models;
using sii.ws;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace sii.views
{
    class CargaAcademica : ContentPage
    {
        private ListView lv_inst;
        private StackLayout st_inst, stk1;
        private List<models.Carga> list_inst;
        private wsCarga objWsKardex;
        private Label lblNombre;
        private Label lblClave;
        private Label lbCalificacion;
        private Label lbOportunidad;
        private Label lbCreditos;
        public CargaAcademica()
        {
            Title = "Carga Academica";
            list_inst = new List<models.Carga>();
            objWsKardex = new wsCarga();
            CrearGUIAsync();
        }
        public void CrearGUIAsync()
        {
            lblNombre = new Label()
            {
                Text = "CveMat",
                FontSize = 15,
                TextColor = Color.White,
            };
            lblClave = new Label()
            {
                Text = "Horas",
                FontSize = 15,
                TextColor = Color.White
            };
            lbCalificacion = new Label()
            {
                Text = "Salon",
                FontSize = 15,
                TextColor = Color.White
            };
            lbOportunidad = new Label()
            {
                Text = "NombMat",
                FontSize = 15,
                TextColor = Color.White
            };
            lbCreditos = new Label()
            {
                Text = "CveMae",
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
                    lblNombre,lblClave,lbCalificacion,lbOportunidad,lbCreditos
                }

            };

            lv_inst = new ListView()
            {
                HasUnevenRows = true, //Estandarizar items


                ItemTemplate = new DataTemplate(typeof(ResultCell2))
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
                list_inst = await objWsKardex.listaKardex();
                lv_inst.ItemsSource = list_inst;
                lv_inst.IsVisible = true;
            }
            catch (Exception e) { await DisplayAlert("", e.StackTrace, ""); }

        }
    }
    class ResultCell2 : ViewCell
    {


        public ResultCell2()
        {
            int width = 100, heigh = 35;




            var lblcvemat = new Label()
            {
                HorizontalTextAlignment = TextAlignment.Start,
                FontSize = 14,
                HeightRequest = heigh,
                WidthRequest = width,
                TextColor = Color.Black,
                FontFamily = "Roboto"
            };
            lblcvemat.SetBinding(Label.TextProperty, "cvemat");
            var lblNombre_mat = new Label
            {
                HorizontalTextAlignment = TextAlignment.Start,
                FontSize = 14,
                HeightRequest = heigh,
                WidthRequest = 50,
                TextColor = Color.Black,
                FontFamily = "Roboto"
            };
            lblNombre_mat.SetBinding(Label.TextProperty, "grupo.horario");
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
            lb_mat_calif.SetBinding(Label.TextProperty, "grupo.salon");

            var lbOportunidad_mat = new Label
            {
                HorizontalTextAlignment = TextAlignment.Start,
                FontSize = 14,
                HeightRequest = heigh,
                WidthRequest = 50,
                TextColor = Color.Black,
                FontFamily = "Roboto",

            };
            lbOportunidad_mat.SetBinding(Label.TextProperty, "materia.nombre");
            var lbCreditos_mat = new Label
            {
                HorizontalTextAlignment = TextAlignment.Start,
                FontSize = 14,
                HeightRequest = heigh,
                WidthRequest = 50,
                TextColor = Color.Black,
                FontFamily = "Roboto",

            };
            lbCreditos_mat.SetBinding(Label.TextProperty, "grupo.cvemae");

            var stackList = new StackLayout
            {
                Padding = new Thickness(10),
                Orientation = StackOrientation.Horizontal,
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.Center,
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

