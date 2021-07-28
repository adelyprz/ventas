using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Rentas
{
    public class ClientesBL
    {
            Contexto _contexto;
            public BindingList<Cliente> ListaClientes { get; set; }

            public ClientesBL()
            {
                _contexto = new Contexto();
                ListaClientes = new BindingList<Cliente>();


            }

            public BindingList<Cliente> ObtenerClientes()
            {
                _contexto.Cliente.Load();
                ListaClientes = _contexto.Cliente.Local.ToBindingList();

                return ListaClientes;
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

            public Resultado GuardarCliente(Cliente cliente)
            {
                var resultado = Validar(cliente);
                resultado.Exitoso = true;

                if (cliente == null)
                {
                    resultado.Mensaje = "Agregue un cliente valido";
                    resultado.Exitoso = false;

                    return resultado;
                }

            if (resultado.Exitoso == false)
                {
                    return resultado;
                }

                _contexto.SaveChanges();

                resultado.Exitoso = true;
                return resultado;
            }

            public void AgregarCliente()
            {
                var nuevoCliente = new Cliente();
                ListaClientes.Add(nuevoCliente);
            }

            public bool EliminarCliente(int id)
            {
                foreach (var item in ListaClientes)
                {
                    if (item.Id == id)
                    {
                        ListaClientes.Remove(item);
                        _contexto.SaveChanges();
                        return true;
                    }
                }
                return false;
            }

            private Resultado Validar(Cliente Cliente)
            {
            var resultado = new Resultado();
            resultado.Exitoso = true;

            if (string.IsNullOrEmpty(Cliente.NombreCliente) == true)
            {
                resultado.Mensaje = "Ingrese un nombre!";
                resultado.Exitoso = false;
            }

            if (string.IsNullOrEmpty(Cliente.ApellidosCliente) == true)
            {
                resultado.Mensaje = "Ingrese un Apellido!";
                resultado.Exitoso = false;
            }

            if (string.IsNullOrEmpty(Cliente.DireccionCliente) == true)
            {
               resultado.Mensaje = "Debe ingresar una direccion";
               resultado.Exitoso = false;
            }

            if (string.IsNullOrEmpty(Cliente.TelefonoCliente) == true)
            {
               resultado.Mensaje = "Debe proporcionar un numero telefonico";
               resultado.Exitoso = false;
            }


            return resultado;
        }

    }


        public class Cliente
        {
            public int Id { get; set; }
            public string NombreCliente { get; set; }
            public string ApellidosCliente { get; set; }
            public string DireccionCliente { get; set; }
            public string TelefonoCliente { get; set; }
        }

    
}
