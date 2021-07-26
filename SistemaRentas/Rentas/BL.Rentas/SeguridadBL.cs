using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace BL.Rentas
{
    public class SeguridadBL
    {
        Contexto _contexto;

        public SeguridadBL()
        {
          _contexto = new Contexto();
        }


        public bool Autorizacion(string usuario, string contrasena)
        {
            var usuarios = _contexto.Usuario.ToList();

            foreach (var usuarioDB in usuarios)
            {
                if (usuario == usuarioDB.Nombre && contrasena == usuarioDB.Password)
                {
                    return true;
                }

            }

            return false;
            
        }
    }
}
