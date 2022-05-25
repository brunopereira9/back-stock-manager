using Microsoft.AspNetCore.Mvc;
using stock_manager.Persistence.Entities;
using stock_manager.Persistence.Models;
using stock_manager.Persistence.Repositories;

namespace stock_manager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _repository;
        public ProductController(IProductRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Product
        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetAll()
        {
            try{
                var products = _repository.GetAll();
                if (products == null)
                {
                    return NotFound();
                }

                return Ok(products);
            }catch(Exception e){
                return BadRequest(e.Message);
            }
        }

        // GET: api/Product/5
        [HttpGet("{id}")]
        public ActionResult<Product> GetById(int id)
        {
            try{
                var product = _repository.GetById(id);
                if (product == null)
                {
                    return NotFound();
                }

                return Ok(product);
            }catch(Exception e){
                return BadRequest(e.Message);
            }
        }

        // PUT: api/Product/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult Update(int id, ProductModel model)
        {
            try{
                if (_repository.ProductExists(id))
                {
                    var product = _repository.GetById(id);
                    var stock = product.StockConferences
                        .Find(
                            item => item.Price == model.StockConference.Price && item.Quantity == model.StockConference.Quantity
                        );
                    if(stock == null)
                    {
                        product.SetStockConference(model.StockConference);
                    }
                    product.SetName(model.Name);
                    _repository.Update(product);
                    return Ok();
                }
                else
                {
                    return NotFound();
                }
            }catch(Exception e){
                return BadRequest(e.Message);
            }
        }

        // POST: api/Product
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<Product> Insert(ProductModel productModel)
        {
            try{
                if(productModel.Name.Length < 3){
                    return BadRequest("Name length must be at least 3 characters long.");
                }
                var product = new Product(productModel.Name);
                product.SetStockConference(productModel.StockConference);
                _repository.Insert(product);

                return CreatedAtAction("Insert", new { name = product.Name }, product);
            }catch(Exception e){
                return BadRequest(e.Message);
            }
        }

        // DELETE: api/Product/5
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            try{
                var product = _repository.GetById(id);
                
                if (product == null)
                {
                    return NotFound();
                }

                _repository.Remove(product);

                return NoContent();
            }catch(Exception e){
                return BadRequest(e.Message);
            }
        }
    }
}
