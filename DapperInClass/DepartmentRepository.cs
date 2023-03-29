using System;
using System.Data;
using System.Collections.Generic;
using Dapper;

namespace DapperInClass
{
	public class DepartmentRepository : IDepartmentRepository
	{
        private readonly IDbConnection _connection;
        //PRIVATE  method placed in FIELD to allow access to methods within
        //class
        //READONLY MODIFIER ensures the field can only be given a value during
        //its initialization or in its class constructor. 
		public DepartmentRepository(IDbConnection connection)
		{
            _connection = connection;
		}

        public IEnumerable<Department> GetAllDepartments()
        {
            return _connection.Query<Department>("SELECT * FROM departments;");
        }//this METHOD gets ALL the DEPARTMENT'S:  NAME    and    DEPARTMENTID
        //      and stores it in a COLLECTION/LIST....

        public void CreateDepartment(string name)
        {
            _connection.Execute("INSERT INTO departments Name Values(@name);", new { name = name });
        }

    
        public void UpdateDepartment(int id, string newName)
        {
            _connection.Execute("UPDATE departments SET Name = @newName WHERE DepartmentID = @id;", new { newName = newName, id = id });
        }
    }
}

