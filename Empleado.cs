using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluacion_Final_POO
{
    class Empleado
    {

        //Atributos
        string nombre;
        double mrenta;
        double misss;
        double tdescuentos;
        double sbase;
        double sneto;

        //Propiedades de acceso

        public string NombreEmpleado
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public double MontoRenta
        {
            get { return mrenta; }
            set { mrenta = value; }
        }
        public double MontoIsss
        {
            get { return misss; }
            set { misss = value; }
        }
        public double TotalDescuentos
        {
            get { return tdescuentos; }
            set { tdescuentos = value; }
        }
        public double SueldoBase
        {
            get { return sbase; }
            set { sbase = value; }
        }
        public double SueldoNeto
        {
            get { return sneto; }
            set { sneto = value; }
        }

    }
}
