using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace ClasesInstanciables
{
    public sealed class Alumno:Universitario
    {
        #region Enumerados

        public enum EEstadoCuenta
        {
            AlDia,
            Deudor,
            Becado
        }

        #endregion
        #region Atributos

        private Universidad.EClases _claseQueToma;
        private EEstadoCuenta _estadoCuenta;

        #endregion
        #region Constructores

        /// <summary>
        /// constructor por defecto
        /// </summary>
        public Alumno() : base()
        {
            this._claseQueToma = default(Universidad.EClases);
            this._estadoCuenta = default(EEstadoCuenta);
        }

        /// <summary>
        /// Constructor con parametros
        /// </summary>
        /// <param name="id">valor para  clase base</param>
        /// <param name="nombre">valor para  clase base</param>
        /// <param name="apellido">valor para  clase base</param>
        /// <param name="dni">valor para  clase base</param>
        /// <param name="nacionalidad">valor para  clase base</param>
        /// <param name="claseQueToma">valor para campo _claseQueToma</param>
        public Alumno(int id, string nombre,string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma)
            :base(id,nombre,apellido,dni,nacionalidad)
        {
            this._claseQueToma = claseQueToma;            
        }

        /// <summary>
        /// Constructor con parametros
        /// </summary>
        /// <param name="id">valor para  clase base</param>
        /// <param name="nombre">valor para  clase base</param>
        /// <param name="apellido">valor para  clase base</param>
        /// <param name="dni">valor para  clase base</param>
        /// <param name="nacionalidad">valor para  clase base</param>
        /// <param name="claseQueToma">valor para campo _claseQueToma</param>
        /// <param name="estadoCuenta">valor para campo _estadoCuenta</param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad,Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta)
            :this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this._estadoCuenta = estadoCuenta;
        }

        #endregion
        #region SobreCargas

        /// <summary>
        /// Metodo que sobrescribe clase base
        /// </summary>
        /// <returns>Cadena de string con los datos del alumno</returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            
            sb.AppendLine(base.MostrarDatos());           
            
            switch (this._estadoCuenta)
            {
                case EEstadoCuenta.AlDia:
                    sb.AppendLine("\nEstado de Cuenta: Cuota al dia");
                    break;                          
                case EEstadoCuenta.Becado:
                    sb.AppendLine("\nEstado de Cuenta: Becado");
                    break;
                case EEstadoCuenta.Deudor:
                    sb.AppendLine("\nEstado de Cuenta:Deudor");
                    break;
                default:
                    break;
            }

            sb.AppendLine(this.ParticiparEnClase());

            return sb.ToString();
        }

        /// <summary>
        /// Metodo que Muestra la clase de eleccion por el alumno.
        /// </summary>
        /// <returns>string con los datos del campo _claseQueToma</returns>
        protected override string ParticiparEnClase()
        {
            return String.Format("\nToma clase de: {0}",this._claseQueToma.ToString());
        }

        /// <summary>
        /// Sobreescribe el metodo ToString()
        /// </summary>
        /// <returns>Hace publico metodo MostrarDatos</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        /// <summary>
        /// Metodo que determina la igualdad de sus paramentros
        /// </summary>
        /// <param name="a">Valor Alumno</param>
        /// <param name="clase">Universida EClase</param>
        /// <returns></returns>
        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {                     
           return (a._claseQueToma == clase && a._estadoCuenta != EEstadoCuenta.Deudor); 
        }

        /// <summary>
        /// Metodo que determina la desigualdad de sus paramentros
        /// </summary>
        /// <param name="a">Valor Alumno</param>
        /// <param name="clase">Universida EClase</param>
        /// <returns></returns>
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            return (a._claseQueToma != clase);
        }
        #endregion
    }
}
