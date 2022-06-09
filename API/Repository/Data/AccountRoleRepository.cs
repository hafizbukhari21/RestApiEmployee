using API.Contex;
using API.Models;
using API.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository.Data
{
   public class AccountRoleRepository { 
  
        public MyContext context;
        public AccountRoleRepository(MyContext myContext) 
        {
            this.context = myContext;
        }

        public int SetManager(InsertManagerVM insertManagervm)
        {
            var acr = context.accountRoles
                .Where(acr => acr.nik == insertManagervm.nik)
                .FirstOrDefault(acr=>acr.idRole == 3);
            if (acr != null) return 999;

            AccountRole acrUpdate = new AccountRole()
            {
                nik = insertManagervm.nik,
                idRole = 3
            };

            context.accountRoles.Add(acrUpdate);
            return context.SaveChanges();
        }

       

    }
}
