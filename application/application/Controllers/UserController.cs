using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using application.Models;
using application.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

using MySql.Data.MySqlClient;
using Newtonsoft.Json;

namespace application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserManager<ApplicationUser> _userManager;
        private readonly ConfigHelper _appSettings;
        private readonly ConnectionStrings _connect;
        private readonly UserRepository _userRepository;

        public UserController(UserManager<ApplicationUser> userManager, IOptions<ConfigHelper> appSettings, IOptions<ConnectionStrings> mySqlConnect)
        {
            _userManager = userManager;
            _appSettings = appSettings.Value;
            _connect = mySqlConnect.Value;
            _userRepository = new UserRepository(mySqlConnect);
        }
        

        [HttpGet]
        [Route("AllUsers")]
        //GET : /api/User/AllUsers
        public IActionResult GetUser()
        {
            var result = _userRepository.GetUsers();
            return Ok(JsonConvert.SerializeObject(result));
        }
    }
}
