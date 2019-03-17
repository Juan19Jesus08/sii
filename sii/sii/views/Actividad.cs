using sii.models;
using sii.ws;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace sii.views
{
    class Actividad : ContentPage
    {
        private ListView lv_inst;
        private StackLayout st_inst, stk1;
        private List<models.Actividad> list_inst;
        private wsActividad objWsActividad;
        private Label lblNombre;
        private Label lblClave;
        private Label lbCalificacion;
        private Label lbOportunidad;
        private Label lbCreditos;
        private ScrollView scroll;
        public Actividad()
        {
            list_inst = new List<models.Actividad>();
            objWsActividad = new wsActividad();
            CrearGUIAsync();
        }
        public void CrearGUIAsync()
        {
            Title = "Actividades Extraescolares";
            lblNombre = new Label()
            {
                Text = "Actividad",
                FontSize = 18,
                TextColor = Color.White,
            };
            lblClave = new Label()
            {
                Text = "Rama",
                FontSize = 18,
                TextColor = Color.White
            };
            lbCalificacion = new Label()
            {
                Text = "Grupo",
                FontSize = 18,
                TextColor = Color.White
            };
            lbOportunidad = new Label()
            {
                Text = "Lugar",
                FontSize = 18,
                TextColor = Color.White
            };
            lbCreditos = new Label()
            {
                Text = "Responsable",
                FontSize = 18,
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


                ItemTemplate = new DataTemplate(typeof(ResultCell3))
            };
            lv_inst.ItemSelected += (sender, e) =>
            {

                models.Actividad objIns = (models.Actividad)e.SelectedItem;

                Settings.Settings.actividad = objIns.actividad;
                Settings.Settings.rama = objIns.rama;
                Settings.Settings.grupo = objIns.grupo;
                Settings.Settings.lugar = objIns.lugar;
                Settings.Settings.responsable = objIns.responsable;
                
                // DisplayAlert("Actividad Extraescolar", Settings.Settings.actividad);// + "\n" +
                //  Settings.Settings.institucionShortName + "\n"
                //+ Settings.Settings.institucionLogo + "\n", "Aceptar");
                DisplayAlert("Atividad Extraescolar", "Actividad : "+Settings.Settings.actividad+"\n"+"Rama : " + Settings.Settings.rama+"\n"
                    +"Grupo"+ Settings.Settings.grupo+"\n"+"Lugar : " + Settings.Settings.lugar+"\n"+"Respondable : "+ Settings.Settings.responsable
                    , "Aceptar");

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
                Orientation=ScrollOrientation.Horizontal,
                Content=st_inst
            };
            Content = scroll;
        }

     

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            try
            {
                lv_inst.IsVisible = false;
                list_inst = await objWsActividad.listaKardex();
                lv_inst.ItemsSource = list_inst;
                lv_inst.IsVisible = true;
            }
            catch (Exception e) { await DisplayAlert("", e.StackTrace, ""); }

        }
    }
    class ResultCell3 : ViewCell
    {


        public ResultCell3()
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
            lblcvemat.SetBinding(Label.TextProperty, "actividad");
            var lblNombre_mat = new Label
            {
                HorizontalTextAlignment = TextAlignment.Start,
                FontSize = 14,
                HeightRequest = heigh,
                WidthRequest = 50,
                TextColor = Color.Black,
                FontFamily = "Roboto"
            };
            lblNombre_mat.SetBinding(Label.TextProperty, "rama");
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
            lb_mat_calif.SetBinding(Label.TextProperty, "grupo");

            var lbOportunidad_mat = new Label
            {
                HorizontalTextAlignment = TextAlignment.Start,
                FontSize = 14,
                HeightRequest = heigh,
                WidthRequest = 50,
                TextColor = Color.Black,
                FontFamily = "Roboto",

            };
            lbOportunidad_mat.SetBinding(Label.TextProperty, "lugar");
            var lbCreditos_mat = new Label
            {
                HorizontalTextAlignment = TextAlignment.Start,
                FontSize = 14,
                HeightRequest = heigh,
                WidthRequest = 50,
                TextColor = Color.Black,
                FontFamily = "Roboto",

            };
            lbCreditos_mat.SetBinding(Label.TextProperty, "responsable");

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
                    lbOportunidad_mat,
                    lbCreditos_mat

                }
            };
            View = stackList;
        }

    }



}
