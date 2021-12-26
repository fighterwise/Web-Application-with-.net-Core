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

            //List<string> DisplayName = new List<string>();
            //List<string> Mail = new List<string>();
            //List<string> Departament = new List<string>();
            //List<string> CompanyName = new List<string>();


            var usersList = new List<Models.User>();


            foreach (var item in user)                                               // Username.Mail.Department,CompaNyname
            {
                var joinedTeams = "";
                if (item.JoinedTeams != null)
                {
                    foreach (var team in item.JoinedTeams)
                    {
                        joinedTeams += $"{team.DisplayName}\n";
                    }
                }

                var userModel = new Models.User()
                {
                    Mail = item.Mail ?? "",
                    Name = item.DisplayName ?? "",
                    Department = item.Department ?? "",
                    CompanyName = item.CompanyName ?? "",
                    TeamgroupName = joinedTeams
                };



                usersList.Add(userModel);

                //await _userWriteRepository.Add(usermodel);

                //DisplayName.Add(item.DisplayName);
                //Mail.Add(item.Mail);
                //Departament.Add(item.Department);
                //CompanyName.Add(item.CompanyName);

                //if (item.DisplayName  != null && item.Mail != null && item.Department != null && item.CompanyName != null)
                //{
                //}
                //Users user1 = new Users(item.DisplayName.ToString(), item.Mail.ToString(), item.Department.ToString(), item.CompanyName.ToString());

                //Models.User user2 = new Models.User()
                //{
                //    Name = item.DisplayName ?? "",
                //    Mail = item.Mail ?? "",
                //    Department = item.Department ?? "",
                //    CompanyName = item.CompanyName ?? ""
                //};


                //ViewData["users2"] = user2;
            }


            // List<string> groupNames = new List<string>();

            //if (groups != null)
            //{
            //    foreach (var item in groups)                                           // Team.groupName
            //    {

            //        if (item.Team != null)
            //        {

            //            userModel.TeamgroupName = item.Team.DisplayName.ToString() ?? "";

            //           // groupNames.Add(item.Team.DisplayName);
            //            //Models.User user2 = new Models.User { TeamgroupName = item.Team.DisplayName.ToString() };

            //        }

            //    }
            //    // }
            //}

            return View(usersList);
        }
    }
}
