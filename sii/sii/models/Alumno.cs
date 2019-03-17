using System;
using System.Collections.Generic;
using System.Text;

namespace sii.models
{
    class Alumno
    {//nombre ,a_paterno,a_materno,email,no_control
        public String nombre
        {
            get;
            set;
        }
     
        public String nocont
        {
            get;
            set;
        }
        public String cveesp { get; set; }
        public  Especialidades especialidad { get; set; }

        public String email { get; set; }

        public String sexo { get; set; }
        public String telefono { get; set; }
        public String direccion { get; set; }

    }
}
