using AutoMapper;
using Ecommerce.APIs.Dtos;
using Ecommerce.APIs.Errors;
using Ecommerce.APIs.Helper;
using Ecommerce.Core.Entities;
using Ecommerce.Core.RepositoriesContract;
using Ecommerce.Core.Specification;
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
        private readonly IGenericRepositories<ProductBrand> _brandsRepo;
        private readonly IGenericRepositories<ProductCategory> _categoriesRepo;
        private readonly IMapper _mapper;

        public ProductController( IGenericRepositories<Product> repositories,
            IGenericRepositories<ProductBrand> brandsRepo ,
            IGenericRepositories<ProductCategory>categoriesRepo
            , IMapper mapper   )
        {
             _repositories = repositories;
             _brandsRepo = brandsRepo;
             _categoriesRepo = categoriesRepo;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductToReturnDto>>> ProductGetAll( [FromQuery] ProductSpecParams specParams)
        {
            var spec = new ProductTypeBrand(specParams);
            
            var products = await _repositories.GetAllWithSpecAsync(spec);
            var data = _mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDto>>(products);
            var countSpec = new ProductWithFiltrationForCountSpec(specParams);

            var totalItems = await _repositories.GetCountWithSpecAsync(countSpec);


            return Ok(new Pagination<ProductToReturnDto>(specParams.PageSize,specParams.PageIndex,totalItems,data));
        }


        [ProducesResponseType(typeof(ProductToReturnDto),StatusCodes.Status200OK)]

        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]





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

        [HttpGet("brands")]

        public async Task<ActionResult< IReadOnlyList<ProductBrand>>> GetAllBrands()
        {


            var brands =  await _brandsRepo.GetAllAsync();

            return Ok(brands);
        }



        [HttpGet("categories")]

        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetAllCategories()
        {


            var categories = await _categoriesRepo.GetAllAsync();

            return Ok(categories);
        }

    }

}
