using GeekShopping.ProductAPI.Data.ValueObjects;
using GeekShopping.ProductAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.ProductAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _repository;

        public ProductController(IProductRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductVO>>> FindAll()
        {
            var products = await _repository.FindAll();
            if(products == null) return NotFound();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductVO>> FindById(long id)
        {
            var product = await _repository.FindById(id);
            if(product == null) return NotFound();
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<ProductVO>> Create(ProductVO vo)
        {
            if(vo == null) return BadRequest();
            var result = await _repository.Create(vo);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<ProductVO>> Put(ProductVO vo)
        {
            if(vo == null) return BadRequest();
            var produtoAtualizado = await _repository.Update(vo);
            return Ok(produtoAtualizado);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            var produtoDeletado = await _repository.Delete(id);
            if(!produtoDeletado) return BadRequest();

            return Ok(produtoDeletado);
        }
    }
}
