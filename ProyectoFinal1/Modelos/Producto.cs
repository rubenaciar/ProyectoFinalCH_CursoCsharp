using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal1.Modelos
{
    //CLASE PRODUCTO
    public class Producto
    {
        #region Atributos
        private int _id;
        private string _descripcion;
        private decimal _costo;
        private decimal _precioVenta;
        private int _stock;
        private int _idUsuario;
        #endregion
        #region Constructores

        // Constructor por defecto para inicializar los atributos
        public Producto()
        {
            _id = 0;
            _descripcion = string.Empty;
            _costo = 0;
            _precioVenta = 0;
            _stock = 0;
            _idUsuario = 0;


            // Mensaje de creacion de la instancia de Producto
            Console.WriteLine("La instancia de Producto se ha creado satisfactoriamente.");
        }
        public Producto(int id, string descripcion, decimal costo, decimal precioVenta, int stock, int idUsuario)
        {
            // Validacion de parametros
            if (string.IsNullOrWhiteSpace(descripcion))
            {
                throw new ArgumentException("La descripcion no puede ser nula o vacia.");
            }

            if (costo < 0)
            {
                throw new ArgumentException("El costo no puede ser negativo.");
            }

            if (precioVenta < 0)
            {
                throw new ArgumentException("El precio de venta no puede ser negativo.");
            }

            if (stock < 0)
            {
                throw new ArgumentException("La cantidad en stock no puede ser negativa.");
            }
            // Inicializacion de las propiedades por medio de los argumentos
            _id = id;
            _descripcion = descripcion;
            _costo = costo;
            _precioVenta = precioVenta;
            _stock = stock;
            _idUsuario = idUsuario;
            // Mensaje de creacion de la instancia de Producto
            Console.WriteLine("La instancia de Producto se ha creado satisfactoriamente.");
        }
        #endregion


        #region Propiedades
        public int Id { get; set; } // Identificador unico del producto
        public string Descripcion { get; set; } // Descripcion del producto
        public decimal Costo { get; set; } // Costo de produccion del producto
        public decimal PrecioVenta { get; set; } // Precio de venta del producto
        public int Stock { get; set; } // Cantidad en stock del producto
        public int IdUsuario { get; set; } // Identificador del usuario que creo el producto
        #endregion

    }
}