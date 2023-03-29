using System;
using System.Collections.Generic;

namespace DapperInClass
{
	public interface IDepartmentRepository
	{//INTERFACE  is template foe BEHVIOR..
		//will specify what DEPARTMENT need to behave like..
		//with DEPARTMENTS we need to potentially access ALL departments
		//and their DATA and CREATE departments...hence:
		//		"GETALLDEPARTMENTS" stubbed out method (pascal case)
		//		"CREATEDEPARTMENT" (pascal case)
		IEnumerable<Department> GetAllDepartments();
		void CreateDepartment(string Name); 
	}
}

