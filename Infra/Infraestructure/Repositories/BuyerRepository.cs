using Domain.Entities.Client;
using Infra.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Infraestructure.Repositories
{
    public class BuyerRepository : IRepository<Buyer>
    {
        private readonly AppDbContext _context;

        public BuyerRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Add(Buyer entity)
        {
            int entriesDB = 0;
            _context.Buyers.Add(entity);
            entriesDB = await _context.SaveChangesAsync();
            return entriesDB > 0;
        }

        public async Task<IEnumerable<Buyer>> Get()
        {
            var list = await _context.Buyers
                .Include(p=> p.name)
                .Include(p=> p.Address)
                .Include(p => p.CellPhoneNumbers)
                .Include(p => p.Emails)
                .AsNoTracking()
                .ToListAsync();


            return list;
        }

        public async Task<Buyer> GetOne(string Id)
        {
            var list = await _context.Buyers
                .Include(p => p.name)
                .Include(p => p.Address)
                .Include(p => p.CellPhoneNumbers)
                .Include(p => p.Emails)
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == Id);

            if (list == null) return null;

            return list;
        }

        public async Task<bool> Remove(Buyer entity)
        {
            int entriesDB = 0;
            _context.Buyers.Remove(entity);
            entriesDB = await _context.SaveChangesAsync();

            return entriesDB > 0;
        }

        public async Task<bool> Update(Buyer entity)
        {
            int entriesDB = 0;
            _context.Buyers.Update(entity);
            entriesDB = await _context.SaveChangesAsync();

            return entriesDB > 0;
        }
    }
}
