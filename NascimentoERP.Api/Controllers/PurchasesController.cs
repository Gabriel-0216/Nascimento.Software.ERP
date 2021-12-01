using Domain.Entities.Product;
using Domain.Entities.Purchase;
using Infra.Infraestructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NascimentoERP.Api.DTO;

namespace NascimentoERP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchasesController : ControllerBase
    {
        [HttpGet]
        [Route("listarTodasCompras")]
        public async Task<ActionResult> Get([FromServices] IPurchaseRepository _repo)
        {
            var list = await _repo.Get();
            if (list == null) return BadRequest();
            return Ok(list);
        }

        [HttpGet]
        [Route("listarComprasPorCliente")]
        public async Task<ActionResult> GetByBuyer([FromServices] IPurchaseRepository _repo, string Id)
        {
            var list = await _repo.GetByBuyerId(Id);
            if (list == null) return BadRequest();
            return Ok(list);
        }

        [HttpPost]
        [Route("finalizarCompra")]
        public async Task<ActionResult> PurchasePost([FromServices] IPurchaseRepository _repo,
            [FromServices] IRepository<Products> _productRepo,
            PurchaseDTO purchaseDTO)
        {
            if (ModelState.IsValid)
            {

                var purchaseEntity = new Purchases();
                purchaseEntity.SetBuyer(purchaseDTO.BuyerId);
                foreach (var item in purchaseDTO.Products)
                {
                    var product = await _productRepo.GetOne(item.Id);
                    if (product != null) purchaseEntity.AddProduct(product);
                }

                purchaseEntity.FinishPurchase();

                var repoInsert = await _repo.Add(purchaseEntity);

                if (repoInsert) return Ok("Compra finalizada com sucesso");

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return BadRequest();
        }

    }
}
