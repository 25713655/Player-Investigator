using System.Drawing.Text;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Player_Investigator
{
    public partial class Form1 : Form
    {
        Queryer? queryer;

        Calculator? calculator;

        string key, steamID, game;

        //Form functions

        public Form1()
        {
            InitializeComponent();

            key = "";
            steamID = "";
            game = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            errorTextBox.Text = "";
            ratingBar.Value = 0;
            percentageTextBox.Text = "";
            usernameTextBox.Text = "";
            playtimeTextBox.Text = "";
            createdTextBox.Text = "";

            key = keyTextBox.Text;
            steamID = IDTextBox.Text;
            game = gameSelection.Text;
            if (game != "CS:GO" && game != "Dota 2" && game != "Apex Legends")
            {
                errorTextBox.Text = "Invalid game selection.";
                return;
            }

            queryer = new Queryer(key, steamID);

            UserInfo? userInfo = await queryer.GetAll();

            if (userInfo is null)
            {
                errorTextBox.Text = "Unable to retrieve information.";
                return;
            }
            else if (userInfo.visible == 1)
            {
                errorTextBox.Text = "Profile is private.";
            }
            else
            {
                calculator = new Calculator(userInfo);

                double percentage = calculator.CheckSmurfAccount(game);
                percentageTextBox.Text = $"Calculated percentage: {percentage}%";
                ratingBar.Value = (int)percentage;

                usernameTextBox.Text = $"Username: {userInfo.username}";

                if (game == "CS:GO")
                {
                    if (userInfo.CSGOPlaytimeForever == 0)
                    {
                        errorTextBox.Text = "User has never played CS:GO.";
                        percentageTextBox.Text = $"Calculated percentage: 0%";
                        ratingBar.Value = 0;
                    }
                    playtimeTextBox.Text = $"Playtime: {userInfo.CSGOPlaytimeForever / 60} hours";
                }
                else if (game == "Dota 2")
                {
                    if (userInfo.Dota2PlaytimeForever == 0)
                    {
                        errorTextBox.Text = "User has never played Dota 2.";
                        percentageTextBox.Text = $"Calculated percentage: 0%";
                        ratingBar.Value = 0;
                    }
                    playtimeTextBox.Text = $"Playtime: {userInfo.Dota2PlaytimeForever / 60} hours";
                }
                else if (game == "Apex Legends")
                {
                    if (userInfo.ApexPlaytimeForever == 0)
                    {
                        errorTextBox.Text = "User has never played Apex Legends.";
                        percentageTextBox.Text = $"Calculated percentage: 0%";
                        ratingBar.Value = 0;
                    }
                    playtimeTextBox.Text = $"Playtime: {userInfo.ApexPlaytimeForever / 60} hours";
                }

                createdTextBox.Text = $"Date created: {userInfo.timeCreated}";
            }
        }
    }
}