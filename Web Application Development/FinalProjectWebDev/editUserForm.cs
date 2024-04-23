using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProjectWebDev
{
    public partial class editUserForm : Form
    {
        public editUserForm()
        {
            InitializeComponent();
        }


        //PUT request for Users
        private async void editUserbtn_Click(object sender, EventArgs e)
        {
            string UserID = editUsernameTextBox.Text;

            DateTime registerDate = DateTime.Parse(editRegisterDateTextBox.Text);
            DateTime dateOfBirth = DateTime.Parse(editDateOfBirthTextBox.Text);

            var data = new
            {
                userName = UserID,
                registerDate = registerDate,
                dateOfBirth = dateOfBirth,
                userRank =  editUserRankTextBox.Text,
                eloScore = editEloScoreTextBox.Text,
                displayName = editDisplayNameTextBox.Text,
            };

            var jsondata = JsonSerializer.Serialize(data);
            var content = new StringContent(jsondata, Encoding.UTF8, "application/json");

            using (HttpClient chessClient = new HttpClient())
            {
                try
                {
                    chessClient.BaseAddress = new Uri($"https://localhost:{WebAppFinal.port}/api/");
                    var response = await chessClient.PutAsync($"ChessUsers?UserName={UserID}", content);

                    response.EnsureSuccessStatusCode();

                    MessageBox.Show("User has been updated");
                }
                catch (HttpRequestException ex)
                {
                    MessageBox.Show("User not updated. Please enter the correct information");
                }
            }
        }
    }
}
