using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using sii.ws;
using sii.views;
using XLabs.Forms.Controls;

namespace sii
{
    public partial class MainPage : ContentPage
    {
        private ActivityIndicator aiIndicadorLogin;
        private Image imgLogin;
        private Entry txtUsuarioLogin, txtContrasenaLogin;
        private CheckBox checkbox;
        private Button btnLogin;
        private Label lblLogin;
        private StackLayout stkLogin;
        private RelativeLayout rlLogin;
        private wsAlumno objWSAlumno;
        public MainPage()
        {
            objWSAlumno = new wsAlumno();
            
            checkbox = new CheckBox
            {
                DefaultText = "Recordad usuario y contrseña",
                FontSize = 13,
                TextColor = Color.Black,
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };
            //InitializeComponent();
           
            NavigationPage.SetHasNavigationBar(this, false);
            var sub = new AbsoluteLayout();
            imgLogin = new Image
            {
                Source = "logo_itc.png",
                WidthRequest = 200,
                HeightRequest = 200
            };
            sub.Children.Add(imgLogin);
           
            this.Content = sub;
            txtUsuarioLogin = new Entry
            {
                Placeholder = "Usuario",
                PlaceholderColor = Color.Black,
                HorizontalTextAlignment = TextAlignment.Center,
                TextColor = Color.Black,
                HorizontalOptions = LayoutOptions.Center,
                WidthRequest = 400,
                Keyboard = Keyboard.Numeric
            };
            txtContrasenaLogin = new Entry
            {
                IsPassword = true,
                Placeholder = "Contraseña",
                TextColor = Color.Black,
                HorizontalTextAlignment = TextAlignment.Center,
                PlaceholderColor = Color.Black,
                HorizontalOptions = LayoutOptions.Center,
                WidthRequest = 400
            };
            btnLogin = new Button
            {
                Text = "Iniciar sesion",
                BackgroundColor = Color.FromHex("#008A17"),
                TextColor = Color.White
            };
            btnLogin.Clicked += Btn_Cliked;
            aiIndicadorLogin = new ActivityIndicator
            {
                HorizontalOptions = LayoutOptions.Center
            };
            stkLogin = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                HorizontalOptions = LayoutOptions.Center,
                
                WidthRequest = 500,
                Children =
                {
                    imgLogin,
                    txtUsuarioLogin,
                    txtContrasenaLogin,
                    checkbox,
                    btnLogin,
                    aiIndicadorLogin
                }
            };
            rlLogin = new RelativeLayout();
            rlLogin.Children.Add(
                stkLogin,
                Constraint.RelativeToParent((parent) => { return 0; }),/*Posision X*/
                Constraint.RelativeToParent((parent) => { return parent.Height * 0.1; }),/*Posicion Y*/
                Constraint.RelativeToParent((parent) => { return parent.Width; }),/*Ancho*/
                Constraint.RelativeToParent((parent) => { return parent.Width; })/*Alto*/
            );
            lblLogin = new Label
            {
                Text = "Instituto Tecnologico de Celaya",
                FontSize = 20,
                TextColor = Color.Black,
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };
            rlLogin.Children.Add(
                lblLogin,
                Constraint.RelativeToParent((parent) => { return 0; }),
                Constraint.RelativeToView(stkLogin, (parent, view) => { return view.Y + view.Height + 100; }),
                Constraint.RelativeToParent((parent) => { return parent.Width; }),
                Constraint.RelativeToParent((parent) => { return parent.Width; })
            );
            if (!String.IsNullOrEmpty(Settings.Settings.nocont) && !String.IsNullOrEmpty(Settings.Settings.password))
            {
                txtUsuarioLogin.Text = Settings.Settings.nocont;
                txtContrasenaLogin.Text = Settings.Settings.password;
            }
            Content = rlLogin;
        }

        private async void Btn_Cliked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsuarioLogin.Text))
            {
                await DisplayAlert("Error", "Debes introducir un usuario", "Aceptar");
                txtUsuarioLogin.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtContrasenaLogin.Text))
            {
                await DisplayAlert("Error", "Debes de introducir una contraseña", "Aceptar");
                txtContrasenaLogin.Focus();
                return;
            }
            aiIndicadorLogin.IsRunning = true;
            wsLogin objWSL = new wsLogin();
            try
            {
                List<String> resultado = await objWSL.Conexion(txtUsuarioLogin.Text, txtContrasenaLogin.Text);
                if (!resultado.Equals("Acceso Denegado"))
                {
                    if (checkbox.Checked)
                    {
                        Settings.Settings.nocont = txtUsuarioLogin.Text;
                        Settings.Settings.password = txtContrasenaLogin.Text;
                    }
                    else
                    {
                        Settings.Settings.nocont = txtUsuarioLogin.Text;
                        Settings.Settings.password = null;
                    }
                    await DisplayAlert("Bienvenido","Usuario Correcto","Aceptar");
                    var consumir = await objWSAlumno.listaAlumno();
                    await Navigation.PushModalAsync(new SplashPage());
                }
            }
            catch (Exception) { await DisplayAlert("Error", "Usuario o contraseña incorrectos", "Aceptar"); }
            aiIndicadorLogin.IsRunning = false;
        }

    }
}