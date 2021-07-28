using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Rentas
{
    public class ProductosBL
    {
        Contexto _contexto;
        public BindingList<Producto> ListaProductos { get; set; }

        public ProductosBL()
        {
            _contexto = new Contexto();
            ListaProductos = new BindingList<Producto>();

            
        }

        public BindingList<Producto> ObtenerProductos()
        {
            _contexto.Productos.Load();
            ListaProductos = _contexto.Productos.Local.ToBindingList();

            return ListaProductos;
        }
        
        //Cancelar ingreso de datos
        public void CancelarCambios()
        {
            foreach (var item in _contexto.ChangeTracker.Entries())
            {
                item.State = EntityState.Unchanged;
                item.Reload();
            }
        }

        public Resultado GuardarProducto(Producto producto)
        {
            var resultado = Validar(producto);

                if (resultado.Exitoso == false)
                {
                 return resultado;
                }

            _contexto.SaveChanges();

            resultado.Exitoso = true;
            return resultado;
        }

        public void AgregarProducto()
        {
            var nuevoProducto = new Producto();
            ListaProductos.Add(nuevoProducto);
        }

        public bool EliminarProducto(int id)
        {
            foreach (var item in ListaProductos)
            {
                if(item.Id == id)
                {
                    ListaProductos.Remove(item);
                    _contexto.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        private Resultado Validar(Producto producto)
        {
            var resultado = new Resultado();
            resultado.Exitoso = true;

            if(producto == null)
            {
                resultado.Mensaje = "Agregue un producto valido";
                resultado.Exitoso = false;

                return resultado;
            }

            if (string.IsNullOrEmpty(producto.Descripcion) == true)
            {
                resultado.Mensaje = "Ingrese una descripcion!";
                resultado.Exitoso = false;
            }

            if (producto.Existencia < 0)
            {
                resultado.Mensaje = "La existencia debe ser mayor que cero!";
                resultado.Exitoso = false;
            }

            if (producto.Precio < 0)
            {
                resultado.Mensaje = "El precio no debe ser negativo";
                resultado.Exitoso = false;
            }

            if (producto.TipoId < 0)
            {
                resultado.Mensaje = "Debe seleccionar un tipo de producto";
                resultado.Exitoso = false;
            }

            //Validacion extra si no es un videojuego no selecciona una categoria propia
            if (producto.TipoId != 3)
            {
                producto.CategoriaId = 6;
            }

            if (producto.CategoriaId < 0)
            {
                resultado.Mensaje = "Debe seleccionar una categoria";
                resultado.Exitoso = false;
            }

            

            return resultado;
        }

    }


    public class Producto
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public byte[] Foto { get; set; }
        public double Precio { get; set; }
        public int Existencia { get; set; }
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
        public int TipoId { get; set; }
        public Tipo Tipo { get; set; }
        public bool Activo { get; set; }
    }

    public class Resultado
    {
        public bool Exitoso { get; set; }
        public string Mensaje { get; set; }
    }
}
