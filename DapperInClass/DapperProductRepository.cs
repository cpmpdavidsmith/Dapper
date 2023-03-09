using System;
using System.Data;
using System.Collections.Generic;
using Dapper;

namespace DapperInClass
{
	public class DapperProductRepository : IProductRepository
	{
        private readonly IDbConnection _connection; //field called _connection of type IDbConnection 
		public DapperProductRepository(IDbConnection connection)            //the private message is an example oof "encapsulation" where every time an instance is made of line 7, a connection(with password!!) called 'IDbConnection' is run in 'constructor' line 11 and stored in field (which is unaccessable by the world) and is 'private" line 10
		{
            _connection = connection;
		}

        IEnumerable<Product> IProductRepository.GetAllProducts()
        {
            return _connection.Query<Product>("SELECT * FROM products");
        }
    }
}

