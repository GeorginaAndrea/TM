namespace Chat

{
   
    public partial class Form1 : Form
    {
        SerialPort SerialPort1 = new SerialPort();

        public Form1()
             
        {
            
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
            foreach (String ListaSerialPorts in SerialPort.GetPortNames)){
                comboBox1.Items.Add(ListaSerialPorts);
            }
            SerialPort1.DataReceived += new;
            SerialDataReceivedEventHandler(SerialPort1DataReceived);

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SerialPort1.PortName = comboBox1.Text;
            try {
                SerialPort1.Open();
            }catch {
                MessageBox.Show("Puerto no valido");
                return;
            }
            comboBox1.Enabled= false;
        }
    }
}