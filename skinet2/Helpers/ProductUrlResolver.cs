using AutoMapper;
using Core.Entities;
using skinet2.Dtos;
using Microsoft.Extensions.Configuration;

namespace skinet2.Helpers
{
	public class ProductUrlResolver : IValueResolver<Products, ProductToReturnDto, string>
	{
		private readonly IConfiguration _config;

		public ProductUrlResolver(IConfiguration config)
        {
			_config = config;
		}


        public string Resolve(Products source, ProductToReturnDto destination, string destMember, ResolutionContext context)
		{
			if(!string.IsNullOrEmpty(source.PictureUrl))
			{
				return _config["ApiUrl"] + source.PictureUrl;

			}

			return null;
		}
	}
}
