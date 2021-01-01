using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Models
{
    public class User
    {
        public User()
        {
            role = "user";
            orderId = 0;
        }

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(50)]
        public string FirstName { get; set; }
        [MaxLength(50)]
        public string LastName { get; set; }
        [MaxLength(70)]
        public string email { get; set; }
        public string password { get; set; }
        public string role { get; set; }
        public int orderId { get; set; }
}
}
