using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2018
{
    /// <summary>
    /// La clase Producto no deberá permitir que se instancien elementos de este tipo.
    /// </summary>
    public abstract class Producto
    {
       public enum EMarca
       {
            Serenisima, Campagnola, Arcor, Ilolay, Sancor, Pepsico
       }
        private EMarca marca;
        private string codigoDeBarras;
        private ConsoleColor colorPrimarioEmpaque;

        public Producto(string patente, EMarca marca, ConsoleColor color)
        {
            this.codigoDeBarras = patente;
            this.marca = marca;
            this.colorPrimarioEmpaque = color;
        }
        /// <summary>
        /// ReadOnly: Retornará la cantidad de ruedas del vehículo
        /// </summary>
        protected abstract short CantidadCalorias {get;}        
                
        /// <summary>
        /// Publica todos los datos del Producto.
        /// </summary>
        /// <returns>string, resultante del casteo explicito</returns>
        public virtual string Mostrar()
        {
            return (string)this;
        }
        /// <summary>
        /// Genera un apendice que muestra, los campos, codigoDeBarras, marca y colorPrimarioEmpaque.
        /// </summary>
        /// <param name="valorProducto">valor tipo Producto ingresado</param>
        public static explicit operator string(Producto valorProducto)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CODIGO DE BARRAS: " + valorProducto.codigoDeBarras);
            sb.AppendLine("MARCA          : " + valorProducto.marca.ToString());
            sb.AppendLine("COLOR EMPAQUE  : " + valorProducto.colorPrimarioEmpaque.ToString());
            sb.AppendLine("---------------------");

            return sb.ToString();
        }

        /// <summary>
        /// Dos productos son iguales si comparten el mismo código de barras
        /// </summary>
        /// <param name="valorProductoUno">Primer valor Producto ingresado</param>
        /// <param name="valorProductoDos">Segundo valor Producto ingresado</param>
        /// <returns>bool resultante de la comparacion del campo codigo de barras</returns>
        public static bool operator ==(Producto valorProductoUno, Producto valorProductoDos)
        {
            return (valorProductoUno.codigoDeBarras == valorProductoDos.codigoDeBarras);
        }
        /// <summary>
        /// Dos productos son distintos si su código de barras es distinto
        /// </summary>
        /// <param name="valorProductoUno">Primer valor Producto ingresado</param>
        /// <param name="valorProductoDos">Segundo valor Producto ingresado</param>
        /// <returns></returns>
        public static bool operator !=(Producto valorProductoUno, Producto valorProductoDos)
        {
            return !(valorProductoUno.codigoDeBarras == valorProductoDos.codigoDeBarras);
        }


    }
}
