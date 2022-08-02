﻿using Core.DataAccsess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product, Northwindcontext>, IProductDal
    {
        public List<ProductDetailDto> GetProductDetails()
        {
            using (Northwindcontext context=new Northwindcontext())
            {
                var result = from p in context.Products
                             join c in context.Categories
                             on p.CategoryId equals c.CategoryId
                             select new ProductDetailDto
                             {
                                 ProductId=p.ProductId,productName=p.ProductName,
                                 UnitsInStock=p.UnitsInStock,CategoryName=c.CategoryName
                             };

                       return result.ToList();
                          
            }
        }
    }
}
