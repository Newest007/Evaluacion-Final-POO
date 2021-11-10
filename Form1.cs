using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Evaluacion_Final_POO
{
    public partial class Form1 : Form
    {
        private List<Empleado> Empleados = new List<Empleado>(); //Lista en la que se guardarán los productos
        private DataTable Listaempleado = new DataTable(); //Aquí mostraremos la lista en el DGV
        private int edit_indice = -1;

        private void LlenarGrid() //Procedimiento que va a poner los datos del DataTable al DGV
        {
            Listaempleado.Rows.Clear();
            foreach (Empleado emp in Empleados)
            {
                Listaempleado.Rows.Add(emp.Nombre, emp.Mrenta, emp.Misss, emp.Tdescuentos, emp.Sbase, emp.Sneto);
            }
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = Listaempleado;

        }

        private void limpiarcampos()
        {
            txtnombres.Clear();
            txtapellidos.Clear();
            //Aqui va la limpieza del dateTimePicker1
            //Aqui va la limpieza del dateTimePicker2
            maskedTextBox1.Clear();
            maskedTextBox2.Clear();
            textBox2.Clear();
            textBox1.Clear();
            //Aqui va la limpieza del numericUpDown1
            //Aqui va la limpieza del numericUpDown1
            txtnombres.Focus();
        }

        public Form1()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Empleado emp = new Empleado();

            double procentRent = (double)numericUpDown1.Value;
            double porcentIss = (double)numericUpDown2.Value;
            double salbase = double.Parse(textBox1.Text);
            double mrenta = salbase * 0.10;
            double misss = salbase * 0.03;
            double tdesc = mrenta + misss; 

            emp.Nombre = txtnombres.Text;
            emp.Apellido = txtapellidos.Text;
            emp.Naciemiento = dateTimePicker1.Value;
            emp.Dui = maskedTextBox1.Text;
            emp.Tel = maskedTextBox2.Text;
            emp.Correo = textBox2.Text;
            emp.Fcontrato = dateTimePicker2.Value;
            emp.Sbase = salbase;
            emp.Mrenta = mrenta;
            emp.Misss = misss;
            emp.Tdescuentos = tdesc;
            emp.Sneto = salbase - tdesc;

            if (edit_indice > -1)
            {
                Empleados[edit_indice] = emp;
                edit_indice = -1;
            }
            else
            {
                Empleados.Add(emp);
            }

            limpiarcampos();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LlenarGrid();
        }
    }
}
