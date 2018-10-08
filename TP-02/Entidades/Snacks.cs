using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2018
{
    public class Snacks:Producto
    {
        /// <summary>
        /// Cosntructor de la clase Snacks, con herencia de la clase Producto.
        /// </summary>
        /// <param name="marca">valor tipo EMarca ingresado</param>
        /// <param name="patente">valor tipo string ingresado</param>
        /// <param name="color">valor tipo ConsoleColer ingresado</param>
        public Snacks(EMarca marca, string patente, ConsoleColor color)
            : base(patente, marca, color)
        {
        }
        /// <summary>
        /// Los snacks tienen 104 calorías
        /// </summary>
        protected override short CantidadCalorias
        {
            get
            {
                return 104;
            }
        }
        /// <summary>
        /// sobreescritura del metodo Mostrar, de la clase base.
        /// </summary>
        /// <returns>valor string</returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SNACKS");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("CALORIAS : {0}", this.CantidadCalorias);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
