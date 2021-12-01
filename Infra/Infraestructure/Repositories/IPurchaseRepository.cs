using Domain.Entities.Purchase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Infraestructure.Repositories
{
    public interface IPurchaseRepository : IRepository<Purchases>
    {
        Task<IEnumerable<Purchases>> GetByBuyerId(string buyerId);
    }
}
