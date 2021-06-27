using GameStore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.Data
{
    public class WarehouseRepository : IWarehouseRepository
    {
        private readonly GamesContext _context;

        public WarehouseRepository(GamesContext context)
        {
            _context = context;
        }

        public async Task CreateWarehouseAsync(Warehouse wh)
        {
            await _context.AddAsync(wh);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteWarehouseAsync(Warehouse wh)
        {
            _context.Remove(wh);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Warehouse>> GetAllWareHousesAsync()
            => await _context.Warehouses.Include(e => e.Games).ToListAsync();

        public async Task<Warehouse> GetWarehouseByIdAsync(int id)
            => await _context.Warehouses.Include(e => e.Games).SingleOrDefaultAsync(x => x.Id == id);

        public async Task UpdateWarehouseAsync(Warehouse wh)
        {
            _context.Warehouses.Update(wh);
            await _context.SaveChangesAsync();
        }
    }
}
