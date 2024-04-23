using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChessAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChessUsersController : ControllerBase
    {
        [HttpGet(Name = "GetChessUsers")]
        public IActionResult GetChessUsers(string UserName)
        {
            using (ChessUsersDBContext gdbc = new ChessUsersDBContext())
            {
                ChessUsers foundchessuser = gdbc.ChessUsers.Find(UserName);
                if (foundchessuser != null)
                {
                    return Ok(foundchessuser);
                }
                else
                {
                    return NotFound($"Username {UserName} does not exist");
                }
            }
        }

        [HttpPost(Name = "PostChessUsers")]
        public IActionResult PostChessUsers([FromBody] ChessUsers userData)
        {
            using(ChessUsersDBContext cudbc = new ChessUsersDBContext())
            {
                ChessUsers foundchessuser = cudbc.ChessUsers.Find(userData.UserName);

                if (foundchessuser == null)
                {
                    cudbc.ChessUsers.Add(userData);
                    cudbc.SaveChanges();
                    return Ok(userData);
                }
                else
                {
                    return BadRequest($"Username {userData.UserName} already exists");
                }

            }
        }

        [HttpPut(Name = "PutChessUsers")]
        public IActionResult PutChessUsers(string UserName, [FromBody] ChessUsers userData)
        {
            using (ChessUsersDBContext cudbc = new ChessUsersDBContext())
            {
                ChessUsers foundchessuser = cudbc.ChessUsers.Find(UserName);

                if (foundchessuser != null)
                {
                    foundchessuser.RegisterDate = userData.RegisterDate;
                    foundchessuser.DateOfBirth = userData.DateOfBirth;
                    foundchessuser.UserRank = userData.UserRank;
                    foundchessuser.ELOScore = userData.ELOScore;
                    foundchessuser.DisplayName = userData.DisplayName;

                    cudbc.SaveChanges();
                    return Ok(userData);
                }
                else
                {
                    return NotFound($"Username {UserName} does not exist");
                }
            }
        }

        [HttpDelete(Name = "DeleteChessUsers")]
        public IActionResult DeleteChessUsers(string UserName)
        {
            using (ChessUsersDBContext cudbc = new ChessUsersDBContext())
            {
                ChessUsers foundchessuser = cudbc.ChessUsers.Find(UserName);

                if(foundchessuser != null)
                {
                    cudbc.ChessUsers.Remove(foundchessuser);
                    cudbc.SaveChanges();
                    return Ok($"Username {UserName} has been deleted");
                }
                else
                {
                    return NotFound($"Username {UserName} does not exist");
                }
            }
        }

    }
}
