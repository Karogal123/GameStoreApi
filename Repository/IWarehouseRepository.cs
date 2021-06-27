using GameStore.Models;
using GameStore.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.Data
{
    public interface IWarehouseRepository : IRepository
    {
        Task<IEnumerable<Warehouse>> GetAllWareHousesAsync();
        Task<Warehouse> GetWarehouseByIdAsync(int id);
        Task UpdateWarehouseAsync(Warehouse wh);
        Task DeleteWarehouseAsync(Warehouse wh);
        Task CreateWarehouseAsync(Warehouse wh);
    }
}
