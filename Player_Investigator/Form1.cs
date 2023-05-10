using System.Drawing.Text;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Player_Investigator
{
    public partial class Form1 : Form
    {
        Queryer? queryer;

        Calculator? calculator;

        string key = "4DA0CD7EC93E4167D233CCF091DD4B8F"; //Remove
        string steamID = "76561197960434622"; //"Valve employee"
        //string steamID = "76561199502029751";

        //string steamID = "76561198271851487"; //"nomsies"
        //string steamID = "76561198271791346"; //"kezosi"

        //string steamID = "76561198963674526"; //"asdfg"
        //string steamID = "76561198259415370"; //"aaaaa"
        //Form functions

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            queryer = new Queryer(key, steamID);

            UserInfo? userInfo = await queryer.GetAll();

            richTextBox1.Text = queryer.output;

            if (userInfo is null || userInfo.visible == 1)
            {
                return;
            }

            calculator = new Calculator(userInfo);

            /*double percentage = */calculator.CheckSmurfAccount("CS:GO");

            richTextBox1.Text += calculator.output;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}