using Plugin.Settings;
using Plugin.Settings.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace sii.Settings
{
    class Settings
    {


        private static ISettings AppSettings =>
            CrossSettings.Current;

        public static String nombre
        {
            get => AppSettings.GetValueOrDefault(nameof(nombre), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(nombre), value);
        }
        public static String token
        {
            get => AppSettings.GetValueOrDefault(nameof(token), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(token), value);
        }
        public static String password
        {
            get => AppSettings.GetValueOrDefault(nameof(password), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(password), value);
        }
        public static String nocont
        {
            get => AppSettings.GetValueOrDefault(nameof(nocont), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(nocont), value);
        }
        public static String cveesp
        {
            get => AppSettings.GetValueOrDefault(nameof(cveesp), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(cveesp), value);
        }

        public static String especialidad
            {
            get => AppSettings.GetValueOrDefault(nameof(especialidad), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(especialidad), value);
        }
        public static String email
        {
            get => AppSettings.GetValueOrDefault(nameof(email), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(email), value);
        }
        public static String fecha_ins
        {
            get => AppSettings.GetValueOrDefault(nameof(fecha_ins), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(fecha_ins), value);
        }
        public static String actividad
        {
            get => AppSettings.GetValueOrDefault(nameof(actividad), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(actividad), value);
        }
        public static String rama
        {
            get => AppSettings.GetValueOrDefault(nameof(rama), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(rama), value);
        }
        public static String grupo
        {
            get => AppSettings.GetValueOrDefault(nameof(grupo), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(grupo), value);
        }
        public static String lugar
        {
            get => AppSettings.GetValueOrDefault(nameof(lugar), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(lugar), value);
        }
        public static String responsable
        {
            get => AppSettings.GetValueOrDefault(nameof(responsable), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(responsable), value);
        }
        public static String sexo
        {
            get => AppSettings.GetValueOrDefault(nameof(sexo), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(sexo), value);
        }
        public static String nombre_profe
        {
            get => AppSettings.GetValueOrDefault(nameof(nombre_profe), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(nombre_profe), value);
        }
        public static String correo
        {
            get => AppSettings.GetValueOrDefault(nameof(correo), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(correo), value);
        }
        public static String telefono
        {
            get => AppSettings.GetValueOrDefault(nameof(telefono), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(telefono), value);
        }
        public static String direccion
        {
            get => AppSettings.GetValueOrDefault(nameof(direccion), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(direccion), value);
        }
        public static String nombre_mat
        {
            get => AppSettings.GetValueOrDefault(nameof(nombre_mat), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(nombre_mat), value);
        }
        public static String clave_mat
        {
            get => AppSettings.GetValueOrDefault(nameof(clave_mat), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(clave_mat), value);
        }
        public static String clave_grupo
        {
            get => AppSettings.GetValueOrDefault(nameof(clave_grupo), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(clave_grupo), value);
        }
        public static String horas
        {
            get => AppSettings.GetValueOrDefault(nameof(horas), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(horas), value);
        }

    }
}
