using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Text.Json;
using WebApplication2.Helpers;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class ReservationController : Controller
    {
        public string url = "http://localhost:8080";
        public IActionResult Index()
        {
            ApiConnect api = new ApiConnect();
            var response = api.GetApi(url + "/reservation/");
            var contents = response.Content.ReadAsStringAsync().Result;
            Reservation[] lstReservation = JsonSerializer.Deserialize<Reservation[]>(contents.ToString());
            List<Reservation> lstReservationsParsed = new List<Reservation>();
            for (int i = 0; i < lstReservation.Length; i++)
            {
                Reservation reservation = lstReservation[i];
                lstReservationsParsed.Add(reservation);
            }
            ViewBag.Reservations = lstReservationsParsed;
            return View();
        }
    }
}
