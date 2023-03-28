using System;
using System.Data;
using System.Collections.Generic;
using Dapper;

namespace DapperInClass
{
	public class ProductRepository : IProductRepository
	{
        //in field:
        //connection of type IDbConnection is set to PRIVATE making it only
        //ACCESSABLE in this class...
        //this Is ENCAPSULATION and positioned to provide connection to the DATABASE
        //for the METHOD below it...which can be ACCESSED by other classes but
        //the IDbConnection is not accessed
        private readonly IDbConnection _connection;
        //this METHOD   is a CONSTRUCTOR named "DapperProductRepository"
        //it is a CONSTRUCTOR because its purpose is to make a new INSTANCE of a class. 
		public ProductRepository(IDbConnection connection)                                            
		{
            _connection = connection;
		}
        //the data in the DATABASE is now available in "_connection"
        public void CreateProduct(string name, double price, int categoryID)
        {
            _connection.Execute("INSERT INTO products (Name, Price, CategoryID)" +
                "VALUES (@name, @price, @categoryID);"
                , new { name = name, price = price, categoryID = categoryID});
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _connection.Query<Product>("SELECT * FROM products;");
        }

        public void UpdateProductName(int  productID, string updatedName)
        {
            _connection.Execute("UPDATE products SET Name = @updatedName WHERE ProductID = @productID;",   
                new { updatedName = updatedName, productID = productID });
        }

        public void DeleteProduct(int productID)
        {
            _connection.Execute("DELETE FROM reviews WHERE ProductID = @productID;",
                new { productID = productID });

            _connection.Execute("DELETS FROM sale WHERE ProductID = @productID;",
                new { productID = productID });

            _connection.Execute("DELETE FROM products WHERE ProductID = @productID;",
                new { productID = productID });
        }

        
    }
}

