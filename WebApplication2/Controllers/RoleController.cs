using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Text.Json;
using WebApplication2.Helpers;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class RoleController : Controller
    {
        public string url = "http://localhost:8080";
        ApiConnect api = new ApiConnect();
        public IActionResult Index()
        {
            var response = api.GetApi(url + "/role/");
            var contents = response.Content.ReadAsStringAsync().Result;
            List<Role> lstRolesParsed = CastRoles(contents);
            ViewBag.lstRoles = lstRolesParsed;
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Role _role)
        {
            var json = JsonSerializer.Serialize(_role);
            var response = api.PostApi(url + "/role/", json);
            return View("Success");
        }

        public IActionResult Delete(int id)
        {
            var responseUser = api.DeleteFromApi(url + "/role/" + id);
            if (responseUser.IsSuccessStatusCode)
            {
                return View("Success");
            }
            return View("Error");
        }

        private static List<Role> CastRoles(string contents)
        {
            Role[] lstRol = JsonSerializer.Deserialize<Role[]>(contents.ToString());
            List<Role> lstRolesParsed = new List<Role>();
            for (int i = 0; i < lstRol.Length; i++)
            {
                Role role = lstRol[i];
                lstRolesParsed.Add(role);
            }

            return lstRolesParsed;
        }
    }
}
