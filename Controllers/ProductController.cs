using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YungChingAPI.Models;

namespace YungChingAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController(MasterContext _masterContext) : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return _masterContext.Products;
        }
    }
}
