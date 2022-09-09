using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleWebFormApp.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
    }

    public static class ProductRepo
    {
        private static List<Product> products = new List<Product>();

        static ProductRepo()
        {
            products.Add(new Product { ProductId = 1, Image = "~/Images/Pic3.png", Price = 599, ProductName = "USB Converter" });
            products.Add(new Product { ProductId = 2, Image = "~/Images/Pic2.png", Price = 1599, ProductName = "Levis Blue Jeans" });
            products.Add(new Product { ProductId = 3, Image = "~/Images/Pic1.png", Price = 700, ProductName = "Faztoo Mini Wallet" });
            products.Add(new Product { ProductId = 4, Image = "~/Images/Pic4.png", Price = 499, ProductName = "Kitchen Knife" });
            products.Add(new Product { ProductId = 5, Image = "~/Images/Pic5.png", Price = 1599, ProductName = "Red Tape White Shoes" });
            products.Add(new Product { ProductId = 6, Image = "~/Images/Pic6.png", Price = 4599, ProductName = "Office Arm Chair" });
            products.Add(new Product { ProductId = 7, Image = "~/Images/Pic7.png", Price = 999, ProductName = "Studds Large Black Helmet" });
        }
        public static List<Product> Products => products;
    }
}