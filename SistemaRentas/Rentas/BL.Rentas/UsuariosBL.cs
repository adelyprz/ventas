using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Rentas
{
    public class UsuariosBL
    {
        Contexto _contexto;

        public List<Usuario> ListaUsuarios { get; set; }

        public UsuariosBL()
        {
            _contexto = new Contexto();
            ListaUsuarios = new List<Usuario>();
        }

        public List<Usuario> ObtenerUsuarios()
        {
            _contexto.Usuario.Load();
            ListaUsuarios = _contexto.Usuario.Local.ToList();

            return ListaUsuarios;
        }
    }

    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Password { get; set; }
    }
}

