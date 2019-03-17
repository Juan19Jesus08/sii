using sii.models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace sii.views
{
    class DashBoardLista : MasterDetailPage
    {
        private MenuDashBoard menuPage;
        private string sportSelected;
        private Lista lista;
        //private Fondo fondo;
        public DashBoardLista(string nocont, string token)
        {
            crearGui(nocont, token);
        }

        private void crearGui(string nocont, string token)
        {
            menuPage = new MenuDashBoard();
            lista = new Lista();
            menuPage.OpcionesMenu.ItemSelected += (sender, e) => NavigationTo(e.SelectedItem as MenuOpcion);
            ToolbarItems.Add(
               new ToolbarItem
               {
                   Icon = "notificacion.png",
                   Order = ToolbarItemOrder.Primary,
                   Command = new Command(async () =>
                   {
                       await App.Current.MainPage.DisplayActionSheet("Notificaciones", "Aceptar", null,
                            "0 Notificaciones");

                   })
               }
            );
            Master = menuPage;
            Detail = new NavigationPage(lista);
        }
        private void NavigationTo(MenuOpcion item)
        {
            try
            {

                Page pagina = (Page)Activator.CreateInstance(item.TargetType);//crear instancia de pagina

                switch (pagina.GetType().Name)
                {
                    case "SplashPage":
                        Detail = new NavigationPage(pagina);
                        IsPresented = false;
                        break;
                    case "Lista":
                        Detail = new NavigationPage(pagina);
                        IsPresented = false;
                        break;
                    case "Quejas":
                        Detail = new NavigationPage(pagina);
                        IsPresented = false;
                        break;
                    case "Complementaria":
                        Detail = new NavigationPage(pagina);
                        IsPresented = false;
                        break;
                    case "Correo":
                        Detail = new NavigationPage(pagina);
                        IsPresented = false;
                        break;
                    case "MainPage":
                        Detail = new NavigationPage(pagina);
                        IsPresented = false;
                        break;
                }





            }
            catch (Exception e) { DisplayAlert("", e.StackTrace, "Aceptar"); }

        }

    }
}
