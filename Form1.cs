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

        int NumEmpleados = 10;

        private void LlenarGrid() //Procedimiento que va a poner los datos del DataTable al DGV
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = Empleados;
        }

        private bool validarCampos() //Pro edimiento para validar campos
        {
            bool validado = true;
            if (txtnombres.Text == "")
            {
                validado = false;
                errorProvider1.SetError(txtnombres, "Ingresar el Nombre");
            }

            if (txtapellidos.Text == "")
            {
                validado = false;
                errorProvider1.SetError(txtapellidos, "Ingresar el Apellido");
            }
            if(mstbxDUI.Text == "")
            {
                validado = false;
                errorProvider1.SetError(mstbxDUI, "Ingrese el DUI");
            }
            if(mstbxCelular.Text == "")
            {
                validado = false;
                errorProvider1.SetError(mstbxCelular, "Ingrese su Tel.Celular");
            }

            return validado;
        }

        private void limpiarcampos()
        {
            txtnombres.Clear();
            txtapellidos.Clear();
            //Aqui va la limpieza del dateTimePicker1
            //Aqui va la limpieza del dateTimePicker2
            mstbxDUI.Clear();
            mstbxCelular.Clear();
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

            int ClicksRestantes = (NumEmpleados - 1);
            NumEmpleados = ClicksRestantes;

            if (ClicksRestantes <= 0)
            {
                btnNuevo.Visible = false;
                btnGuardar.Visible = false;
                MessageBox.Show("Acaba de agregar los 10 empleados", "Atención");

            }
            else
            {


                if (validarCampos())
                {
                    if (dateTimePicker1.Value.Year > System.DateTime.Now.Year)
                    {
                        MessageBox.Show("Prueba con un año anterior al presente", "Al parecer vienes del futuro :O");
                        //Application.Restart();
                    }
                    if (dateTimePicker1.Value.Year <= 1971 || dateTimePicker1.Value.Year >= 2004)
                    {
                        MessageBox.Show("Solo se aceptan empleados con edades con un intervalo de 18 a 50 años", "Prueba de nuevo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    else
                    {
                        //====================================================================//
                        Empleado emp = new Empleado();

                        double procentRent = (double)numericUpDown1.Value;
                        double porcentIss = (double)numericUpDown2.Value;
                        double salbase = double.Parse(textBox1.Text);
                        double mrenta = salbase * 0.10;
                        double misss = salbase * 0.03;
                        double tdesc = mrenta + misss;

                        emp.Nombre = txtnombres.Text;
                        emp.Mrenta = mrenta;
                        emp.Misss = misss;
                        emp.Tdescuentos = tdesc;
                        emp.Sbase = salbase;
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
                        //====================================================================//

                        MessageBox.Show("Sus datos se han ingresado correctamente", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnNuevo.Visible = true;
                        btnGuardar.Visible = false;
                    }

                }



            }


            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LlenarGrid();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnActualizar.Visible = false;
            btnGuardar.Visible = false;
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            btnMostrar.Visible = false;

        }
    }
}
