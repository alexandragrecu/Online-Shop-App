using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Models
{
    public class Product
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(200)]
        public string Name  { get; set; }
        public float Price  { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        public int OrderId { get; set; }
    }
}
