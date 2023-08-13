using com.calitha.goldparser;

namespace Calculadora
{
    public partial class Form1 : Form
    {
        MyParser parser;
        public Form1()
        {
            parser = new MyParser(Application.StartupPath + "Calcu.cgt");
            InitializeComponent();

        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            parser.Parse(txtEntrada.Text);
            txtResultado.Text = parser.resultado;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void txtEntrada_TextChanged(object sender, EventArgs e)
        {

        }
    }
}