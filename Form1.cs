
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;



namespace CRUD.WindowsForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Bd.Conexion();
            MessageBox.Show(" Se a conectado correctamente");

            dataGridView1.DataSource = Consulta();
        }

        public DataTable Consulta()

        {
            Bd.Conexion();
            DataTable datos = new DataTable();
            string consultar = " SELECT * FROM Empleado";
            SqlCommand cmd = new SqlCommand(consultar, Bd.Conexion());
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(datos);
            return datos;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bd.Conexion();
            string insertar = " INSERT INTO Empleado(codigo,nombre,apellido,direccion) VALUES (@codigo,@nombre,@apellido,@direccion)";

            SqlCommand inseret = new SqlCommand(insertar, Bd.Conexion());
            inseret.Parameters.AddWithValue("@codigo", textBox1.Text);
            inseret.Parameters.AddWithValue("@nombre", textBox2.Text);
            inseret.Parameters.AddWithValue("@apellido", textBox3.Text);
            inseret.Parameters.AddWithValue("@direccion", textBox4.Text);

            inseret.ExecuteNonQuery();

            MessageBox.Show(" Se a agregado correctamente");
            dataGridView1.DataSource = Consulta();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Verifica que se haya seleccionado una fila válida
            {
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value?.ToString() ?? string.Empty;
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value?.ToString() ?? string.Empty;
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value?.ToString() ?? string.Empty;
                textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value?.ToString() ?? string.Empty;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Bd.Conexion();
            string update = " UPDATE Empleado SET codigo=@codigo,nombre=@nombre,apellido=@apellido,direccion=@direccion where codigo=@codigo";

            SqlCommand actualizar = new SqlCommand(update, Bd.Conexion());
            actualizar.Parameters.AddWithValue("@codigo", textBox1.Text);
            actualizar.Parameters.AddWithValue("@nombre", textBox2.Text);
            actualizar.Parameters.AddWithValue("@apellido", textBox3.Text);
            actualizar.Parameters.AddWithValue("@direccion", textBox4.Text);

            actualizar.ExecuteNonQuery();

            MessageBox.Show(" Actualizado correctamente");
            dataGridView1.DataSource = Consulta();



        }

        private void button3_Click(object sender, EventArgs e)
        {
            Bd.Conexion();

            string delete = "DELETE FROM Empleado WHERE codigo=@codigo";
            SqlCommand eliminar = new SqlCommand(delete, Bd.Conexion());
            eliminar.Parameters.AddWithValue("@codigo", textBox1.Text);
            eliminar.ExecuteNonQuery();

            MessageBox.Show(" Eliminado correctamente");
            dataGridView1.DataSource = Consulta();


        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox1.Focus();
        }
    }
}
