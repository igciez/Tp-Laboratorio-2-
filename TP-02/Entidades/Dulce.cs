using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2018
{
    public class Dulce : Producto
    {
        /// <summary>
        /// Constructor de la clase Dulce, con herencia de la clase Producto.
        /// </summary>
        /// <param name="marca">Valor EMarca ingresado</param>
        /// <param name="patente">Valor string ingresado</param>
        /// <param name="color">Valor ConsoleColor ingresado</param>
        public Dulce(EMarca marca, string patente, ConsoleColor color)
            :base(patente,marca,color)
        {
       
        }

        /// <summary>
        /// Los dulces tienen 80 calorías
        /// </summary>
        protected override short CantidadCalorias
        {
            get
            {
                return 80;
            }
        }
        /// <summary>
        /// sobreescritura del metodo Mostrar, de la clase Producto.
        /// </summary>
        /// <returns>Un apendice por consola</returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("DULCE");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("CALORIAS : {0}", this.CantidadCalorias);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
