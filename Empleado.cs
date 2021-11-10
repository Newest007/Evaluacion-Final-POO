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
        string correo;
        string tel;
        string dui;
        double mrenta;
        double misss;
        double tdescuentos;
        double sbase;
        double sneto;

        //Propiedades de acceso

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public string Correo
        {
            get { return correo; }
            set { correo = value; }
        }
        public string Tel
        {
            get { return tel; }
            set { tel = value; }
        }
        public string Dui
        {
            get { return dui; }
            set { dui = value; }
        }
        public double Mrenta
        {
            get { return mrenta; }
            set { mrenta = value; }
        }
        public double Misss
        {
            get { return misss; }
            set { misss = value; }
        }
        public double Tdescuentos
        {
            get { return tdescuentos; }
            set { tdescuentos = value; }
        }
        public double Sbase
        {
            get { return sbase; }
            set { sbase = value; }
        }
        public double Sneto
        {
            get { return sneto; }
            set { sneto = value; }
        }

    }
}
