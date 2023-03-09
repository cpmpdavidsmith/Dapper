using System;
namespace DapperInClass
{
	public interface IProductRepository
	{
		IEnumerable<Product> GetAllProducts();
	}
}

