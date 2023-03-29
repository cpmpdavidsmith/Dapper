using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;


namespace DapperInClass
{
    class Program
    {
        //1.DELEAT APPSETTING then add APPSETTINGS to GIT IGNOR FILE
        //  then add CONNECTION CODE to that APPSETTINGS file...
        //2.DOWNLOAD NUGET PACKAGES...
        //3. ADD CONNECTION CODE to PROGRAM CLASS... 
        //these 4 lines (19-22) will find our APPSETTING.JSON file...
        static IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

        static string connString = config.GetConnectionString("DefaultConnection");
        //LINE 24:  gets connection string and stores it in "connString"
        static IDbConnection conn = new MySqlConnection(connString);
        //LINE 26: create out IDbConnection that uses MySQL, so Dapper can extend it 
        //NOW MY CONNECTION TO SQL DATABASE IS OFFICIALLY SET UP....
        //4.now I must CREATE CLASSES to define OBJECTS
        //      -CLASSES must be MAPPED/SET UP like:
        //          DATABASE TABLES
        //      and COLUMN/PROPERTIES..
        //use ORM to MAP DATA from the DATABASE to OBJECTS
        //DATABASE COLUMN will be used as PROPERTIES in our OBJECT classes  
        //5. make DEPARTMENT.CS CLASS with PROPERTIES {GET; SET;}
        //6. now create and INTERFACE for DEPARTMENT..
        //      -name interface IDEPARTMENTREPOSITORY.CS (pascal case)
        //7. now create a class that will CONFORM to IDEPARTMENTREPOSITORY.CS
        //      -name it DEPARTMENTREPOSITORY.CS (pascal case)

        static void Main(string[] args)
        {
            ListProducts();

            DeleteProduct();

            ListProducts();
        }
        public static void DeleteProduct()                                                           //we can use these methods that add user interaction with our Dapper Methods 
        {
            var prodRepo = new ProductRepository(conn);
            Console.WriteLine($"What is the productID of th product you would like to delete:");
            var productID = Convert.ToInt32(Console.ReadLine());

            prodRepo.DeleteProduct(productID);

        }
        public static void UpdateProductName()
        {
            var prodRepo = new ProductRepository(conn);

            Console.WriteLine($"What is the productID of the product you would like to update?");
            var productID = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"What is the new name you ould like for the product with an id of {productID}?");
            var updatedName = Console.ReadLine();

            prodRepo.UpdateProductName(productID, updatedName);
        }
        public static void CreateAndListProducts()
        {
            var prodRepo = new ProductRepository(conn);

            Console.WriteLine($"What is the new product name?");
            var prodName = Console.ReadLine();

            Console.WriteLine($"What is the new product's price?");
            var price = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine($"What is th new products category id?");
            var categoryID = Convert.ToInt32(Console.ReadLine());

            prodRepo.CreateProduct(prodName, price, categoryID);

            var products = prodRepo.GetAllProducts();

            foreach (var product in products)
            {
                Console.WriteLine($"{product.ProductID} {product.Name}");
            }

        }

        public static void ListProducts()
        {
            var prodRepo = new ProductRepository(conn);
            var products = prodRepo.GetAllProducts();

            //print each product from the products collection to the console
            foreach (var product in products)
            {
                Console.WriteLine($"{product.ProductID} {product.Name}");
            }
        }

        public static void ListDepartments(IDbConnection conn)
        {
            var repo = new DepartmentRepository(conn);
            var departments = repo.GetAllDepartments();
            foreach (var item in departments)
            {
                Console.WriteLine($"{item.DepartmentID} {item.Name}");
            }
        }
        public static void DepartmentUpdate()
        {
            var repo = new DepartmentRepository(conn);
            Console.WriteLine($"Would you like to update a departmen? yes or no");
            if (Console.ReadLine().ToUpper() == "Yes")
            {
                Console.WriteLine($"What is the ID of the Department you would like to update?");
                var id = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine($"What would you like to change the name of the department to?");
                var newName = Console.ReadLine();
                repo.UpdateDepartment(id, newName);
                var depts = repo.GetAllDepartments();
                foreach (var item in depts)
                {
                    Console.WriteLine($"{item.DepartmentID} {item.Name}");
                }
            }
        }
    }
}


