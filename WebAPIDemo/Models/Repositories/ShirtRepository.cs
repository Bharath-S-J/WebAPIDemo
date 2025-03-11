using WebAPIDemo.Controllers;

namespace WebAPIDemo.Models.Repositories
{
    public static class ShirtRepository
    {
        private static List<Shirt> shirts = new List<Shirt>()
        {
            new Shirt { ShirtId = 1, Brand = "Puma", Color = "Blue", Gender = "Men", Price = 1100, Size = 7 },
            new Shirt { ShirtId = 2, Brand = "Nike", Color = "Black", Gender = "Men", Price = 1350, Size = 8 },
            new Shirt { ShirtId = 3, Brand = "Adidas", Color = "Red", Gender = "Women", Price = 1600, Size = 6 },
            new Shirt { ShirtId = 4, Brand = "Reebok", Color = "White", Gender = "Women", Price = 1750, Size = 5 },
            new Shirt { ShirtId = 5, Brand = "Under Armour", Color = "Green", Gender = "Men", Price = 1450, Size = 9 },
            new Shirt { ShirtId = 6, Brand = "New Balance", Color = "Yellow", Gender = "Men", Price = 1550, Size = 10 },
            new Shirt { ShirtId = 7, Brand = "Fila", Color = "Pink", Gender = "Women", Price = 1650, Size = 4 },
            new Shirt { ShirtId = 8, Brand = "ASICS", Color = "Purple", Gender = "Women", Price = 1850, Size = 3 },
            new Shirt { ShirtId = 9, Brand = "Columbia", Color = "Grey", Gender = "Men", Price = 1950, Size = 11 },
            new Shirt { ShirtId = 10, Brand = "Lacoste", Color = "Orange", Gender = "Men", Price = 2000, Size = 12 }

        };

        public static List<Shirt> GetShirts()
        {
            return shirts;
        }

        public static bool ShirtExists(int id)
        {
            return shirts.Any(x => x.ShirtId == id);
        }

        public static Shirt? GetShirtById(int id)
        {
            return shirts.FirstOrDefault(x=>x.ShirtId == id);
        }

        public static void AddShirt(Shirt shirt)
        {
            int maxId = shirts.Any() ? shirts.Max(x => x.ShirtId) : 0;
            shirt.ShirtId = maxId + 1;
            shirts.Add(shirt);
        }

        public static Shirt? getShirtByProperties(string? brand, string? gender, string? color,int? size)
        {
            return shirts.FirstOrDefault(x =>
            !string.IsNullOrWhiteSpace(brand) &&
            !string.IsNullOrWhiteSpace(x.Brand) &&
            x.Brand.Equals(brand, StringComparison.OrdinalIgnoreCase) &&
            !string.IsNullOrWhiteSpace(gender) &&
            !string.IsNullOrWhiteSpace(x.Gender) &&
            x.Gender.Equals(gender, StringComparison.OrdinalIgnoreCase) &&
            !string.IsNullOrWhiteSpace(color) &&
            !string.IsNullOrWhiteSpace(x.Color) &&
            x.Color.Equals(color, StringComparison.OrdinalIgnoreCase) &&
            size.HasValue &&
            x.Size.HasValue &&
            size.Value == x.Size.Value);

        }

        public static void UpdateShirt(Shirt shirt)
        {
            var shirtToUpdate = shirts.First(x => x.ShirtId == shirt.ShirtId);
           
            
            shirtToUpdate.Brand = shirt.Brand;
            shirtToUpdate.Color = shirt.Color;
            shirtToUpdate.Size = shirt.Size;
            shirtToUpdate.Gender = shirt.Gender;
            shirtToUpdate.Price = shirt.Price;
        }
        public static void DeleteShirt(int shirtId)
        {
            var shirt = GetShirtById(shirtId);
            if (shirt != null) shirts.Remove(shirt);
        }
    }
}
