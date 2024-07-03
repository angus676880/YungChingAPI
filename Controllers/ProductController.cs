using Microsoft.AspNetCore.Mvc;
using YungChingAPI.Models;
using YungChingAPI.Request;
using YungChingAPI.Rseponse;
using YungChingAPI.Services;
using YungChingAPI.Utils;

namespace YungChingAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController(
        IProductService _productService
        ) : ControllerBase
    {
        [HttpGet]
        [Route("AllProduct")]
        public ActionResult<ApiResponse<List<Product>>> GetAllProduct()
        {
            try
            {
                var response = _productService.GetAll();
                return Ok(new ApiResponse<List<Product>>("0000", response));
            }
            catch (MyException ex)
            {
                return Ok(new ApiResponse<object>(ex.ErrorCode, ex.ErrorMessage));
            }
            catch (Exception ex)
            {
                return Ok(new ApiResponse<object>("9999", ex.Message));
            }
        }
        [HttpGet]
        [Route("OneProduct")]
        public ActionResult<ApiResponse<Product>> GetOneProduct(int Id)
        {
            try
            {
                if (Id <= 0) 
                {
                    return Ok(new ApiResponse<object>("1001", "Paramater is required 'Id'"));
                }
                var response = _productService.GetById(Id);
                 
                return Ok(new ApiResponse<Product>("0000", response));
            }
            catch (MyException ex)
            {
                return Ok(new ApiResponse<object>(ex.ErrorCode, ex.ErrorMessage));
            }
            catch (Exception ex)
            {
                return Ok(new ApiResponse<object>("9999", ex.Message));
            }
        }
        [HttpPost]
        [Route("OneProduct")]
        public ActionResult<ApiResponse<object>> AddOneProduct(AddProductRequest data)
        {
            try
            {
                if (data.SupplierId <= 0)
                {
                    return Ok(new ApiResponse<object>("1001", "Paramater is required 'SupplierId'"));
                }
                if (data.CategoryId <= 0)
                {
                    return Ok(new ApiResponse<object>("1001", "Paramater is required 'CategoryId'"));
                }
                _productService.AddProduct(data);

                return Ok(new ApiResponse<object>("0000","success"));
            }
            catch (MyException ex)
            {
                return Ok(new ApiResponse<object>(ex.ErrorCode, ex.ErrorMessage));
            }
            catch (Exception ex)
            {
                return Ok(new ApiResponse<object>("9999", ex.Message));
            }
        }
        [HttpPut]
        [Route("OneProduct")]
        public ActionResult<ApiResponse<object>> UpdateOneProduct(UpdateProductRequest data)
        {
            try
            {
                if (data.ProductId <= 0)
                {
                    return Ok(new ApiResponse<object>("1001", "Paramater is required 'ProductId'"));
                }
                if (data.SupplierId <= 0)
                {
                    return Ok(new ApiResponse<object>("1001", "Paramater is required 'SupplierId'"));
                }
                if (data.CategoryId <= 0)
                {
                    return Ok(new ApiResponse<object>("1001", "Paramater is required 'CategoryId'"));
                }
                _productService.UpdateProduct(data);

                return Ok(new ApiResponse<object>("0000", "success"));
            }
            catch (MyException ex)
            {
                return Ok(new ApiResponse<object>(ex.ErrorCode, ex.ErrorMessage));
            }
            catch (Exception ex)
            {
                return Ok(new ApiResponse<object>("9999", ex.Message));
            }
        }
        [HttpDelete]
        [Route("OneProduct")]
        public ActionResult<ApiResponse<object>> DeleteOneProduct(DeleteProductRequest data)
        {
            try
            {
                if (data.ProductId <= 0)
                {
                    return Ok(new ApiResponse<object>("1001", "Paramater is required 'ProductId'"));
                }
                _productService.DeleteProduct(data.ProductId);

                return Ok(new ApiResponse<object>("0000", "success"));
            }
            catch (MyException ex)
            {
                return Ok(new ApiResponse<object>(ex.ErrorCode, ex.ErrorMessage));
            }
            catch (Exception ex)
            {
                return Ok(new ApiResponse<object>("9999", ex.Message));
            }
        }
    }
}
