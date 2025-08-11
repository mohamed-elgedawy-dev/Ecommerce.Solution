using AutoMapper;
using Ecommerce.APIs.Dtos;
using Ecommerce.APIs.Errors;
using Ecommerce.Core.Entities;
using Ecommerce.Core.RepositoriesContract;
using Ecommerce.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Ecommerce.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IGenericRepositories<Product> _repositories;
        private readonly IMapper _mapper;

        public ProductController( IGenericRepositories<Product> repositories , IMapper mapper   )
        {
             _repositories = repositories;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<ProductToReturnDto>> ProductGetAll()
        {
            var spec = new ProductTypeBrand();

            var products = await _repositories.GetAllWithSpecAsync(spec);
            return Ok(_mapper.Map<IEnumerable<Product>,IEnumerable<ProductToReturnDto>>(products));
        }


        [HttpGet("{id}")]

        public async Task<ActionResult<ProductToReturnDto>> GetByIdWithSpecAsync(int id)

        {
            var spec = new ProductTypeBrand(id);
            var product = await _repositories.GetByIdWithSpecAsync(spec);
            if (product == null)
            {
                return NotFound(new ApiResponse(404));
            }
            return Ok(_mapper.Map<Product,ProductToReturnDto>(product));

            




        }





    }

}
