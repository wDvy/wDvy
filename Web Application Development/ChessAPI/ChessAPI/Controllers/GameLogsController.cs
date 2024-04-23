using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChessAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameLogsController : ControllerBase
    {
        [HttpGet(Name ="GetGameLogs")]
        public IActionResult GetGameLogs(int GameID, int MoveSequence)
        {
            using(GameLogsDBContext gldbc = new GameLogsDBContext())
            {
                GameLogs foundgamelog = gldbc.GameLogs.Find(GameID, MoveSequence);

                if (foundgamelog != null)
                {
                    return Ok(foundgamelog);
                }
                else
                {
                    return NotFound("Game log does not exist");
                }
            }
        }

        [HttpPost(Name ="PostGameLogs")]
        public IActionResult PostGameLogs([FromBody] GameLogs logData)
        {
            using (GameLogsDBContext gldbc = new GameLogsDBContext())
            {
                GameLogs foundgamelog = gldbc.GameLogs.Find(logData.GameID  , logData.MoveSequence);

                if (foundgamelog == null)
                {
                    gldbc.GameLogs.Add(logData);
                    gldbc.SaveChanges();
                    return Ok(logData);
                }
                else
                {
                    return BadRequest("Game log already exists");
                }
            }
        }
    }
}
