﻿using System;
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
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            
        }

        private void venatnasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void servidorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 newMDIChild = new Form2();
            // Set the Parent Form of the Child window.
            newMDIChild.MdiParent = this;
            // Display the new form.
            newMDIChild.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 newMDIChild = new Form3();
            // Set the Parent Form of the Child window.
            newMDIChild.MdiParent = this;
            // Display the new form.
            newMDIChild.Show();

        }

        private void archivosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
