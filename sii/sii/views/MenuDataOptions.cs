using sii.models;

using System;
using System.Collections.Generic;
using System.Text;

namespace sii.views
{
    class MenuDataOptions : List<MenuOpcion>
    {
        public MenuDataOptions()
        {
            this.Add(new MenuOpcion()
                {
                Title = "Inicio",
                IconSource = "inicio.png",
                TargetType = typeof(SplashPage)
            });
            this.Add(new MenuOpcion()
            {
                Title = "Calificaciones ",
                IconSource = "calif.png",
                TargetType = typeof(Lista)
            });
            this.Add(new MenuOpcion()
            {
                Title = "Buzon de Quejas",
                IconSource = "quejas.png",
                TargetType=typeof(Quejas)
            });
            this.Add(new MenuOpcion()
            {
                Title = "Actividades Complementarias",
                IconSource = "complementaria.png",
                TargetType = typeof(Complementaria),
            });
            this.Add(new MenuOpcion()
            {
                Title = "Inscribir Materia",
                IconSource = "ac.png",
                TargetType = typeof(ListaMateria),
            });
            this.Add(new MenuOpcion()
            {
                Title = "Enviar Correo Profesor",
                IconSource = "correo.png",
                TargetType = typeof(Contacto),
            });
            this.Add(new MenuOpcion()
            {
                Title = "Cerrar Sesion",
                IconSource = "salir.png",
               
                TargetType = typeof(MainPage)
            });

        }
    }
}
