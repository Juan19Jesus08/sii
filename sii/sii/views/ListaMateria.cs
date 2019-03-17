using sii.models;
using sii.ws;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace sii.views
{
    class ListaMateria : ContentPage
    {
        private ListView lv_inst;
        private StackLayout st_inst, stk1;
        private List<models.ListaMateria> list_inst;
        private wsListaMateria objwsListaMateria;
        private wsInscripcion objInscripcion = new wsInscripcion();
        private Label lblNombre;

        private ScrollView scroll;
        public ListaMateria()
        {
            list_inst = new List<models.ListaMateria>();
            objwsListaMateria = new wsListaMateria();
            CrearGUIAsync();
        }
        public void CrearGUIAsync()
        {
            Title = "Lista Materia";
            lblNombre = new Label()
            {
                Text = "Materias",
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


                ItemTemplate = new DataTemplate(typeof(ResultCellLista))
            };
            lv_inst.ItemSelected += async (sender, e) =>
            {

                models.ListaMateria objCorreo = (models.ListaMateria)e.SelectedItem;

                Settings.Settings.horas = objCorreo.horas;
                Settings.Settings.clave_grupo = objCorreo.clave_grupo;
                Settings.Settings.clave_mat = objCorreo.clave_mat;
                Settings.Settings.nombre_mat = objCorreo.nombre_mat;


                // DisplayAlert("Actividad Extraescolar", Settings.Settings.actividad);// + "\n" +
                //  Settings.Settings.institucionShortName + "\n"
                //+ Settings.Settings.institucionLogo + "\n", "Aceptar");
                await DisplayAlert("Inscribir", "Nombre de la materia : " + Settings.Settings.nombre_mat + "\n"
                    +"Clave de la Materia : "+Settings.Settings.clave_mat+"\n"
                    +"Numero de Grupo : "+Settings.Settings.clave_grupo+"\n"
                    +"Horas"+Settings.Settings.horas, "Aceptar");

                wsInscripcion objInscripcion = new wsInscripcion();


                try
                {


                    bool resultado = await objInscripcion.postInscripcion("0", "0", "0", "0");
                    if (resultado)
                    {


                        await DisplayAlert("Exito", "Envio Exitoso", "Aceptar");
                        await Navigation.PushModalAsync(new CargaAcademica());

                    }
                }
                catch (Exception) { await DisplayAlert("Error", "Al Envio no Exitoso", "Aceptar"); }






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
                list_inst = await objwsListaMateria.listaMateria();
                lv_inst.ItemsSource = list_inst;
                lv_inst.IsVisible = true;
            }
            catch (Exception e) { await DisplayAlert("", e.StackTrace, ""); }

        }
    }
    class ResultCellLista : ViewCell
    {


        public ResultCellLista()
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
            lblcvemat.SetBinding(Label.TextProperty, "nombre_mat");
            var lblNombre_mat = new Label
            {

                FontSize = 10,
                HeightRequest = heigh,
                WidthRequest = 60,
                TextColor = Color.Black,
                FontFamily = "Roboto"
            };
            lblNombre_mat.SetBinding(Label.TextProperty, "clave_mat");
            var lb_mat_calif = new Label
            {

                FontSize = 10,
                HeightRequest = heigh,
                WidthRequest = 60,
                TextColor = Color.Black,
                FontFamily = "Roboto",
                FontAttributes = FontAttributes.Bold
            };
            lb_mat_calif.SetBinding(Label.TextProperty, "clave_grupo");

            var lbOportunidad_mat = new Label
            {

                FontSize = 10,
                HeightRequest = heigh,
                WidthRequest = 60,
                TextColor = Color.Black,
                FontFamily = "Roboto",

            };
            lbOportunidad_mat.SetBinding(Label.TextProperty, "horas");
            

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
                 

                }
            };
            View = stackList;
        }

    }



}

