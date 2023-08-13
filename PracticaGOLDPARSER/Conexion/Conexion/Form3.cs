using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace Conexion
{
    
    public partial class Form3 : Form
    {
        SerialPort SerialPort1 = new SerialPort();
        public Form3()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
            foreach (string ListaSerialPorts in SerialPort.GetPortNames()) 
            {
                comboBox1.Items.Add(ListaSerialPorts);
            }
            SerialPort1.DataReceived += new
                SerialDataReceivedEventHandler(SerialPort1_DataReceived);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SerialPort1.PortName = comboBox1.Text;
            try
            {
                SerialPort1.Open();
            }
            catch 
            {
                MessageBox.Show("Puerto no valido");
                return;
            }
            comboBox1.Enabled = false;
        }

        private void SerialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            string dato_reciv = SerialPort1.ReadExisting();
            label4.Text = dato_reciv;
            textBox2.Text = dato_reciv.Trim();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SerialPort1.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SerialPort1.Write(textBox1.Text.ToString());
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
