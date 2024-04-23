using System.ComponentModel.DataAnnotations;

namespace ChessAPI
{
    public class ChessUsers
    {
        [Key]
        [Required]
        public string UserName { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string UserRank { get; set; }
        public int ELOScore { get; set; }
        public string DisplayName { get; set; }
    }
}
