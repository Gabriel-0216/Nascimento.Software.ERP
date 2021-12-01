using Domain.Entities.Product;
using Infra.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Infraestructure.Repositories
{
    public class ProductRepository : IRepository<Products>
    {
        private readonly AppDbContext _context;
        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Add(Products entity)
        {
            int entriesDb = 0;
            _context.Products.Add(entity);
            entriesDb = await _context.SaveChangesAsync();

            return entriesDb > 0;
        }

        public async Task<IEnumerable<Products>> Get()
        {
            IQueryable<Products> query = _context.Products;
            query.Include(p => p.ProductName);
            return await query.ToListAsync();
        }

        public async Task<Products> GetOne(string Id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == Id);
            if (product == null) return null;

            return product;

        }

        public async Task<bool> Remove(Products entity)
        {
            int entriesDb = 0;
            _context.Products.Remove(entity);
            entriesDb = await _context.SaveChangesAsync();
            return entriesDb > 0;
        }

        public async Task<bool> Update(Products entity)
        {
            int entriesDb = 0;
            _context.Products.Update(entity);
            entriesDb = await _context.SaveChangesAsync();
            return entriesDb > 0;
        }
    }
}
