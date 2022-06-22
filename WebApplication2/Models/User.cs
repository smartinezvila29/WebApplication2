using System.Collections.Generic;

namespace WebApplication2.Models
{
    public class User
    {
        public string userName { get; set; }
        public string password { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string documentType { get; set; }
        public int document { get; set; }
        public string email { get; set; }
        public List<Role> roles { get; set; }
        public int rolNumId { get; set; }

    }
}
