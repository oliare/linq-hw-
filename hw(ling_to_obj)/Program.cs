    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    

    namespace hw_ling_to_obj_
    {
        internal class Program
        {
            static void Main(string[] args)
            {
                Product[] products = new[]
                {
                    new Product{Name = "Cofee Mashine", Price = 800, Country = "China", Year = 2021, Category="Appliances"},
                    new Product{Name = "Washing Machine", Price = 820, Country = "Germany", Year = 2021, Category="Appliances"},
                    new Product{Name = "Dishwasher", Price = 330, Country = "Germany", Year = 2021, Category="Appliances"},
                    new Product{Name = "Fridge", Price = 1000, Country = "Germany", Year = 2019, Category="Appliances"},
                    new Product{Name = "Laptop", Price = 1200, Country = "USA", Year = 2023, Category="Electronics"},
                    new Product{Name = "Phone", Price = 750, Country = "USA", Year = 2022, Category="Electronics"},
                    new Product{Name = "Smart TV", Price = 587, Country = "South Korea", Year = 2023, Category="Electronics"},
                    new Product{Name = "Headphones", Price = 120, Country = "China", Year = 2022, Category="Electronics"},
                    new Product{Name = "Table", Price = 294, Country = "Poland", Year = 2022, Category="Furniture"},
                    new Product{Name = "Blender", Price = 50, Country = "Ukraine", Year = 2023, Category="Kitchen"},
                    new Product{Name = "Toaster", Price = 69, Country = "Ukraine", Year = 2023, Category="Kitchen"},
          };

                ProdThisYear(products);
                InSelectedCountry("Germany", products);
                MinMaxInCategory("Electronics", products);
                NotProdInUkr(products);
                ProdCountInCategory(products);
                GroupCtgrySortByYear(products);
            }

            public class Product
            {
                public string Name { get; set; }
                public double Price { get; set; }
                public string Country { get; set; }
                public int Year { get; set; }
                public string Category { get; set; }
                public override string ToString()
                {
                    return $"Category: {Category,-15} Name: {Name,-15} Price: {Price, -10}" +
                        $"Country: {Country,-13} Year: {Year} ";
                }
            }

            static void ProdThisYear(params Product[] products)
            {
                var sorted = products.Where(x => x.Year == 2023).OrderByDescending(x => x.Price);
                Console.WriteLine("1) Products manufactured this year (in descending order): ");
                foreach (var product in sorted)
                {
                    Console.WriteLine(product.ToString());
                }
                Console.WriteLine();
            }

            static void InSelectedCountry(string country, params Product[] products)
            {
                var sort = from i in products where i.Country == country select i;
                Console.WriteLine($"2) The number of products manufactured in {country} --> {sort.Count()}\n");
            }

            static void MinMaxInCategory(string category, params Product[] products)
            {
                var sort = from i in products
                           where i.Category == category
                           orderby i.Price descending
                           select i;
                var min = sort.Select(x => x.Price).Min();
                var max = sort.Select(x => x.Price).Max();
                Console.WriteLine($"3) The cheapest product of the '{category}': {min}\n" +
                    $"The most expensive product of the '{category}': {max}\n");
            }
            static void NotProdInUkr(params Product[] products)
            {
                var sort = (from i in products
                            where i.Country != "Ukraine"
                            select i.Category).Distinct();
                Console.WriteLine($"4) Categories whose products aren't manufactured in Ukraine: {string.Join(", ", sort)}\n");
            }

            static void ProdCountInCategory(params Product[] products)
            {
                var sort = products.GroupBy(i => i.Category).OrderBy(list => list.Count());
                Console.WriteLine("5) Number of products in each category:");
                Console.WriteLine("{0,-17} {1,0}", "Category:", "Count:");
                foreach (var item in sort)
                {
                    Console.WriteLine($"{item.Key,-19} {item.Count()}");
                }
                Console.WriteLine();
            }

            static void GroupCtgrySortByYear(params Product[] products)
            {
                var sort = products.OrderBy(i => i.Year).GroupBy(i => i.Category);
                Console.WriteLine("6) Grouped by category and sorted by date of manufacture: ");
                foreach (var group in sort)
                {
                    Console.WriteLine($"{group.Key} >>>");
                    foreach (var product in group)
                    {
                        Console.WriteLine($"\tProduct: {product.Name,-15}Date: {product.Year}");
                    }
                    Console.WriteLine();
                }
            }

        }
    }
