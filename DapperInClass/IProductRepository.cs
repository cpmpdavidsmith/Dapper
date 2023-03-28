using System;
using System.Collections.Generic;

namespace DapperInClass
{
	public interface IProductRepository
	{
		public IEnumerable<Product> GetAllProducts();
		public void CreateProduct(string name, double price, int categoryID); 
	}
}

