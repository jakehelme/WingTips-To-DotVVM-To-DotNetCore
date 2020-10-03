﻿using System;
using System.Linq;
using System.Web.UI;
using WingtipToys.Models;
using System.Web.ModelBinding;

namespace WingtipToys
{
    public partial class ProductList : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IQueryable<Product> GetProducts([QueryString("id")] int? categoryId, [RouteData] string categoryName)
        {
            var _db = new ProductContext();
            IQueryable<Product> query = _db.Products;

            if (categoryId.HasValue && categoryId > 0)
            {
                query = query.Where(p => p.CategoryID == categoryId);
            }

            if (!string.IsNullOrEmpty(categoryName))
            {
                query = query.Where(p =>
                    string.Compare(p.Category.CategoryName,
                    categoryName) == 0);
            }
            return query;
        }
    }
}