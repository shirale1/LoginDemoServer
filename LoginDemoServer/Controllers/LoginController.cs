
using LoginDemoServer.Models;
using LoginDemoServer.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication;


namespace LoginDemoServer.Controllers
{
    [Route("api")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        //a variable to hold a reference to the db context!
       
        private LoginDemoDbContext context;

        //Use dependency injection to get the db context intot he constructor



        public LoginController(LoginDemoDbContext context)
        {
            this.context = context;
        }

        // POST api/login
        [HttpPost("login")]
        public IActionResult Login([FromBody] DTO.LoginInfo loginDto)
        {
            try
            {
                HttpContext.Session.Clear(); //Logout any previous login attempt

                //Get model user class from DB with matching email. 
             
                Models.Users modelsUser = context.GetUSerFromDB(loginDto.Email);
                
                //Check if user exist for this email and if password match, if not return Access Denied (Error 403) 
                if (modelsUser == null || modelsUser.Password != loginDto.Password) 
                {
                    return Unauthorized();
                }

                //Login suceed! now mark login in session memory!
                HttpContext.Session.SetString("loggedInUser", modelsUser.Email);

                return Ok(new DTO.Users(modelsUser));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        

        // Get api/check
        [HttpGet("check")]
        public IActionResult Check()
        {
            try
            {
                //Check if user is logged in 
                string userEmail = HttpContext.Session.GetString("loggedInUser");

                if (string.IsNullOrEmpty(userEmail))
                {
                    return Unauthorized("User is not logged in");
                }


                //user is logged in - lets check who is the user
                Models.Users modelsUser = context.GetUSerFromDB(userEmail);
             
                return Ok(new DTO.Users(modelsUser));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


    }
}
