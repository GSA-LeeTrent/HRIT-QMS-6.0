using System;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using QmsCore.Services;
using QmsCore.UIModel;
using Qms_Data.Services.Interfaces;
using Qms_Data.ViewModels;

namespace Qms_Web.Controllers
{
    [Route("api/ua/users")]
    [ApiController]
    public class UserAdminApiController : ControllerBase
    {
        private readonly IUserAdminService _userAdminService;

        public UserAdminApiController(IUserAdminService userAdminService)
        {
            _userAdminService = userAdminService;
        }

        [HttpGet]
        public ActionResult<List<ManagerSelectOptionVM>> RetrieveUsersByOrganizationId(int orgId)
        {
            string logSnippet = new StringBuilder("[")
                                .Append(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"))
                                .Append("][UserAdminApiController][HttpGet][RetrieveUsersByOrganizationId] => ")
                                .ToString();

            Console.WriteLine(logSnippet + $"(orgId)............: '{orgId}'");
            Console.WriteLine(logSnippet + $"(# of users in org): '{_userAdminService.RetrieveUsersByOrgId(orgId).Count}'");

            return _userAdminService.RetrieveUsersByOrgId(orgId);
        }
    }
}