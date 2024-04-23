using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;
using System.Net.Http.Headers;
using System.Linq.Expressions;

namespace FinalProjectWebDev
{
    public partial class WebAppFinal : Form
    {
        public const int port = 7242;   //variable to hold the local host port
        
        public WebAppFinal()
        {
            InitializeComponent();
        }

        //GET request for games
        private async void gamesGetBtn_Click(object sender, EventArgs e)
        {
            using (HttpClient chessClient = new HttpClient())
            {
                try
                {
                    chessClient.BaseAddress = new Uri($"https://localhost:{port}/api/");

                    chessClient.DefaultRequestHeaders.Add("User_Agent", "CIS411FinalAssignment");
                    chessClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    string gameID = gamesSearchTextBox.Text;
                    System.IO.Stream pageinfo = null;
                    var response = await chessClient.GetAsync($"ChessGames?GameID={gameID}");

                    response.EnsureSuccessStatusCode();
                    pageinfo = await response.Content.ReadAsStreamAsync();
                    editGamebtn.Enabled = true;
                    createGamebtn.Enabled = false;
                    newGameLogbtn.Enabled = true;

                    ChessGames chessGame = JsonSerializer.Deserialize<ChessGames>(pageinfo);

                    player1Outlbl.Text = chessGame.playerID1;
                    player2outlbl.Text = chessGame.playerID2;
                    winningPlayerOutlbl.Text = chessGame.winningPlayer;
                    losingPlayerOutlbl.Text = chessGame.losingPlayer;
                    gameTimeOutlbl.Text = "" + chessGame.gameTime;
                    newGameLogIDTextBox.Text = gamesSearchTextBox.Text;
                }
                catch (HttpRequestException err)
                {
                    MessageBox.Show($"Game does not exist");
                    editGamebtn.Enabled = false;
                    createGamebtn.Enabled = true;
                    newGameLogbtn.Enabled = false;
                    newGameLogIDTextBox.Text = "";
                }
            }
        }


        //Model for games
        public class ChessGames
        {
            public int gameID { get; set; }
            public string playerID1 { get; set; }
            public string playerID2 { get; set; }
            public string winningPlayer { get; set; }
            public string losingPlayer { get; set; }
            public DateTime gameTime { get; set; }
        }


        //PUT request for games from popup window
        private void editGamebtn_Click(object sender, EventArgs e)
        {
            editGameForm editGameForm = new editGameForm();

            editGameForm.Controls.Find("playerID1TextBox", true)[0].Text = player1Outlbl.Text;
            editGameForm.Controls.Find("playerID2TextBox", true)[0].Text = player2outlbl.Text;
            editGameForm.Controls.Find("winningPlayerTextBox", true)[0].Text = winningPlayerOutlbl.Text;
            editGameForm.Controls.Find("losingPlayerTextBox", true)[0].Text = losingPlayerOutlbl.Text;
            editGameForm.Controls.Find("gameTimeTextbox", true)[0].Text = gameTimeOutlbl.Text;
            editGameForm.Controls.Find("editGameIDoutlbl", true)[0].Text = gamesSearchTextBox.Text;

            editGameForm.Show();
        }


        //POST request for games
        private async void createGamebtn_Click(object sender, EventArgs e)
        {
            DateTime gameTime = DateTime.Parse(gameTimeTextbox.Text);

            var data = new
            {
                gameID = 0,
                playerID1 = playerID1TextBox.Text,
                playerID2 = playerID2TextBox.Text,
                winningPlayer = winningPlayerTextBox.Text,
                losingPlayer = losingPlayerTextBox.Text,
                gameTime = gameTime
            };

            var jsondata = JsonSerializer.Serialize(data);
            var content = new StringContent(jsondata, Encoding.UTF8, "application/json");

            using (HttpClient chessClient = new HttpClient())
            {
                try
                {
                    chessClient.BaseAddress = new Uri($"https://localhost:{port}/api/");
                    var response = await chessClient.PostAsync($"ChessGames?GameID=0", content);

                    response.EnsureSuccessStatusCode();

                    MessageBox.Show("New Game Created");
                    newGameLogbtn.Enabled = true;
                    gamesSearchTextBox.Text = "";
                }
                catch (HttpRequestException err)
                {
                    MessageBox.Show("New game not created. Please fill in all fields");
                    newGameLogbtn.Enabled = false;
                }
            }
        }


        //GET Request for Users
        private async void getUserbtn_Click(object sender, EventArgs e)
        {
            using (HttpClient chessClient = new HttpClient())
            {
                try
                {
                    chessClient.BaseAddress = new Uri($"https://localhost:{port}/api/");

                    chessClient.DefaultRequestHeaders.Add("User_Agent", "CIS411FinalAssignment");
                    chessClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    string UserID = userIDTextBox.Text;
                    System.IO.Stream pageinfo = null;
                    var response = await chessClient.GetAsync($"ChessUsers?UserName={UserID}");
                    response.EnsureSuccessStatusCode();
                    pageinfo = await response.Content.ReadAsStreamAsync();
                    editUserbtn.Enabled = true;
                    deleteUserbtn.Enabled = true;
                    button1.Enabled = false;

                    ChessUser chessUser = JsonSerializer.Deserialize<ChessUser>(pageinfo);

                    usernameOutlbl.Text = chessUser.userName;
                    RegisterDateOutlbl.Text = "" + chessUser.registerDate;
                    dateOfBirthOutlbl.Text = "" + chessUser.dateOfBirth;
                    userRankOutlbl.Text = chessUser.userRank;
                    eloScoreOutlbl.Text = "" + chessUser.eloScore;
                    displayNameOutlbl.Text = chessUser.displayName;
                }
                catch (HttpRequestException err)
                {
                    MessageBox.Show($"User Not Found");
                    editUserbtn.Enabled = false;
                    deleteUserbtn.Enabled = false;
                    button1.Enabled = true;
                    newUsernameTextBox.Text = userIDTextBox.Text;
                }
            }
        }


        //Model for users
        public class ChessUser
        {
            public string userName { get; set; }
            public DateTime registerDate { get; set; }
            public DateTime dateOfBirth { get; set; }
            public string userRank { get; set; }
            public int eloScore { get; set; }
            public string displayName { get; set; }
        }


        //PUT request for Users
        private void editUserbtn_Click(object sender, EventArgs e)
        {
            editUserForm editUserForm = new editUserForm();

            editUserForm.Controls.Find("editUsernameTextBox", true)[0].Text = usernameOutlbl.Text;
            editUserForm.Controls.Find("editRegisterDateTextBox", true)[0].Text = RegisterDateOutlbl.Text;
            editUserForm.Controls.Find("editDateOfBirthTextBox", true)[0].Text = dateOfBirthOutlbl.Text;
            editUserForm.Controls.Find("editUserRankTextBox", true)[0].Text = userRankOutlbl.Text;
            editUserForm.Controls.Find("editEloScoreTextBox", true)[0].Text = eloScoreOutlbl.Text;
            editUserForm.Controls.Find("editDisplayNameTextBox", true)[0].Text = displayNameOutlbl.Text;

            editUserForm.Show();
        }


        //DELETE request for users
        private async void deleteUserbtn_Click(object sender, EventArgs e)
        {
            HttpClient chessClient = new HttpClient();
            chessClient.BaseAddress = new Uri($"https://localhost:{port}/api/");

            chessClient.DefaultRequestHeaders.Add("User_Agent", "CIS411FinalAssignment");
            chessClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            string UserID = userIDTextBox.Text;

            try
            {
                var response = await chessClient.DeleteAsync($"ChessUsers?UserName={UserID}");
                response.EnsureSuccessStatusCode();

                MessageBox.Show("User has been deleted");
            }
            catch (HttpRequestException err)
            {
                MessageBox.Show($"User Not Found {chessClient.BaseAddress + UserID} + {err.Message}");
            }
        }


        //POST request for new user
        private async void button1_Click(object sender, EventArgs e)
        {
            DateTime registerDate = DateTime.Parse(newRegisterDateTextBox.Text);
            DateTime dateOfBirth = DateTime.Parse(newDateOfBirthTextBox.Text);

            string userName = newUsernameTextBox.Text;

            var data = new
            {
                userName = userName,
                registerDate = registerDate,
                dateOfBirth = dateOfBirth,
                userRank = newUserRankTextBox.Text,
                eloScore = newEloScoreTextBox.Text,
                displayName = newDisplayNameTextBox.Text,
            };

            var jsondata = JsonSerializer.Serialize(data);
            var content = new StringContent(jsondata, Encoding.UTF8, "application/json");

            using (HttpClient chessClient = new HttpClient())
            {
                try
                {
                    chessClient.BaseAddress = new Uri($"https://localhost:{port}/api/");
                    var response = await chessClient.PostAsync($"ChessUsers", content);

                    response.EnsureSuccessStatusCode();

                    MessageBox.Show("New User Created");
                }
                catch (HttpRequestException err)
                {
                    MessageBox.Show("User not created. Please fill in all fields.");
                }
            }
        }


        //GET request for Game Logs
        private async void getGameLogsbtn_Click(object sender, EventArgs e)
        {
            using (HttpClient chessClient = new HttpClient())
            {
                try
                {
                    chessClient.BaseAddress = new Uri($"https://localhost:{port}/api/");

                    chessClient.DefaultRequestHeaders.Add("User_Agent", "CIS411FinalAssignment");
                    chessClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    string GameID = gameLogIDTextBox.Text;
                    string MoveID = moveSequenceTextBox.Text;

                    System.IO.Stream pageinfo = null;
                    var response = await chessClient.GetAsync($"GameLogs?GameID={GameID}&MoveSequence={MoveID}");

                    response.EnsureSuccessStatusCode();
                    pageinfo = await response.Content.ReadAsStreamAsync();
                    newGameLogbtn.Enabled = false;

                    GameLog gameLog = JsonSerializer.Deserialize<GameLog>(pageinfo);

                    moveSequenceOutlbl.Text = "" + gameLog.moveSequence;
                    pieceOutlbl.Text = "" + gameLog.piece;
                    startTileOutlbl.Text = "" + gameLog.startTile;
                    endTileOutlbl.Text = gameLog.endTile;
                }
                catch (HttpRequestException err)
                {
                    MessageBox.Show($"Game Log Not Found");
                }
            }
        }

        //Model for game logs
        public class GameLog {

            public int gameID { get; set; }
            public int moveSequence { get; set; }
            public string piece { get; set; }
            public string startTile { get; set; }
            public string endTile { get; set; }
        }


        //POST request for Game Logs
        private async void newGameLogbtn_Click(object sender, EventArgs e)
        {
            string gameID = newGameLogIDTextBox.Text;

            var data = new
            {
                gameID = gameID,
                moveSequence = 0,
                piece = newPieceTextBox.Text,
                startTile = newStartTileTextBox.Text,
                endTile = newEndTileTextBox.Text,
            };

            var jsondata = JsonSerializer.Serialize(data);
            var content = new StringContent(jsondata, Encoding.UTF8, "application/json");

            using (HttpClient chessClient = new HttpClient())
            {
                try
                {
                    chessClient.BaseAddress = new Uri($"https://localhost:{port}/api/");
                    var response = await chessClient.PostAsync($"GameLogs", content);

                    response.EnsureSuccessStatusCode();

                    MessageBox.Show("New game log entry created");
                }
                catch (HttpRequestException err)
                {
                    MessageBox.Show("Game log entry not created");
                }
            }
        }
    }
}
