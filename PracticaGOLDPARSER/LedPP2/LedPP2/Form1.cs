using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LedPP2
{
    public partial class Form1 : Form

    {
        System.IO.Ports.SerialPort ArduinoPort;
        public Form1()
        {
            InitializeComponent();
            //crear Serial Port
            ArduinoPort = new System.IO.Ports.SerialPort();
            ArduinoPort.PortName = "COM5";  //sustituir por vuestro 
            ArduinoPort.BaudRate = 9600;
            ArduinoPort.Open();

            //vincular eventos
            this.FormClosing += Frm1_FormClosing;
            this.BtOFF_Click.Click += Button1_Click;
            this.BtON_Click.Click += Button2_Click;
        }
        private void Frm1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //cerrar puerto
            if (ArduinoPort.IsOpen) ArduinoPort.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            ArduinoPort.Write("b");
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            ArduinoPort.Write("a");
        }

    }
}
