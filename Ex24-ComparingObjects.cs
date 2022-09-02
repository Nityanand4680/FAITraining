using System;
using System.Collections.Generic;

namespace SampleConApp
{
    class Product : IComparable<Product>
    {
        static int no = 1000;
        public Product()
        {
            ProductId = ++no;
        }
        public int ProductId { get; private set; }
        public string ProductName { get; set; }
        public int ProductCost { get; set; }
        public string  Category { get; set; }

        //Default sort is by ProductCost...
        public int CompareTo(Product other)
        {
            if (ProductCost < other.ProductCost)
                return -1;
            else if (ProductCost > other.ProductCost)
                return 1;
            else
                return 0;
        }
        public override string ToString()
        {
            return $"Name: {ProductName}\tPrice: {ProductCost}";
        }
    }

    static class ProductRepo
    {
        private static List<Product> getAll()
        {
            var list = new List<Product>();
            list.Add(new Product { ProductName = "Tennis Racquet", Category = "Sports", ProductCost = 560 });
            list.Add(new Product { ProductName = "Tennis Ball", Category = "Sports", ProductCost = 60 });
            list.Add(new Product { ProductName = "Smart Office Chair", Category = "Furniture", ProductCost = 4500 });
            list.Add(new Product { ProductName = "Laptop Table", Category = "Furniture", ProductCost = 1560 });
            list.Add(new Product { ProductName = "USB Pen Drive 16GB", Category = "Electronics", ProductCost = 800 });
            list.Add(new Product { ProductName = "Ear Phone", Category = "Electronics", ProductCost = 2000 });
            return list;
        }
        public static List<Product> AllProducts
        {
            get
            {
                return getAll();
            }
        }
    }

    enum ProductCriteria {  ByName, ByCategory, ById };
    class ProductComparer : IComparer<Product>
    {
        private ProductCriteria _criteria;
        public ProductComparer(ProductCriteria criteria)
        {
            _criteria = criteria;
        }
        public int Compare(Product x, Product y)
        {
            switch (_criteria)
            {
                case ProductCriteria.ByName:
                    return x.ProductName.CompareTo(y.ProductName);
                    
                case ProductCriteria.ByCategory:
                    return x.Category.CompareTo(y.Category);
                   
                case ProductCriteria.ById:
                    return x.ProductId.CompareTo(y.ProductId);
                default:
                    return x.CompareTo(y);
            }
        }
    }
    class ComparingObjectsDemo
    {
        static void Main(string[] args)
        {
            var list = ProductRepo.AllProducts;
            Console.WriteLine("Select any from the above list");
            Array possibleValues = Enum.GetValues(typeof(ProductCriteria));
            foreach (var value in possibleValues) Console.WriteLine(value);
            ProductCriteria input = (ProductCriteria)Enum.Parse(typeof(ProductCriteria), Console.ReadLine());
            list.Sort(new ProductComparer(input));//It will try to call any of the object's IComparable Function..

            foreach (var item in list) Console.WriteLine(item);
        }
    }
}