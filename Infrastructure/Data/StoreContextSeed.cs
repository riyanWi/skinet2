

using System.Text.Json;
using Core.Entities;

namespace Infrastructure.Data
{
	public class StoreContextSeed
	{
		public static async Task SeedAsync(StoreContext context)
		{
			if (!context.ProductBrand.Any())
			{
				var brandsData = File.ReadAllText("../Infrastucture/Data/SeedData/brands.json");
				var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);
				context.ProductBrand.AddRange(brands);
			}

			if (!context.ProductType.Any())
			{
				var typeData = File.ReadAllText("../Infrastucture/Data/SeedData/types.json");
				var types = JsonSerializer.Deserialize<List<ProductType>>(typeData);
				context.ProductType.AddRange(types);
			}

			if (!context.Products.Any())
			{
				var productData = File.ReadAllText("../Infrastucture/Data/SeedData/products.json");
				var products = JsonSerializer.Deserialize<List<Products>>(productData);
				context.Products.AddRange(products);
			}

			if (context.ChangeTracker.HasChanges())
			{
				await context.SaveChangesAsync();
			}
		}

	}
}
