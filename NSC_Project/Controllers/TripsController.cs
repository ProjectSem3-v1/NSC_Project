using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NSC_Project.Data;
using NSC_Project.Extentions;
using NSC_Project.Extentions.Models;
using NSC_Project.Models;
using NSC_Project.Models.ViewModel;
using NuGet.Versioning;
using ShopASP.Middlewares;

namespace NSC_Project.Controllers
{

    [MiddlewareFilter(typeof(AuthUserMiddleware))]

    public class TripsController : Controller
    {
        private readonly NSC_ProjectContext _context;

        public TripsController(NSC_ProjectContext context)
        {
            _context = context;
        }
        // GET: Trips
        public async Task<IActionResult> Index(TripViewModel tripViewModel)
        {
            var nSC_ProjectContext = _context.Trip.Include(t => t.AirlineCompany).Include(t => t.FlightRoute).Include(t => t.Plane);
            var airportFroms = await _context.AirportFrom.ToListAsync();
            var airportTos = await _context.AirportTo.ToListAsync();
            var ticketClasses = await _context.TicketClass.ToListAsync();
            var airlineCompanies = await _context.AirlineCompany.ToListAsync();
            //
            var airportToId = tripViewModel.AirportToId;
            var airportFromId = tripViewModel.AirportFromId;
            var ticketClassId = tripViewModel.TicketClassId;
            var airlineCompanyId = tripViewModel.AirlineCompanyId;
            var priceMin = tripViewModel.priceMin;
            var priceMax = tripViewModel.priceMax;
            DateTime ticketDate = tripViewModel.TicketDate;
            var timeStart = 0;
            var timeEnd = 24;
            switch (tripViewModel.timeStartId)
            {
                case 0:
                    timeStart = 0;
                    timeEnd = 6;
                    break;
                case 1:
                    timeStart = 6;
                    timeEnd = 12;
                    break;
                case 2:
                    timeStart = 12;
                    timeEnd = 18;
                    break;
                case 3:
                    timeStart = 18;
                    timeEnd = 24;
                    break;
            }

            var TicketContext = _context.Ticket
                .Include(t => t.Trip)
                    .ThenInclude(trip => trip.FlightRoute)
                .Include(t => t.Fare)
                    .ThenInclude(fare => fare.TicketClass);


            var Ticket = from t in TicketContext
                         where t.Trip.FlightRoute.AirportToId == airportToId 
                         && t.Trip.FlightRoute.AirportFromId == airportFromId
                         && t.Fare.TicketClassId == ticketClassId
                         && t.Trip.AirlineCompanyId == airlineCompanyId
                         && t.Fare.Price >= priceMin
                         && t.Fare.Price <= priceMax
                         && t.Trip.StartDate.Hour >= timeStart
                         && t.Trip.StartDate.Hour <= timeEnd
                         && t.Trip.StartDate.Day == ticketDate.Day
                         && t.Trip.StartDate.Month == ticketDate.Month
                         && t.Trip.StartDate.Year == ticketDate.Year
                         select t;

            var tickets = await Ticket.ToListAsync();

            tripViewModel.airportFroms = airportFroms;
            tripViewModel.airportTos = airportTos;
            tripViewModel.ticketClasses = ticketClasses;
            tripViewModel.airlineCompanies = airlineCompanies;
            tripViewModel.tickets = tickets;

          
            return View(tripViewModel);
        }
        //Get: Trips/Checkout
        public async Task<IActionResult> Checkout(CheckoutViewModel checkoutViewModel)
        {
            var ticket = await _context.Ticket.Include(t=>t.Fare).Include(t=>t.Trip)
                .ThenInclude(t=>t.AirlineCompany)
                .FirstAsync(t=>t.Id==checkoutViewModel.ticket.Id);

            checkoutViewModel.ticket = ticket;
            return View(checkoutViewModel);
        }

        [HttpPost, ActionName("Checkout")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CheckoutConfirmed(CheckoutViewModel checkoutViewModel)
        {

            Ticket ticket = await _context.Ticket
                .Include(t => t.Fare)
                .FirstAsync(t=>t.Id == checkoutViewModel.ticket.Id);

            var subtotal = ticket.Fare.Price * checkoutViewModel.people;

            var userSession = HttpContext.Session.GetObjectFromJson<UserSession>("Client");

            Console.WriteLine("UserId" + userSession.UserId);

            Bill newBill = new Bill {
                UserId = userSession.UserId,
                Subtotal = subtotal,
                CreatedAt = DateTime.Now
            };

            _context.Bill.Add(newBill);
            await _context.SaveChangesAsync();

            List<TicketDetail> ticketDetails = new List<TicketDetail> { };
            List<Customer> customers = new List<Customer> { };

            customers.Add(checkoutViewModel.customer_1);


            if(checkoutViewModel.customer_2 != null)
            {
                customers.Add(checkoutViewModel.customer_2);

            }

            if (checkoutViewModel.customer_3 != null)
            {
                customers.Add(checkoutViewModel.customer_3);
            }

            if (checkoutViewModel.customer_4 != null)
            {
                customers.Add(checkoutViewModel.customer_4);
            }

            if (checkoutViewModel.customer_5 != null)
            {
                customers.Add(checkoutViewModel.customer_5);
            }

            await _context.Customer.AddRangeAsync(customers);
            await _context.SaveChangesAsync();

            foreach (var customer in customers)
            {
                await _context.TicketDetail.AddAsync(
                    new TicketDetail
                    {
                        TicketId = checkoutViewModel.ticket.Id,
                        CustomerId = customer.Id,
                        BillId = newBill.Id
                    }    
                );
            }

            await _context.SaveChangesAsync();


            return RedirectToAction("History","Account");
        }
       
        
    }
   
}
