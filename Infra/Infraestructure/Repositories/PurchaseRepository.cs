using Infra.Infraestructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Purchase;
using Microsoft.EntityFrameworkCore;

namespace Infra.Infraestructure.Repositories
{
    public class PurchaseRepository : IPurchaseRepository
    {
        private readonly AppDbContext _context;

        public PurchaseRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Add(Purchases entity)
        {
            int entries = 0;
            _context.Add(entity);
            entries = await _context.SaveChangesAsync();
            return entries > 0;
        }

        public async Task<IEnumerable<Purchases>> Get()
        {
            IQueryable<Purchases> query = _context.Purchases;

            query.Include(p => p.Buyer)
                .Include(p => p.Products)
                .AsNoTracking();

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<Purchases>> GetByBuyerId(string buyerId)
        {

            IQueryable<Purchases> query = _context.Purchases;

            query.Include(p => p.Buyer)
                .Include(p => p.Products)
                .AsNoTracking();

            return await query.Where(p => p.BuyerId == buyerId).ToListAsync();
  
        }

        public async Task<Purchases> GetOne(string Id)
        {
            IQueryable<Purchases> query = _context.Purchases;

            query.Include(p => p.Buyer)
                .Include(p => p.Products)
                .AsNoTracking();

            return await query.FirstOrDefaultAsync(p=> p.Id == Id);
        }

        public async Task<bool> Remove(Purchases entity)
        {
            int entriesDB = 0;

            _context.Remove(entity);
            entriesDB = await _context.SaveChangesAsync();

            return entriesDB > 0;
        }

        public async Task<bool> Update(Purchases entity)
        {
            int entriesDB = 0;

            _context.Update(entity);
            entriesDB = await _context.SaveChangesAsync();

            return entriesDB > 0;
        }
    }
}
