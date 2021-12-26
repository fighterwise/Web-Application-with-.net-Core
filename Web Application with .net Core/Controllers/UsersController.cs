using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Graph;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Web_Application_with_.net_Core.Models;

namespace Web_Application_with_.net_Core.Controllers
{
    public class UsersController : Controller
    {
        private readonly ILogger<UsersController> _logger;
        private readonly GraphServiceClient _graphServiceClient;

        public UsersController(ILogger<UsersController> logger, GraphServiceClient graphServiceClient) // 
        {
            _logger = logger;
            _graphServiceClient = graphServiceClient;
        }


        public async Task<IActionResult> Index()
        {
            //var user = await _graphServiceClient.Me
            //    .Request()
            //    .GetAsync();

            var groups = await _graphServiceClient.Groups
                .Request()
                .GetAsync();              //Groups

            var user = await _graphServiceClient.Users                                       // Users
                .Request()
                .GetAsync();
            
            List<string> DisplayName = new List<string>();
            List<string> Mail = new List<string>();
            List<string> Departament = new List<string>();
            List<string> CompanyName = new List<string>();

            foreach (var item in user)                                               // Username.Mail.Department,CompaNyname
            {
                DisplayName.Add(item.DisplayName);
                Mail.Add(item.Mail);
                Departament.Add(item.Department);
                CompanyName.Add(item.CompanyName);

                //if (item.DisplayName  != null && item.Mail != null && item.Department != null && item.CompanyName != null)
                //{
                //}
                //Users user1 = new Users(item.DisplayName.ToString(), item.Mail.ToString(), item.Department.ToString(), item.CompanyName.ToString());

                Users user2 = new Users()
                {
                    Name = item.DisplayName ?? "",
                    Mail = item.Mail ?? "",
                    Department = item.Department ?? "",
                    CompanyName = item.CompanyName ?? ""
                };

                //ViewData["users2"] = user2;
            }


            List<string> groupNames = new List<string>();

            if (groups != null)
            {
                foreach (var item in groups)                                           // Team.groupName
                {

                    if (item.Team != null)
                    {
                        groupNames.Add(item.Team.DisplayName);
                        Users user2 = new Users { TeamgroupName = item.Team.DisplayName.ToString() };
                        
                    }

                }
                // }
            }
            return View();
        }
    }
}
