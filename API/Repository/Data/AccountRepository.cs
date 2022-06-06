using API.Contex;
using API.Controllers;
using API.Models;
using API.Services;
using API.Utils;
using API.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;
using Microsoft.EntityFrameworkCore;

namespace API.Repository.Data
{
    public class AccountRepository : GeneralRepository<MyContext, Account, string>
    {
        public MyContext contex;
        public AccountRepository(MyContext myContext) : base(myContext)
        {
            this.contex = myContext;
        }

        public float Login(LoginPegawaiVM loginPegawaiVM)
        {
            Employee emCkh = contex.Employees.Include("account").FirstOrDefault(emp => emp.Email == loginPegawaiVM.email);

            if (emCkh.Email != loginPegawaiVM.email) return Variable.EMAIL_NOT_FOUND;// email gk ada
            else if (!BCrypt.Net.BCrypt.Verify(loginPegawaiVM.password, emCkh.account.password)) return Variable.PASSWORD_NOT_FOUND;//password tidak match

           
            return 200;

        }

        
        public string ActivateForgotPassword(ForgotPasswordVM forgotPasswordVM)
        {
            Employee emp = contex.Employees.FirstOrDefault(emp=> emp.Email ==forgotPasswordVM.email);
            if (emp == null) return "account tidak ada";

            Account acc = contex.Accounts.Find(emp.NIK);
                acc.otp = Tools.RandomString(6);
                acc.activeTime = DateTime.Now.AddMinutes(5);
                acc.otpIsActive = true;
            contex.Accounts.Update(acc);

            EmailServices.SendEmail(forgotPasswordVM.email, $"Forgot Password, Mr/Mrs {emp.FirstName}", $"Otp anda : {acc.otp} OTP ini akan expired setelah {acc.activeTime.ToString(CultureInfo.InvariantCulture)}");
            if (contex.SaveChanges() == 1) return "success";
            return "gagal";
            
        }

        public List<Role> GetAccountRoles(string email)
        {
           
            return (from emp in contex.Employees
                    join acr in contex.accountRoles
                    on emp.NIK equals acr.nik
                    join r in contex.roles
                    on acr.idRole equals r.idRole
                    where emp.Email == email select r

                    ).ToList();
        }

        public string ValidateForgotPassword (ForgotPasswordValidateVM forgotPasswordValidateVM)
        {
            Employee emp = contex.Employees.SingleOrDefault(emp => emp.Email == forgotPasswordValidateVM.email);
            Account acc = contex.Accounts.FirstOrDefault(acc => acc.otp == forgotPasswordValidateVM.otp);

            if (forgotPasswordValidateVM.newPassword 
                != forgotPasswordValidateVM.validate_newPassword 
                || emp == null) return "Password Tidak Cocok atau Email tidak terdaftar";
            
            if (acc == null) return "otp tidak valid";

            if (DateTime.Now > acc.activeTime)
            {
                acc.otpIsActive = false;
                contex.Accounts.Update(acc);
                if (contex.SaveChanges() == 1) return "otp is expired";
                return "otp is expired database not updated";
            }

            acc.password = Tools.BCryptHasing(forgotPasswordValidateVM.newPassword);
            contex.Accounts.Update(acc);
            if (contex.SaveChanges() == 1) return "Berhasil Update Password";
            return "Gagal Mengupdate Password";

        }

        public int SetManager (InsertManagerVM insertManagervm)
        {
            AccountRole acr = new AccountRole()
            {
                nik = insertManagervm.nik,
                idRole = 3
            };

            contex.accountRoles.Add(acr);
            return contex.SaveChanges();
        }

        
    }
}
