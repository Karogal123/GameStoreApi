using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.Dtos
{
    public class WarehouseDto
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string City { get; set; }
    }
}
