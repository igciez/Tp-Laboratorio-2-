using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2018
{
    /// <summary>
    /// No podrá tener clases heredadas.
    /// </summary>
    public sealed class Changuito
    {
        private List<Producto> productos;
        private int espacioDisponible;
        public enum ETipo
        {
            Dulce, Leche, Snacks, Todos
        }

        #region "Constructores"
        /// <summary>
        /// Constructor de la clase Changuito, por defecto.
        /// </summary>
        private Changuito()
        {
            this.productos = new List<Producto>();
        }
        /// <summary>
        /// Constructor de la clase Changuito, con parametro.
        /// </summary>
        /// <param name="espacioDisponible"> valor int ingresado </param>
        public Changuito(int espacioDisponible):this()

        {
            this.espacioDisponible = espacioDisponible;
        }
        #endregion

        #region "Sobrecargas"
        /// <summary>
        /// Muestro el Changuito y TODOS los Productos
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Changuito.Mostrar(this, ETipo.Todos);
        }
        #endregion

        #region "Métodos"

        /// <summary>
        /// Expone los datos del elemento y su lista (incluidas sus herencias)
        /// SOLO del tipo requerido
        /// </summary>
        /// <param name="valorChango">Elemento a exponer</param>
        /// <param name="ETipo">Tipos de ítems de la lista a mostrar</param>
        /// <returns>Valor string</returns>
        public static string Mostrar(Changuito valorChango, ETipo tipo)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Tenemos {0} lugares ocupados de un total de {1} disponibles", valorChango.productos.Count, valorChango.espacioDisponible);
            sb.AppendLine("");
            foreach (Producto valorProducto in valorChango.productos)
            {
                switch (tipo)
                {
                    case ETipo.Snacks:
                        if(valorProducto is Snacks)
                            sb.AppendLine(valorProducto.Mostrar());
                        break;
                    case ETipo.Dulce:
                        if(valorProducto is Dulce)
                            sb.AppendLine(valorProducto.Mostrar());
                        break;
                    case ETipo.Leche:
                        if(valorProducto is Leche)
                            sb.AppendLine(valorProducto.Mostrar());
                        break;
                    default:
                        sb.AppendLine(valorProducto.Mostrar());
                        break;
                }
            }
            return sb.ToString();
        }
        #endregion

        #region "Operadores"
        /// <summary>
        /// Agregará un elemento a la lista
        /// </summary>
        /// <param name="valorChanguito">Objeto donde se agregará el elemento</param>
        /// <param name="valorProducto">Objeto a agregar</param>
        /// <returns>Tipo de valor Changuito</returns>
        public static Changuito operator +(Changuito valorChanguito, Producto valorProducto)
        {
            if(valorChanguito.productos.Count < valorChanguito.espacioDisponible)
            {
                foreach(Producto valorTemporal in valorChanguito.productos)
                {
                    if (valorTemporal == valorProducto)
                    {
                        return valorChanguito;
                    }
                }
                valorChanguito.productos.Add(valorProducto);
            }                       
            return valorChanguito;
        }
        /// <summary>
        /// Quitará un elemento de la lista
        /// </summary>
        /// <param name="valorChanguito">Objeto donde se quitará el elemento</param>
        /// <param name="valorProducto">Objeto a quitar</param>
        /// <returns>Tipo de valor Changuito</returns>
        public static Changuito operator -(Changuito valorChanguito, Producto valorProducto)
        {         

            foreach (Producto valorTemporal in valorChanguito.productos)
            {
                if (valorTemporal == valorProducto)
                {
                    valorChanguito.productos.Remove(valorProducto);
                    break;
                }
            }
            return valorChanguito;
        }
        #endregion
    }
}
