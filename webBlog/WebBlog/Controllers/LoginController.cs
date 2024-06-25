using BlogHelper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using ModelEFCore;

namespace WebBlog.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly MyDbContext dbCtx;
        private readonly GenerateToken _tokenGenerator;
        private readonly ILogger<LoginController> _logger;
        private readonly IDistributedCache _cache;

        public LoginController(MyDbContext dbCtx, GenerateToken tokenGenerator, IDistributedCache cache)
        {
            this.dbCtx = dbCtx;
            _tokenGenerator = tokenGenerator;
            _cache = cache;
        }

        # region ��¼��֤
        [HttpPost]
        public ActionResult<Account> Login([FromBody] Account account)
        {
            //дһ���жϱ�֤�˻����벻Ϊ��
            if (string.IsNullOrEmpty(account.User_Name) || string.IsNullOrEmpty(account.Password))
            {
                return BadRequest("�û��������벻��Ϊ��");
            }

            var result = dbCtx.Accounts.FirstOrDefault(a => a.User_Name == account.User_Name && a.Password == account.Password);

            // ����ѯ����Ƿ�Ϊ�ջ��ߵ���0�����Ϊ�ջ��ߵ���0�򷵻ش�����Ϣ�����򷵻سɹ���Ϣ
            if (result != null )
            {
                // �ж��Ƿ��ǹ���Ա�˺ţ�������򷵻ع���ԱȨ�ޣ����򷵻���ͨ�û�Ȩ��
                if (result.Role == 0)
                {
                    // ����ԱȨ�ޡ�
                    return Ok("����Ա��¼�ɹ�!");
                }
                else
                {
                    //��ͨ�û�Ȩ��
                    if(result.Is_Deleted == true)
                    {
                        //�ж��˻��Ƿ��Ѿ���ע��
                        return BadRequest("���˻��ѱ�ע��������ϵ����Ա��");
                    }
                    else
                    {
                        // ��ͨ�û�Ȩ��������¼
                        //����������¼�ĵ�¼ʱ��
                        result.Last_LoginTime = DateTime.Now; // �������Ǹ��µ�¼ʱ��Ĵ��롣

                        try
                        {
                            // ������ĵ����ݿ�
                            dbCtx.SaveChanges();
                            string token = _tokenGenerator.LoginToken(result);
                            _cache.SetString(result.User_Name, token); // �������ǽ�token�洢������Ĵ��롣
                            return Ok("��ͨ�û���¼�ɹ�!" + token);
                        }
                        catch (Exception ex)
                        {
                            // ���񲢴����쳣
                            return StatusCode(500, $"�������ʱ��������: {ex.Message}");
                        }
                    }
                }
            }else
            {
                return BadRequest("�û���������������������룡");
            }                 
        }
        #endregion
    }
}