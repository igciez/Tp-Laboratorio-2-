using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Universitario:Persona
    {
        #region Atributo

        protected int _legajo;

        #endregion
        #region Constructores

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Universitario()
        {
            this._legajo = 0;
        }

        /// <summary>
        /// Constructor con parametros
        /// </summary>
        /// <param name="legajo">valor para campo _legajo</param>
        /// <param name="nombre">valor para campos de la clase padre</param>
        /// <param name="apellido">valor para campos de la clase padre</param>
        /// <param name="dni">valor para campos de la clase padre</param>
        /// <param name="nacionalidad">valor para campos de la clase padre</param>
        public Universitario(int legajo,string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            :base(nombre,apellido,dni,nacionalidad)
        {
            this._legajo = legajo;
        }

        #endregion
        #region Metodos
        /// <summary>
        /// firma del metodo a implementar en clases derivadas
        /// </summary>
        /// <returns></returns>
        protected abstract string ParticiparEnClase();        

        /// <summary>
        /// Metodo virutal que Muestra el campo _legajo
        /// </summary>
        /// <returns>cadena de caracteres</returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
          
            sb.AppendLine(base.ToString());
            sb.AppendFormat("\nLegajo: {0}", this._legajo);

            return sb.ToString();
        }

        /// <summary>
        /// Sobreesctiura del metodo Equals(), para corroborar que el obj sea tipo universitario y tenga valores
        /// </summary>
        /// <param name="obj">valor a validar</param>
        /// <returns>resultado de la validacion con bool</returns>
        public override bool Equals(object obj)
        {
            return this.GetType() == obj.GetType();
        }

        #endregion
        #region SobreCargas
        /// <summary>
        /// Determina la igualdad entre dos objetos universidad
        /// </summary>
        /// <param name="pg1">primer objeto universidad a validar</param>
        /// <param name="pg2">segundo objeto universidad a validar</param>
        /// <returns></returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            return (pg1.Equals(pg2) && pg1.DNI == pg2.DNI || pg1._legajo == pg2._legajo);
        }

        /// <summary>
        /// Determina la desigualdad entre dos objetos universidad
        /// </summary>
        /// <param name="pg1">primer objeto universidad a validar</param>
        /// <param name="pg2">segundo objeto universidad a validar</param>
        /// <returns></returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 != pg2);
        }

        #endregion

    }
}
