using Domain.Entities.Client;
using Infra.Infraestructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NascimentoERP.Api.DTO;

namespace NascimentoERP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuyersController : ControllerBase
    {
        [HttpGet]
        [Route("listarTodos")]
        public async Task<ActionResult> Get([FromServices] IRepository<Buyer> _repo)
        {
            var list = await _repo.Get();
            if (list == null)
            {
                return BadRequest();
            }
            return Ok(list);
        }

        [HttpPost]
        [Route("registrar")]
        public async Task<ActionResult> Create([FromServices] IRepository<Buyer> _repo, BuyerDTO buyerDTO)
        {
            if (ModelState.IsValid)
            {
                var buyer = new Buyer();
                if (buyerDTO.Emails != null)
                { 
                    foreach(var item in buyerDTO.Emails)
                    {
                        buyer.AddEmail(item.email);
                    }
                }
                if(buyerDTO.cellphones != null)
                {
                    foreach(var item in buyerDTO.cellphones)
                    {
                        buyer.AddCellphone(item.Number);
                    }
                }
                buyer.SetName(buyerDTO.Name, buyerDTO.LastName);
                if(buyerDTO.CPF != null) buyer.SetCPF(buyerDTO.CPF);

                buyer.SetAddress(buyerDTO.Address.Street, buyerDTO.Address.Number,
                    buyerDTO.Address.City, buyerDTO.Address.State, buyerDTO.Address.ZipCode);

                buyer.CreatedBy = "Gabriel";

                var repoResult = await _repo.Add(buyer);
                if (repoResult)
                {
                    return Ok();
                }
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return BadRequest();
        }

        [HttpDelete]
        [Route("deletar")]
        public async Task<ActionResult> Deletar([FromServices] IRepository<Buyer> _repo, string Id)
        {
            if (string.IsNullOrWhiteSpace(Id)) return BadRequest();

            var buyer = await _repo.GetOne(Id);
            if (buyer == null) return BadRequest();
            var deleted = await _repo.Remove(buyer);
            if (deleted) return Ok("Deletado");


            return StatusCode(StatusCodes.Status500InternalServerError);


        }
    }
}
