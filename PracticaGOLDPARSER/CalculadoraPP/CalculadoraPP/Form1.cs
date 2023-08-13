using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using com.calitha.goldparser;

namespace CalculadoraPP
{
    public partial class Form1 : Form
    {
        MyParser parser;
        public Form1()
        {
            InitializeComponent();
            parser = new MyParser(Application.StartupPath+ "\\CalculadoraCientificaV2.cgt");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            parser.Parse(txtEntrada.Text);
            txtEntrada.Text = parser.resultado;
        }
    }
}
