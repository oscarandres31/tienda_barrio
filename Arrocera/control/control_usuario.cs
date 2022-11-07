using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using puente;

namespace control
{
    public class usuario
    {
        private string _nombres;
        private string _usuario;
        private string _contraseña;
        private long _cedula;
        private string _rol;

        public string nombre
        {
            get { return _nombres; }
            set { _nombres = value; }

        }

        public string usuarios
        {
            get { return _usuario; }
            set { _usuario = value; }

        }

        public string contraseñas
        {
            get { return _contraseña; }
            set { _contraseña = value; }

        }

        public long cedulas
        {
            get { return _cedula; }
            set { _cedula = value; }
        }
        public string rol
        {
            get { return _rol; }
            set { _rol = value; }

        }

        //class control_usuario
        //{
        //    procesos p = new procesos();
        //    public usuario()
        //    {
        //        puente.procesos p = new procesos();
        //        guarda_usuario(cedulas, nombre, usuarios, contraseñas, rol);


        //    }
      //  }
        }
}
