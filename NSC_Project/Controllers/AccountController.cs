using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.Scripting;
using Microsoft.EntityFrameworkCore;
using NSC_Project.Data;
using NSC_Project.Extentions;
using NSC_Project.Models;
using NSC_Project.Models.ViewModel;
using NSC_Project.Extentions.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;
using ShopASP.Middlewares;

namespace NSC_Project.Controllers
{
    public class AccountController : Controller
    {
        private readonly NSC_ProjectContext _context;

        public AccountController(NSC_ProjectContext context)
        {
            _context = context;
        }
        //GET : Account/Login
        public async Task<IActionResult> Login()
        {
            return View();
        }
        //GET : Account/Register
        public async Task<IActionResult> Register()
        {
            return View();
        }
        //GET : Account/Logout
        public async Task<IActionResult> Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Account");
        }

        //POST : Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(UserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                var User = await _context.User.Where(s => s.Email.Equals(userViewModel.Email)).FirstOrDefaultAsync();

                if(User == null)
                {
                    TempData["errorEmail"] = "Tài khoản không tồn tại";
                    return View(userViewModel);
                }

                bool checkPass = false;

                if (User == null)
                {
                    return View(userViewModel);
                    
                }

                checkPass = BCrypt.Net.BCrypt.Verify(userViewModel.Password, User.Password);
                if (checkPass)
                {
                    //add session
                    var userSession = new UserSession
                    {
                        UserName = User.UserName,
                        UserId = User.Id,
                        Email = User.Email
                    };
                        

                    HttpContext.Session.SetObjectAsJson("Client", userSession);
                    return RedirectToAction("Index", "Trips");
                }
                else
                {
                    ViewBag.error = "Login failed";
                    return RedirectToAction("Login", "Accounts");
                }
            }

            return View(userViewModel);
        }

        //POST :  Account/Register => Create User
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(UserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                string userName = userViewModel.UserName;
                string email = userViewModel.Email;
                string password = userViewModel.Password;
                string rePassword = userViewModel.RePassword;
                var Users = await _context.User.Where(u => u.Email == email).ToListAsync();

                if (Users.Count() > 0)
                {
                    TempData["errorEmail"] = "Email đã tồn tại";
                    return View(userViewModel);
                }
                if(password != rePassword)
                {
                    TempData["errorPassWord"] = "Mật khẩu nhập lại không đúng";
                    return View(userViewModel);
                }

                User newUser = new User { 
                    UserName = userName,
                    Email = email,
                    Password = BCrypt.Net.BCrypt.HashPassword(password),
                    RoleId = 3
                };

                _context.User.Add(newUser);
                await _context.SaveChangesAsync();
                TempData["RegisterDone"] = "Đăng kí thành công";
                
                return RedirectToAction("Login","Account");
            }
            return View(userViewModel);
        }

        //GET : Account/History
        [MiddlewareFilter(typeof(AuthUserMiddleware))]
        public async Task<IActionResult> History()
        {
            var userSession = HttpContext.Session.GetObjectFromJson<UserSession>("Client");
            if (userSession==null)
            {
                return RedirectToAction("Login");
            }
            var userId = userSession.UserId;
            var billContext = _context.Bill
                .Include(bill => bill.User)
                .Include(bill => bill.TicketDetails)
                    .ThenInclude(t => t.Customer)
                .Include(bill=>bill.TicketDetails)
                    .ThenInclude(t=>t.Ticket)
                    .ThenInclude(t=>t.Fare)
                    .ThenInclude(f=>f.Trip)
                    .ThenInclude(trip=>trip.FlightRoute)
                    .ThenInclude(f=>f.AirportFrom)
                .Include(bill => bill.TicketDetails)
                    .ThenInclude(t => t.Ticket)
                    .ThenInclude(t => t.Fare)
                    .ThenInclude(f => f.Trip)
                    .ThenInclude(trip => trip.FlightRoute)
                    .ThenInclude(f => f.AirportTo)
                .Include(bill => bill.TicketDetails)
                    .ThenInclude(t => t.Ticket)
                    .ThenInclude(t => t.Fare)
                    .ThenInclude(f => f.Trip)
                    .ThenInclude(trip => trip.AirlineCompany)
                .Include(bill => bill.TicketDetails)
                    .ThenInclude(t => t.Ticket)
                    .ThenInclude(t => t.Fare)
                    .ThenInclude(f=>f.TicketClass);

            var linqBill = from bill in billContext
                           orderby bill.CreatedAt descending
                           select bill;

            var bills = await linqBill.Where(bill=>bill.UserId== userId).ToListAsync();

            return View(bills);
        }

    }
}
