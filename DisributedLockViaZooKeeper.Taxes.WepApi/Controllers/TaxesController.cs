using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace DisributedLockViaZooKeeper.Taxes.WepApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaxesController : ControllerBase
    {
        private readonly TaxRepository _repository;

        public TaxesController(TaxRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{index}")]
        public IActionResult GetTax([Required]string index)
        {
            return Ok(_repository.GetTax(index));
        }
        
        [HttpGet("{index}/hits")]
        public IActionResult GetHits([Required]string index)
        {
            return Ok(_repository.GetHits(index));
        }

        [HttpDelete("{index}")]
        public IActionResult Delete([Required]string index)
        {
            _repository.Clear(index);
            return Ok();
        }
    }
}