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
                return BadRequest("�û��������벻��Ϊ��");
            }
            if(login.userName == "admin" && login.password == "1234567")
            {
                // �����������֤�û�����������߼��������ѯ���ݿ��
                // �����֤�ɹ������سɹ���Ϣ�������֤ʧ�ܣ����ش�����Ϣ

                return Ok("��¼�ɹ�");
            }
            return BadRequest();
        }
    }

}
