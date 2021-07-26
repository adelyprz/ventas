using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Rentas
{
    public class DatosdeInicio : CreateDatabaseIfNotExists<Contexto>
    {
        protected override void Seed(Contexto contexto)
        {
            var usuarioAdmin = new Usuario();
            usuarioAdmin.Nombre = "admin";
            usuarioAdmin.Password = "123";

            contexto.Usuario.Add(usuarioAdmin);

            var categoria1 = new Categoria();
            categoria1.Descripcion = "Accion y peleas";
            contexto.Categorias.Add(categoria1);

            var categoria2 = new Categoria();
            categoria2.Descripcion = "Estrategia";
            contexto.Categorias.Add(categoria2);

            var categoria3 = new Categoria();
            categoria3.Descripcion = "Simulacion";
            contexto.Categorias.Add(categoria3);

            var categoria4 = new Categoria();
            categoria4.Descripcion = "Deportes";
            contexto.Categorias.Add(categoria4);
        
            var categoria5 = new Categoria();
            categoria5.Descripcion = "Disparos";
            contexto.Categorias.Add(categoria5);

            var categoria6 = new Categoria();
            categoria6.Descripcion = "No es un videojuego";
            contexto.Categorias.Add(categoria6);

            var tipo1 = new Tipo();
            tipo1.Descripcion = "Consola";
            contexto.Tipos.Add(tipo1);

            var tipo2 = new Tipo();
            tipo2.Descripcion = "Accesorio";
            contexto.Tipos.Add(tipo2);

            var tipo3 = new Tipo();
            tipo3.Descripcion = "Videojuego";
            contexto.Tipos.Add(tipo3);
            
            base.Seed(contexto);

        }
    }
}
