using fdoCurrApp.Context;
using fdoCurrApp.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net.NetworkInformation;
using System.Security.Authentication;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace fdoCurrApp.Controllers
{
    public class LoginController : Controller
    {
        private ApplicationDbContext _context;

        public LoginController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Index(Login login)
        {
            //Lecturer lec = _context.lecturerInfo.SingleOrDefault(x => x.lec_id == login.lec_id && x.lec_id == login.lec_id);
            string lecPass = Encrypt(Encrypt(login.lec_pass));
            Lecturer lec = _context.lecturerInfo
         .Where(x => x.lec_id == login.lec_id && x.lec_pass==lecPass).FirstOrDefault();

            if(lec != null)
            {
                lec.auth_key = generateJwtToken(lec);
                _context.SaveChanges();
                ResponseLogin response = new ResponseLogin()
                {
                    lec_id = lec.lec_id,
                    lec_name=lec.lec_name,
                    lec_surname=lec.lec_surname,
                    accesToken=  lec.auth_key
                };
                
                return Json(response);
            }

            throw new AuthenticationException("Lecturer ID veya Şifre yanış girilmiştir.Lütfen tekrar deneyiniz.");
        }

        string hash = "";
        public string Encrypt(string pass)
        {
            byte[] data = Encoding.Default.GetBytes(pass);
            using (MD5CryptoServiceProvider md5=new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(Encoding.Default.GetBytes(hash));
                using (TripleDESCryptoServiceProvider tripleDES=new TripleDESCryptoServiceProvider() { Key=keys,Mode=CipherMode.ECB,Padding=PaddingMode.PKCS7})
                {
                    ICryptoTransform transform = tripleDES.CreateEncryptor();
                    byte[] results = transform.TransformFinalBlock(data,0, data.Length);
                    return Convert.ToBase64String(results,0,results.Length);
                }

            }
        }

        private string generateJwtToken(Lecturer lec)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Convert.ToString(lec.lec_id));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                    new Claim("id", lec.lec_id.ToString()),
                    new Claim("name", lec.lec_name.ToString()),
                    new Claim("surname", lec.lec_surname.ToString()),
                    new Claim("login-time", DateTime.Now.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss")),
                }),
                Expires = DateTime.UtcNow.AddDays(0.5),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }



    }
}
