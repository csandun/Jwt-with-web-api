using System;
using System.Net;
using System.Web.Http;
using System.Web.Http.Results;
using Newtonsoft.Json;

namespace WebApi.Jwt.Controllers
{
    public class TokenController : ApiController
    {
        // THis is naive endpoint for demo, it should use Basic authentication to provide token or POST request
        [AllowAnonymous]
        public IHttpActionResult Get(string username, string password)
        {
            
           
                try
                {
                    if (CheckUser(username, password))
                    {
                        return Json(new { data = JwtManager.GenerateToken(username) });
                    }
                    throw new HttpResponseException(HttpStatusCode.Unauthorized);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
               
          
            
        }

        public bool CheckUser(string username, string password)
        {
            if (username == "sandun" && password =="1234")
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }
    }
}
