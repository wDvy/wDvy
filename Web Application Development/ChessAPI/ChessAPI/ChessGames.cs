using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChessAPI
{
    public class ChessGames
    {
        [Key]
        public int GameID { get; set; }
        public string PlayerID1 { get; set; }
        public string PlayerID2 { get; set; }
        public string WinningPlayer {  get; set; }
        public string LosingPlayer { get; set; }
        public DateTime GameTime { get; set; }
    }
}
