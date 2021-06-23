using API52.Context;
using API52.Models;
using API52.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Threading.Tasks;

namespace API52.Repository.Data
{
    public class AccountRepository : GeneralRepository<MyContext, Account, string>
    {
        private readonly MyContext context;
        public AccountRepository(MyContext myContext) : base(myContext)
        {
            this.context = myContext;
        }
        public int Login(LoginVM loginVM)
        {
            var employee = new Employee();
            var account = new Account();
            var alternatif = context.Accounts.Find(loginVM.NIK);
            if (alternatif != null)
            {
                var test = context.Accounts.FirstOrDefault(a => a.NIK == loginVM.NIK && a.Password == loginVM.Password);
                if (test != null)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                var cekEmail = context.Employees.FirstOrDefault(a => a.Email == loginVM.NIK);
                var cekNIK = context.Employees.Find(cekEmail.NIK);
                var hasedpassword = context.Accounts.Find(cekNIK.NIK);
                var validate = BCrypt.Net.BCrypt.Verify(loginVM.Password, hasedpassword.Password);
                var cekPass = context.Accounts.FirstOrDefault(a => a.NIK == cekNIK.NIK && a.Password == loginVM.Password);
                if (cekEmail != null && validate)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }
        public int ChangePassword(ChangeVM changeVM)
        {
            var employee = new Employee();
            var account = new Account();
            var cekEmail = context.Employees.FirstOrDefault(a => a.Email == changeVM.NIK);
            var cekNIK = context.Employees.Find(cekEmail.NIK);
            var hasedpassword = context.Accounts.Find(cekNIK.NIK);
            if (cekEmail != null)
            {
                var cekpass = BCrypt.Net.BCrypt.Verify(changeVM.PasswordLama, hasedpassword.Password);
                if(cekpass)
                {
                    var change = MyContext.Accounts.Find(cekEmail.NIK);
                    change.Password = BCrypt.Net.BCrypt.HashPassword(changeVM.PasswordBaru);
                    MyContext.SaveChanges();
                    return 2;
                }
                else
                {
                    return 1;
                }
            }
            return 0;
        }
        public int ResetPassword(ForgotVM forgotVM)
        {
            //var oldpassword = context.Accounts.FirstOrDefault(a => a.Password == loginVM.Password);
            try
            {
                var employee = new Employee();
                var account = new Account();
                Guid obj = Guid.NewGuid();
                var cekEmail = context.Employees.FirstOrDefault(a => a.Email == forgotVM.NIK);
                var cekNIK = context.Employees.Find(cekEmail.NIK);
                var email = context.Employees.FirstOrDefault(a => a.Email == forgotVM.Email);
                account.NIK = cekNIK.NIK;
                forgotVM.PasswordLama = account.Password;
                account.Password = BCrypt.Net.BCrypt.HashPassword(obj.ToString());
                using (MailMessage mail = new MailMessage())
                {
                    var placeholder = obj.ToString();
                    mail.From = new MailAddress("geralepua98@gmail.com");
                    mail.To.Add(forgotVM.Email);
                    mail.Subject = $"Reset Password {forgotVM.PasswordLama}";
                    mail.Body = $"Halo {email.FirstName} , ini adalah password baru anda note bahwa ini password sementara {obj.ToString()}";

                    using (SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com", 587))
                    {
                        SmtpServer.Credentials = new System.Net.NetworkCredential("geralepua98@gmail.com", "Gerald9398");
                        SmtpServer.EnableSsl = true;
                        SmtpServer.Send(mail);
                        MyContext.Update(account);
                        MyContext.SaveChanges();
                        return 1;
                    }
                }
            }
            catch (Exception)
            {

                return 0;
            }
        }
    }
}
