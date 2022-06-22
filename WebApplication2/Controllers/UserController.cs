using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Text.Json;
using WebApplication2.Helpers;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class UserController : Controller
    {
        public string url = "http://localhost:8080";
        ApiConnect api = new ApiConnect();
        public IActionResult Index()
        {
            var response = api.GetApi(url + "/person/");
            var contents = response.Content.ReadAsStringAsync().Result;
            User[] lstUsers = JsonSerializer.Deserialize<User[]>(contents.ToString());
            List<User> lstUsersParsed = new List<User>();
            for (int i = 0; i < lstUsers.Length; i++)
            {
                User role = lstUsers[i];
                lstUsersParsed.Add(role);
            }
            ViewBag.lstUsersParsed = lstUsersParsed;
            return View();
        }
        [HttpGet]
        public IActionResult Signin()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Signin(User _user)
        {

            return View("Success");
        }
        [HttpGet]
        public IActionResult Create()
        {
            var response = api.GetApi(url + "/person/roles/");
            var contents = response.Content.ReadAsStringAsync().Result;
            List<Role> lstRolesParsed = CastRoles(contents);
            ViewBag.lstRoles = lstRolesParsed;
            return View();
        }

        [HttpPost]
        public IActionResult Create(User _user)
        {
            Role role = new Role();
            role.id = _user.rolNumId;
            List<Role> lstRole = new List<Role>();
            lstRole.Add(role);
            _user.roles = lstRole;
            var json = JsonSerializer.Serialize(_user);
            api.PostApi(url + "/person/", json);
            return View("Success");
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
        public IActionResult Delete(int id)
        {
            var responseUser = api.DeleteFromApi(url + "/person/" + id);
            if (responseUser.IsSuccessStatusCode)
            {
                return View("Success");
            }
            return View("Error");
        }
        //[HttpGet]
        //public IActionResult Edit(int id)
        //{
        //    var responseUser = api.GetApi(url + "/person/" + id);
        //    return View();
            
        //}
        //public IActionResult Edit(int id, User _user)
        //{
        //    var responseUser = api.UpdateFromApi(url + "/person/" + id, );
        //    return View();
            
        //}
    }
}
