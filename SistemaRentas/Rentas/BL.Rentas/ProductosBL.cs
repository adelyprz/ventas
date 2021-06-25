using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Rentas
{
    public class ProductosBL
    {
        public BindingList<Producto> ListaProductos { get; set; }

        public ProductosBL()
        {
            //Datos de prueba
            ListaProductos = new BindingList<Producto>();

            var producto1 = new Producto();
            producto1.Id = 1;
            producto1.Descripcion = "PS4 Slim";
            producto1.Precio = 17000;
            producto1.Existencia = 5;
            producto1.Activo = true;

            ListaProductos.Add(producto1); //Agrega la información del nuevo producto a la lista.

            var producto2 = new Producto();
            producto2.Id = 2;
            producto2.Descripcion = "PS3";
            producto2.Precio = 6000;
            producto2.Existencia = 7;
            producto2.Activo = true;

            ListaProductos.Add(producto2);

            var producto3 = new Producto();
            producto3.Id = 3;
            producto3.Descripcion = "Mando PS4";
            producto3.Precio = 1800;
            producto3.Existencia = 8;
            producto3.Activo = true;

            ListaProductos.Add(producto3);
        }

        public BindingList<Producto> ObtenerProductos()
        {
            return ListaProductos;
        }

    }

    public class Producto
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public double Precio { get; set; }
        public int Existencia { get; set; }
        public bool Activo { get; set; }
    }
}
