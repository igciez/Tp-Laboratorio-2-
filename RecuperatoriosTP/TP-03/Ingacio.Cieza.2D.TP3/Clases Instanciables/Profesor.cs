using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace ClasesInstanciables
{
    public sealed class Profesor:Universitario
    {
        #region Atributos

        private Queue<Universidad.EClases> _claseDelDia;
        private static Random _random;

        #endregion
        #region Constructores
        /// <summary>
        /// Constructor de clase que inicializa Random
        /// </summary>
        static Profesor()
        {
            Profesor._random = new Random();
        }

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Profesor():base()
        {   
        }

        /// <summary>
        /// Constructor con parametros, asigna clase del dia y metodo random
        /// </summary>
        /// <param name="id">valor para la clase base</param>
        /// <param name="nombre">valor para la clase base</param>
        /// <param name="apellido">valor para la clase base</param>
        /// <param name="dni">valor para la clase base</param>
        /// <param name="nacionalidad">valor para la clase base</param>
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            :base(id,nombre,apellido,dni,nacionalidad)           
        {
            this._claseDelDia = new Queue<Universidad.EClases>();
            this._randomClase();
        }

        #endregion
        #region Metodos

        /// <summary>
        /// Metodo que asigna al azar dos clase a clase del dia.
        /// </summary>
        private void _randomClase()
        {
            for (int i = 0; i < 2; i++)
            {
                this._claseDelDia.Enqueue((Universidad.EClases)Profesor._random.Next(0, 3));
            }
        }

        #endregion
        #region SobreCargas
        /// <summary>
        /// sobreescritura del Metodo base MostrarDatos(), muestra datos del profesor
        /// </summary>
        /// <returns>string</returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            
            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine(this.ParticiparEnClase());
            

            return sb.ToString();
        }

        /// <summary>
        /// sobreescritura del metodo base ParticiparClase, muestra la clase del dia
        /// </summary>
        /// <returns>string</returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("\nClase del dia:");

            foreach(Universidad.EClases temporal in this._claseDelDia)
            {
                sb.AppendLine(temporal.ToString());
            }

            return sb.ToString();

        }
        /// <summary>
        /// Hace publico el metodo MostrarDatos()
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        /// <summary>
        /// Metodo que determina la igualdad entre dos parametros
        /// </summary>
        /// <param name="i">Valor a comparar Profesor</param>
        /// <param name="clase">Valor a compar EClase</param>
        /// <returns>Bool</returns>
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            foreach (Universidad.EClases claseDelProfesor in i._claseDelDia)
            {
                if (claseDelProfesor == clase)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Metodo que determina la desigualdad entre dos parametros
        /// </summary>
        /// <param name="i">Valor a comparar Profesor</param>
        /// <param name="clase">Valor a compar EClase</param>
        /// <returns>Bool</returns>
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }

        #endregion
    }
}
