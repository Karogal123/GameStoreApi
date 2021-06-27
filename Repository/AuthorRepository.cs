using GameStore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.Data
{
    public class AuthorRepo : IAuthorRepository
    {
        private readonly GamesContext _context;

        public AuthorRepo(GamesContext context)
        {
            _context = context;
        }

        public async Task CreateAuthorAsync(Author author)
        {
            await _context.Authors.AddAsync(author);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAuthorAsync(Author author)
        {
            _context.Authors.Remove(author);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Author>> GetAllAuthorsAsync()
            => await _context.Authors.Include(e => e.Games).ToListAsync();

        public async Task<Author> GetAuthorByIdAsync(int id)
            => await _context.Authors.Include(e => e.Games).SingleOrDefaultAsync(x => x.Id == id);

        public async Task UpdateAuthorAsync(Author author)
        {
            _context.Authors.Update(author);
            await _context.SaveChangesAsync();
        }

    }
}
