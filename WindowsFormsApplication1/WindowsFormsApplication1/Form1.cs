using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.IO.Ports;
using System.Drawing;
using MySql.Data.MySqlClient;
using System.Threading;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        byte[] sensorResponse = new byte[1];
        MySqlCommand command;
        MySqlDataAdapter adapter = new MySqlDataAdapter();
        MySqlConnection cnn;
        string sql = string.Empty;
        int extValue;
        int intValue;
        int inputValue;
        public Form1()
        {
            InitializeComponent();
            string ConnectionString;
            ConnectionString = "server=localhost;user id=root;password=Qwerty123;persistsecurityinfo=True;database=mydb";
            cnn = new MySqlConnection(ConnectionString);
            cnn.Open();
        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
            int num;
            comboBox1.Items.Clear();
            string[] ports = SerialPort.GetPortNames().OrderBy(a => a.Length > 3 && int.TryParse(a.Substring(3), out num) ? num : 0).ToArray();
            comboBox1.Items.AddRange(ports);
        }

        private void buttonOpenPort_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
                try
                {
                    serialPort1.PortName = comboBox1.Text;
                    serialPort1.Open();
                    buttonOpenPort.Text = "Close";
                    comboBox1.Enabled = false;
                }
                catch (Exception mycustomex)
                {
                    MessageBox.Show("Port " + comboBox1.Text + " is invalid!" + mycustomex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            else
            {
                serialPort1.Close();
                buttonOpenPort.Text = "Open";
                comboBox1.Enabled = true;
            }
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            Thread.Sleep(20);
            int bytes = serialPort1.BytesToRead;
            byte[] buffer = new byte[bytes];
            byte[] response = new byte[1];
            serialPort1.Read(buffer, 0, bytes);
            if (BitConverter.IsLittleEndian)
                Array.Reverse(buffer);
            if (bytes == 6)
            {
                inputValue = BitConverter.ToInt16(buffer.Skip(0).Take(2).ToArray(), 0);
                intValue = BitConverter.ToInt16(buffer.Skip(2).Take(2).ToArray(), 0);
                extValue = BitConverter.ToInt16(buffer.Skip(4).Take(2).ToArray(), 0);
                Console.WriteLine("ext: {0} int: {1} input: {2}", extValue, intValue, inputValue);
                if (inputValue > 1000 || inputValue < 0) inputValue = 0;
                SetBar3Val(extValue);
                Setlabel2Val(intValue.ToString());
                SetBar1Val(intValue);
                Setlabel3Val(extValue.ToString());
                if (extValue < inputValue && panel1.BackColor == Color.DarkSlateGray)
                {
                    SendCommand("insert into indoor_light_status(is_enabled,date,time) values(1,CURDATE(),CURTIME())");
                    panel1.BackColor = Color.LightGoldenrodYellow;
                }
                else if (extValue >= inputValue && panel1.BackColor == Color.LightGoldenrodYellow)
                {
                    SendCommand("insert into indoor_light_status(is_enabled,date,time) values(0,CURDATE(),CURTIME())");
                    panel1.BackColor = Color.DarkSlateGray;
                }
                SendCommand($"insert into light_measurements(registered_time,date,inside,outside) values(CURTIME(),CURDATE(),{intValue},{extValue})");
            }
            else if (bytes == 2)
            {
                inputValue = BitConverter.ToInt16(buffer, 0);
                Console.WriteLine("input value: {0}", inputValue);
                if (inputValue > 1000 || inputValue < 0) inputValue = 0;
                SetBar2Val(inputValue);
                Setlabel4Val(inputValue.ToString());
                if (extValue < inputValue && panel1.BackColor == Color.DarkSlateGray)
                {
                    SendCommand("insert into indoor_light_status(is_enabled,date,time) values(1,CURDATE(),CURTIME())");
                    panel1.BackColor = Color.LightGoldenrodYellow;
                    sensorResponse[0] = 0xA1;
                    serialPort1.Write(sensorResponse, 0, 1);
                }
                else if (extValue >= inputValue && panel1.BackColor == Color.LightGoldenrodYellow)
                {
                    sensorResponse[0] = 0xB1;
                    serialPort1.Write(sensorResponse, 0, 1);
                    SendCommand("insert into indoor_light_status(is_enabled,date,time) values(0,CURDATE(),CURTIME())");
                    panel1.BackColor = Color.DarkSlateGray;
                }
            }
        }

        private void SendCommand(string commands)
        {
            adapter.InsertCommand = new MySqlCommand(commands, cnn);
            adapter.InsertCommand.ExecuteNonQuery();
            adapter.Dispose();
        }

        string today_average()
        {
            sql = "SELECT AVG(outside) as average FROM mydb.light_measurements where date = current_date() group by date;";

            command = new MySqlCommand(sql, cnn);

            adapter.InsertCommand = new MySqlCommand(sql, cnn);

            MySqlDataReader reader1;
            reader1 = command.ExecuteReader();
            string response = "0";
            if (reader1.Read())
            {
                response = reader1["average"].ToString();
            }
            Console.WriteLine(response);
            reader1.Close();
            adapter.Dispose();
            command.Dispose();
            float kk = float.Parse(response);
            return Math.Floor(kk).ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SetButtonVal(today_average());
        }
    }
}
