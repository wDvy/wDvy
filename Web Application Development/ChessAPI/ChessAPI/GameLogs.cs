using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChessAPI
{
    [PrimaryKey(nameof(GameID),nameof(MoveSequence))]
    public class GameLogs
    {
        [Key]
        public int GameID { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Key]
        public int MoveSequence { get; set; }
        public string Piece {  get; set; }
        public string StartTile { get; set; }
        public string EndTile { get; set; }
    }
}
