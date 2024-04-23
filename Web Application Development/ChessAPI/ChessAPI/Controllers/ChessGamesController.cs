using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChessAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChessGamesController : ControllerBase
    {
        [HttpGet(Name = "GetChessGames")]
        public IActionResult GetChessGames(int GameID)
        {
            using (ChessGamesDBContext cgdbc = new ChessGamesDBContext())
            {
                ChessGames foundchessgame = cgdbc.ChessGames.Find(GameID);

                if (foundchessgame != null)
                {
                    return Ok(foundchessgame);
                }
                else
                {
                    return NotFound($"Game ID {GameID} does not exist");
                }
            }
        }

        [HttpPost(Name = "PostChessGames")]
        public IActionResult PostChessGames([FromBody] ChessGames gameData)
        {
            using (ChessGamesDBContext cgdbc = new ChessGamesDBContext())
            {
                ChessGames foundchessgame = cgdbc.ChessGames.Find(gameData.GameID);

                if(foundchessgame == null)
                {
                    cgdbc.ChessGames.Add(gameData);
                    cgdbc.SaveChanges();
                    return Ok(gameData);
                }
                else
                {
                    return BadRequest($"The Game ID {gameData.GameID} already exists");
                }
            }
        }

        [HttpPut(Name = "PutChessGames")]
        public IActionResult PutChessGames(int GameID, [FromBody] ChessGames gameData)
        {
            using (ChessGamesDBContext cgdbc = new ChessGamesDBContext())
            {
                ChessGames foundchessgame = cgdbc.ChessGames.Find(GameID);

                if (foundchessgame != null)
                {
                    foundchessgame.PlayerID1 = gameData.PlayerID1;
                    foundchessgame.PlayerID2 = gameData.PlayerID2;
                    foundchessgame.WinningPlayer = gameData.WinningPlayer;
                    foundchessgame.LosingPlayer = gameData.LosingPlayer;
                    foundchessgame.GameTime = gameData.GameTime;

                    cgdbc.SaveChanges();
                    return Ok(gameData);
                }
                else
                {
                    return NotFound($"Game ID {GameID} does not exist");
                }
            }
        }
    }
}
