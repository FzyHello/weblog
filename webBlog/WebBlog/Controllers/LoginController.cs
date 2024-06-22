using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace WebBlog.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
            
        private readonly ILogger<LoginController> _logger;

        public class LoginModel
        {
            public string userName { get; set; }
            public string password { get; set; }
        }

        public LoginController(ILogger<LoginController> logger)
        {
            _logger = logger;
        }
        [HttpPost]
        public IActionResult Login([FromBody] LoginModel login)
        {

            if (string.IsNullOrEmpty(login.userName) || string.IsNullOrEmpty(login.password))
            {
                return BadRequest("用户名和密码不能为空");
            }
            if(login.userName == "admin" && login.password == "1234567")
            {
                // 在这里添加验证用户名和密码的逻辑，例如查询数据库等
                // 如果验证成功，返回成功信息；如果验证失败，返回错误信息

                return Ok("登录成功");
            }
            return BadRequest();
        }
    }

}
