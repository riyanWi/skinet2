﻿using Core.Interfaces;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastucture.Data
{
	public class ProductRepository : IProductRepository
	{
		private readonly StoreContext _context;

		public ProductRepository(StoreContext context)
		{
			_context = context;
		}

		public async Task<Products> GetProductByIdAsync(int id)
		{
			return await _context.Products
				.Include(p => p.ProductBrand)
				.Include(p => p.ProductType)
				.FirstOrDefaultAsync(p => p.Id == id);
		}

		public async Task<IReadOnlyList<Products>> GetProductsAsync()
		{
			return await _context.Products
				 .Include(p => p.ProductBrand)
				 .Include(p => p.ProductType)
				 .ToListAsync();
		}

		public async Task<IReadOnlyList<ProductType>> GetProductTypeAsync()
		{
			return await _context.ProductType.ToListAsync();
		}

		public async Task<IReadOnlyList<ProductBrand>> GetProductBrandAsync()
		{
			return await _context.ProductBrand.ToListAsync();
		}
	}
}
