using API.Models;
using API.Repository.Data;
using API.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountRoleController : ControllerBase
    {
        public AccountRoleRepository accountRoleRepository;

        public AccountRoleController(AccountRoleRepository accountRoleRepository )
        {
            this.accountRoleRepository = accountRoleRepository;
        }

        [Authorize(Roles = "Direktur")]
        [HttpPost("SetManager")]
        public ActionResult SetManager(InsertManagerVM insertManagervm)
        {
            if (accountRoleRepository.SetManager(insertManagervm) == 999)
                return Ok(new { message = "Duplicate, sudah di set sebelumnya" });
            else
                return Ok(new { message = "Success jadi manager" });
        }

    }
}
