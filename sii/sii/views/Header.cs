using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using sii.ws;
using sii.ws;
namespace sii.views
{
    class Header : Frame
    {
        public Header()
        {
            wsAlumno objwsAlumno;
            Padding = new Thickness(0, 20, 0, 0);
            HeightRequest = 300;

            //Fondo del Header
            var Backgroundbox = new BoxView
            {
                Color = Color.FromHex("#008A17"),
                HeightRequest = 30,
            };

            Image BackgroundImg = new Image
            {
                Source = "logo_itc.png"
            };

            //Imagen de la escuela que esta siguiendo
            Image imgSchool = new Image
            {
                //Source = App.imgSchool,
            };

            //Imagen del evento deportivo
            Image imgEvento = new Image
            {
                Source = "logo_itc.png",
            };

            Image imgLince = new Image
            {
                Source = "alumno_"+Settings.Settings.nocont + ".png",
                Opacity = 0.6
            };

            //Enfasis de fondo del nombre de escuela y lema
            var Blackbox = new BoxView
            {
                Color = Color.Black,
                HeightRequest = 30,
                Opacity = 0.25
            };

           

            Label lblNombre = new Label
            {
                Text = "Nombre: "+Settings.Settings.nombre,
                FontSize = 12,
                TextColor = Color.White,
                FontFamily = "Roboto"
            };
            Label lblnoControl = new Label
            {
                Text = "Numero de control: "+Settings.Settings.nocont,
                FontSize = 12,
                TextColor = Color.White,
                FontFamily = "Roboto"
            };
            Label lblEspecialidad = new Label
            {
                Text = "Especialidad: "+Settings.Settings.especialidad,
                FontSize = 12,
                TextColor = Color.White,
                FontFamily = "Roboto"
            };
            Label lblemail = new Label
            {
                Text = "Email: "+Settings.Settings.email,
                FontSize = 12,
                TextColor = Color.White,
                FontFamily = "Roboto"
            };

            //Estructura del Header
            var layoutConstant = new RelativeLayout();

            layoutConstant.Children.Add(
            Backgroundbox,
            Constraint.Constant(0),
            Constraint.Constant(0),
            Constraint.RelativeToParent((parent) => { return parent.Width; }),
            Constraint.RelativeToParent((parent) => { return parent.Height; })
            );
            layoutConstant.Children.Add(
            imgLince,
            Constraint.Constant(55),
            Constraint.Constant(0),
            Constraint.RelativeToParent((parent) => { return parent.Width * 1.1; }),
            Constraint.RelativeToParent((parent) => { return parent.Height * 1.1; })
            );
            layoutConstant.Children.Add(
            Blackbox,
            Constraint.Constant(0),
            Constraint.Constant(125),
            Constraint.RelativeToParent((parent) => { return parent.Width; }),
            Constraint.RelativeToParent((parent) => { return parent.Height; })
            );
            layoutConstant.Children.Add(
            imgSchool,
            Constraint.Constant(10),
            Constraint.Constant(30),
            Constraint.Constant(90),
            Constraint.Constant(90)
            );
            layoutConstant.Children.Add(
            imgEvento,
            //Constraint.Constant(245),
            Constraint.RelativeToParent((parent) => {
                return (parent.Width * 1) - 50;
            }),
            Constraint.Constant(30),
            Constraint.Constant(35),
            Constraint.Constant(35)
            );
           
            layoutConstant.Children.Add(
            lblNombre,
            Constraint.Constant(5),
            Constraint.Constant(145),
            Constraint.RelativeToParent((parent) => { return parent.Width; }),
            Constraint.RelativeToParent((parent) => { return parent.Height; })
            );
            layoutConstant.Children.Add(
            lblnoControl,
            Constraint.Constant(5),
            Constraint.Constant(160),
            Constraint.RelativeToParent((parent) => { return parent.Width; }),
            Constraint.RelativeToParent((parent) => { return parent.Height; })
            );
            layoutConstant.Children.Add(
            lblEspecialidad,
            Constraint.Constant(5),
            Constraint.Constant(175),
            Constraint.RelativeToParent((parent) => { return parent.Width; }),
            Constraint.RelativeToParent((parent) => { return parent.Height; })
            );
            layoutConstant.Children.Add(
            lblemail,
            Constraint.Constant(5),
            Constraint.Constant(190),
            Constraint.RelativeToParent((parent) => { return parent.Width; }),
            Constraint.RelativeToParent((parent) => { return parent.Height; })
            );
            //Main Stack
            Content = layoutConstant;
        }
    }
}
