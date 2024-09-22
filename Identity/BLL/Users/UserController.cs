using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.BLL.Controllers;

namespace Identity.BLL.Users
{
    [Authorize(Roles = "develope,developer")]
    public class UserController : BaseController
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("2222222");
        }
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            return Ok("2222222" + id);
        }
    }
}
