using Microsoft.AspNetCore.Mvc;
using Core.Interfaces;
using Core.Entities;
using Core.Specifications;
using skinet2.Dtos;
using AutoMapper;
using skinet2.Errors;

namespace skinet2.Controllers
{
	
	public class ProductsController : BaseApiController
	{
		private readonly IGenericRepository<Products> _productsRepo;
		private readonly IGenericRepository<ProductBrand> _productBrandRepo;
		private readonly IGenericRepository<ProductType> _productTypeRepo;
		private readonly IMapper _mapper;

		public ProductsController(
			IGenericRepository<Products> productsRepo,
			IGenericRepository<ProductBrand> productBrandRepo,
			IGenericRepository<ProductType> productTypeRepo,
			IMapper mapper)
		{
			_productsRepo = productsRepo;
			_productBrandRepo = productBrandRepo;
			_productTypeRepo = productTypeRepo;
			_mapper = mapper;
		}

		[HttpGet]
		public async Task<ActionResult<List<ProductToReturnDto>>> GetProducts([FromQuery]ProductSpecParams productParams)
		{
			var spec = new ProductsWithTypesAndBrandsSpecifications(productParams);

			var products = await _productsRepo.ListAsync(spec);

			return Ok(_mapper.Map<IReadOnlyList<Products>, IReadOnlyList<ProductToReturnDto>>(products));
		}

		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
		public async Task<ActionResult<ProductToReturnDto>> GetProducts(int id)
		{
			var spec = new ProductsWithTypesAndBrandsSpecifications(id);

			var product = await _productsRepo.GetEntityWithSpec(spec);

			if (product == null) return NotFound(new ApiResponse(404));

			return _mapper.Map<Products, ProductToReturnDto>(product);
		}

		[HttpGet("brands")]
		public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
		{
			return Ok(await _productBrandRepo.ListAllAsync());
		}

		[HttpGet("types")]
		public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
		{
			return Ok(await _productTypeRepo.ListAllAsync());
		}
	}
}
