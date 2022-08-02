

using Bussiness.Concrete;
using DataAccess.Concrete.EntityFramework;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            // ProductTest();
            // CategoryTest();
            
            ProductManager productManager = new ProductManager(new EfProductDal());
            var result = productManager.GetProductDetails();
            if (result.Succes==true)
            {
                foreach (var product in result.Data)
                {
                    Console.WriteLine(product.productName + "/" + product.CategoryName);

                }
            }
            else
            {

                Console.WriteLine(result.Message);
            }


            Console.ReadLine();
        }

        private static void CategoryTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());

            foreach (var category in categoryManager.GetAll())
            {
                Console.WriteLine(category.CategoryName);
            }
        }

        //private static void ProductTest()
        //{
        //    ProductManager productManager = new ProductManager(new EfProductDal());

        //    foreach (var product in productManager.GetUnitprice(40, 100))
        //    {
        //        Console.WriteLine(product.ProductName);

        //    }
        //}
    }
    }

