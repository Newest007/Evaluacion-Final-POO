using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Evaluacion_Final_POO
{
    public partial class Form1 : Form
    {
        private List<Empleado> Empleados = new List<Empleado>(); //Lista en la que se guardarán los productos
        private DataTable Listaempleado = new DataTable(); //Aquí mostraremos la lista en el DGV
        private int edit_indice = -1;

        int NumEmpleados = 11; //Empleados + 1

        private void LlenarGrid() //Procedimiento que va a poner los datos del DataTable al DGV
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = Empleados;
        }

        private void BorrarErrores()
        {
            errorProvider1.SetError(txtnombres, "");
            errorProvider1.SetError(txtapellidos, "");
            errorProvider1.SetError(txtCorreo, "");
            errorProvider1.SetError(txtSueldo, "");
            errorProvider1.SetError(dateTimePicker1, "");
            errorProvider1.SetError(dateTimePicker2, "");
            errorProvider1.SetError(mstbxDUI, "");
            errorProvider1.SetError(mstbxCelular, "");

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
            if(mstbxCelular.Text == label13.Text)
            {
                validado = false;
                errorProvider1.SetError(mstbxCelular, "Ingrese el Tel.Celular");
            }
            if (txtCorreo.Text == "")
            {
                validado = false;
                errorProvider1.SetError(txtCorreo, "Ingrese el Correo");
            }
            if (txtSueldo.Text == "")
            {
                validado = false;
                errorProvider1.SetError(txtSueldo, "Ingrese el Sueldo");
            }
            if(mstbxDUI.Text == label14.Text)
            {
                validado = false;
                errorProvider1.SetError(mstbxDUI, "Ingrese el DUI");
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
            txtCorreo.Clear();
            txtSueldo.Clear();
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
            BorrarErrores();
            int ClicksRestantes = (NumEmpleados - 1);
            NumEmpleados = ClicksRestantes;

            if (ClicksRestantes <= 0)
            {
                btnNuevo.Visible = false;
                btnGuardar.Visible = false;
                MessageBox.Show("Acaba de agregar los 10 empleados", "Atención");
                btnActualizar.Visible = true;

            }
            else
            {
                if (validarCampos())
                {

                    if(dateTimePicker2.Value.Year > System.DateTime.Now.Year)
                    {
                        errorProvider1.SetError(dateTimePicker2, "Fecha Incorrecta");
                    }

                    if (dateTimePicker1.Value.Year > System.DateTime.Now.Year)
                    {
                        errorProvider1.SetError(dateTimePicker1, "Introduzca otra fecha");
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
                        double salbase = double.Parse(txtSueldo.Text);
                        double mrenta = salbase * 0.10;
                        double misss = salbase * 0.03;
                        double tdesc = mrenta + misss;

                        emp.NombreEmpleado = txtnombres.Text;
                        emp.MontoRenta = mrenta;
                        emp.MontoIsss = misss;
                        emp.TotalDescuentos = tdesc;
                        emp.SueldoBase = salbase;
                        emp.SueldoNeto = salbase - tdesc;

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
            dataGridView1.Visible = false;
            label13.Text = mstbxCelular.Text;
            label13.Visible = false;
            label14.Text = mstbxDUI.Text;
            label14.Visible = false;

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            btnGuardar.Visible = true;
            btnNuevo.Visible = false;
            groupBox1.Visible = true;
            groupBox2.Visible = true;
            txtnombres.Focus();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            btnActualizar.Visible = false;
            btnMostrar.Visible = true;
        }

        private void txtSueldo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar)) //Tecla de Borrado
            {
                e.Handled = false;
            }
            else if ((e.KeyChar == '.') && (!txtSueldo.Text.Contains("."))) 
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
                errorProvider1.SetError(txtSueldo, "Solo números");

            }
        }

        private void txtnombres_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
            else if(char.IsControl(e.KeyChar)) //Tecla de Borrado
            {
                e.Handled = false;
            }
            else if(char.IsWhiteSpace(e.KeyChar)) //Tecla de Espacio
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
                errorProvider1.SetError(txtnombres, "Son Nombres, no Nick's");
            }
        }

        private void txtapellidos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar)) //Tecla de Borrado
            {
                e.Handled = false;
            }
            else if (char.IsWhiteSpace(e.KeyChar)) //Tecla de Espacio
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
                errorProvider1.SetError(txtapellidos, "Son apellidos, no Nick's");
            }
        }
        
        public static bool validarEmail(string email)
        {
            string expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*"; 

            if(Regex.IsMatch(email,expresion))
            {
                if (Regex.Replace(email, expresion, string.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

        }
        
        private void txtCorreo_Leave(object sender, EventArgs e)
        {
            if (validarEmail(txtCorreo.Text)) { }
            
            else
            {
                errorProvider1.SetError(txtCorreo, "Direccion de Correo Invalida");
                txtCorreo.SelectAll();
                txtCorreo.Focus();
            }
            
        }
    }
}
