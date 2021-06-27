using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.Models
{
    public class Game
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public Warehouse Warehouse { get; set; }
        public int WarehouseId { get; set; }
        public Author Author { get; set; }
        public int AuthorId { get; set; }
    }
}
