using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProjectWebDev
{
    public partial class editGameForm : Form
    {
        public editGameForm()
        {
            InitializeComponent();
        }

        //PUT request for Games
        private async void  editGameBtn_Click_1(object sender, EventArgs e)
        {
            string gameID = editGameIDoutlbl.Text;

            DateTime gameTime = DateTime.Parse(gameTimeTextbox.Text);

            var data = new
            {
                gameID = gameID,
                playerID1 = playerID1TextBox.Text,
                playerID2 = playerID2TextBox.Text,
                winningPlayer = winningPlayerTextBox.Text,
                losingPlayer = losingPlayerTextBox.Text,
                gameTime = gameTime,
            };

            var jsondata = JsonSerializer.Serialize(data);
            var content = new StringContent(jsondata, Encoding.UTF8, "application/json");

            using (HttpClient chessClient = new HttpClient())
            {
                try
                {
                    chessClient.BaseAddress = new Uri($"https://localhost:{WebAppFinal.port}/api/");
                    var response = await chessClient.PutAsync($"ChessGames?GameID={gameID}", content);

                    response.EnsureSuccessStatusCode();

                    MessageBox.Show("Game has been updated");
                }

                catch (HttpRequestException ex)
                {
                    MessageBox.Show("Game not updated. Please enter the correct information");
                }
            }
        }
    }
}
