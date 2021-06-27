using GameStore.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.Dtos
{
    public class GameDto
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int WarehouseId { get; set; }
        public int AuthorId { get; set; }

    }
}
