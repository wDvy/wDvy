using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Diagnostics.CodeAnalysis;


namespace apiacceptform
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void Calc_Click(object sender, EventArgs e)
        {
            HttpClient chessClient = new HttpClient();
            chessClient.BaseAddress = new Uri("https://api.chess.com/pub/player/");

            chessClient.DefaultRequestHeaders.Add("User-Agent", "CIS411HW1");
            chessClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            string userName = nameBox.Text;

            System.IO.Stream pageInfo = null;

            var response = await chessClient.GetAsync($"{userName}");

            if (response.IsSuccessStatusCode)
            {
                pageInfo = await response.Content.ReadAsStreamAsync();
            }

            Player player = JsonSerializer.Deserialize<Player>(pageInfo);

            imgBox.ImageLocation = player.avatar;

            nameOut.Text = player.name;
            locationOut.Text = player.location;
            countryOut.Text = player.country;
            followersOut.Text = player.followers.ToString();



        }

        public class Player
        {
            public string name { get; set; }
            public string location { get; set; }
            public string country { get; set; }
            public int followers { get; set; }
            public string avatar {  get; set; }

        }


    }



}
