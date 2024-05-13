using System.Security.Cryptography;
using api.Models;
using api.Services;
using Microsoft.AspNetCore.Identity;

namespace api.Data;

public class DataInitializer
{
    private readonly ApplicationDbContext _context;
    private readonly ICategoryService _categoryService;
    private readonly IProductService _productService;
    private readonly IShelfService _shelfService;
    private readonly IShoppingListService _shoppingListService;
    private readonly UserManager<AppUser> _userManager;

    public DataInitializer(ApplicationDbContext context, ICategoryService categoryService, IProductService productService, IShelfService shelfService, IShoppingListService shoppingListService, UserManager<AppUser> userManager)
    {
        _context = context;
        _categoryService = categoryService;
        _productService = productService;
        _shelfService = shelfService;
        _shoppingListService = shoppingListService;
        _userManager = userManager;
    }

    public async Task Initialize()
    {
        ClearAll();
        
        var catFruits = new Category { Name = "Fruits" };
        var catVegetables = new Category { Name = "Vegetables" };
        var catDairy = new Category { Name = "Dairy" };
        var catMeat = new Category { Name = "Meat" };
        var catSpices = new Category { Name = "Spices" };
        var catSweets = new Category { Name = "Sweets" };
        var catFrozen = new Category { Name = "Frozen foods" };
        var catCondiments = new Category { Name = "Condiments" };
        var catHealthy = new Category { Name = "Healthy" };
        var categories = new List<Category> { catFruits, catVegetables, catDairy, catMeat, catSpices, catSweets, catFrozen, catCondiments };

        foreach (var category in categories)
            await _categoryService.CreateAsync(category);

        var warehouseShelf = new Shelf { Name = "warehouse", IsInWarehouse = true };
        await _shelfService.CreateAsync(warehouseShelf);

        var pBanana = new Product { Name = "Banana", Category = catFruits, Price = 0.80m };
        var pApple = new Product { Name = "Apple", Category = catFruits, Price = 1.00m, ImageUrl = "https://lh3.googleusercontent.com/d/14lb5pjYA_sKjM9ES4bjq1uA7UXOQPPP3"};
        var pOrange = new Product { Name = "Orange", Category = catFruits, Price = 1.20m };
        var pCarrot = new Product { Name = "Carrot", Category = catVegetables, Price = 0.75m };
        var pBroccoli = new Product { Name = "Broccoli", Category = catVegetables, Price = 1.50m };
        var pMilk = new Product { Name = "Milk", Category = catDairy, Price = 2.50m };
        var pCheese = new Product { Name = "Cheese", Category = catDairy, Price = 3.00m };
        var pChicken = new Product { Name = "Chicken", Category = catMeat, Price = 5.50m };
        var pBeef = new Product { Name = "Beef", Category = catMeat, Price = 7.00m };
        var pSalt = new Product { Name = "Salt", Category = catSpices, Price = 0.50m };
        var pPepper = new Product { Name = "Pepper", Category = catSpices, Price = 0.75m };
        var pChocolate = new Product { Name = "Chocolate", Category = catSweets, Price = 2.00m };
        var pCandy = new Product { Name = "Candy", Category = catSweets, Price = 1.50m };
        var pIceCream = new Product { Name = "Ice Cream", Category = catFrozen, Price = 3.50m };
        var pPizza = new Product { Name = "Pizza", Category = catFrozen, Price = 4.00m };
        var pFrenchFries = new Product { Name = "French Fries", Category = catFrozen, Price = 2.50m };
        var pFish = new Product { Name = "Fish", Category = catMeat, Price = 6.00m };
        var pShrimp = new Product { Name = "Shrimp", Category = catMeat, Price = 8.00m };
        var pSpinach = new Product { Name = "Spinach", Category = catVegetables, Price = 1.25m };
        var pCabbage = new Product { Name = "Cabbage", Category = catVegetables, Price = 1.00m };
        var pYogurt = new Product { Name = "Yogurt", Category = catDairy, Price = 2.00m };
        var pLemon = new Product { Name = "Lemon", Category = catFruits, Price = 0.90m };
        var pPear = new Product { Name = "Pear", Category = catFruits, Price = 1.10m };
        var pGrape = new Product { Name = "Grape", Category = catFruits, Price = 1.30m };
        var pPotato = new Product { Name = "Potato", Category = catVegetables, Price = 0.60m };
        var pTomato = new Product { Name = "Tomato", Category = catVegetables, Price = 1.70m };
        var pButter = new Product { Name = "Butter", Category = catDairy, Price = 2.80m };
        var pYogurtDrink = new Product { Name = "Yogurt Drink", Category = catDairy, Price = 2.20m };
        var pTurkey = new Product { Name = "Turkey", Category = catMeat, Price = 6.50m };
        var pPork = new Product { Name = "Pork", Category = catMeat, Price = 8.00m };
        var pCumin = new Product { Name = "Cumin", Category = catSpices, Price = 0.60m };
        var pCinnamon = new Product { Name = "Cinnamon", Category = catSpices, Price = 1.00m };
        var pCaramel = new Product { Name = "Caramel", Category = catSweets, Price = 2.50m };
        var pToffee = new Product { Name = "Toffee", Category = catSweets, Price = 2.20m };
        var pPopsicle = new Product { Name = "Popsicle", Category = catFrozen, Price = 3.00m };
        var pLasagna = new Product { Name = "Lasagna", Category = catFrozen, Price = 4.50m };
        var pOnionRings = new Product { Name = "Onion Rings", Category = catFrozen, Price = 2.80m };
        var pSalmon = new Product { Name = "Salmon", Category = catMeat, Price = 7.00m };
        var pLobster = new Product { Name = "Lobster", Category = catMeat, Price = 10.00m };
        var pLettuce = new Product { Name = "Lettuce", Category = catVegetables, Price = 1.20m };
        var pBrusselsSprouts = new Product { Name = "Brussels Sprouts", Category = catVegetables, Price = 1.50m };
        var pMustard = new Product { Name = "Mustard", Category = catCondiments, Price = 1.50m };
        var pKetchup = new Product { Name = "Ketchup", Category = catCondiments, Price = 1.75m };
        var pMayonnaise = new Product { Name = "Mayonnaise", Category = catCondiments, Price = 2.00m };
        var pQuinoa = new Product { Name = "Quinoa", Category = catHealthy, Price = 3.50m };
        var pAvocado = new Product { Name = "Avocado", Category = catHealthy, Price = 1.75m };
        var pKale = new Product { Name = "Kale", Category = catHealthy, Price = 2.25m };
        var products = new List<Product> { pBanana, pApple, pOrange, pCarrot, pBroccoli, pMilk, pCheese, pChicken, pBeef, pSalt, pPepper, pChocolate, pCandy, pIceCream, pPizza, pFrenchFries, pFish, pShrimp, pSpinach, pCabbage, pYogurt, pLemon, pPear, pGrape, pPotato, pTomato, pButter, pYogurtDrink, pTurkey, pPork, pCumin, pCinnamon, pCaramel, pToffee, pPopsicle, pLasagna, pOnionRings, pSalmon, pLobster, pLettuce, pBrusselsSprouts, pMayonnaise, pKetchup, pMustard, pKale, pAvocado, pQuinoa };

        foreach (var product in products)
            await _productService.CreateAsync(product);

        var shelf01 = new Shelf { Name = "Fruits", IsInWarehouse = false, Products = new List<Product> { pBanana, pApple } };
        var shelf02 = new Shelf { Name = "Vegetables", IsInWarehouse = false, Products = new List<Product> { pCarrot, pBroccoli } };
        var shelf03 = new Shelf { Name = "Dairy", IsInWarehouse = false, Products = new List<Product> { pMilk, pCheese } };
        var shelf04 = new Shelf { Name = "Meat", IsInWarehouse = false, Products = new List<Product> { pChicken, pBeef } };
        var shelf05 = new Shelf { Name = "Spices", IsInWarehouse = false, Products = new List<Product> { pSalt, pPepper } };
        var shelf06 = new Shelf { Name = "Sweets", IsInWarehouse = false, Products = new List<Product> { pChocolate, pCandy } };
        var shelf07 = new Shelf { Name = "Frozen foods", IsInWarehouse = false, Products = new List<Product> { pIceCream, pPizza, pFrenchFries } };
        var shelf08 = new Shelf { Name = "Other", IsInWarehouse = false, Products = new List<Product> { pFish, pShrimp } };
        var shelf09 = new Shelf { Name = "Greens", IsInWarehouse = false, Products = new List<Product> { pSpinach, pCabbage } };
        var shelf10 = new Shelf { Name = "Fruits and veggies", IsInWarehouse = false, Products = new List<Product> { pLemon, pPear, pGrape, pTomato, pLettuce, pBrusselsSprouts } };
        var shelf11 = new Shelf { Name = "Dairy and meats", IsInWarehouse = false, Products = new List<Product> { pButter, pYogurtDrink, pTurkey, pPork, pYogurt } };
        var shelf12 = new Shelf { Name = "Baking", IsInWarehouse = false, Products = new List<Product> { pCumin, pCinnamon } };
        var shelf13 = new Shelf { Name = "Treats", IsInWarehouse = false, Products = new List<Product> { pCaramel, pToffee } };
        var shelf14 = new Shelf { Name = "Chilled desserts", IsInWarehouse = false, Products = new List<Product> { pPopsicle, pLasagna } };
        var shelf15 = new Shelf { Name = "Appetizers", IsInWarehouse = false, Products = new List<Product> { pOnionRings } };
        var shelf16 = new Shelf { Name = "Seafood", IsInWarehouse = false, Products = new List<Product> { pSalmon, pLobster } };
        var shelf17 = new Shelf { Name = "Seasonal", IsInWarehouse = false, Products = new List<Product> { pOrange } };
        var shelf18 = new Shelf { Name = "Healthy choices", IsInWarehouse = false, Products = new List<Product> { pQuinoa, pKale, pAvocado} };
        var shelf19 = new Shelf { Name = "Grains and legumes", IsInWarehouse = false, Products = new List<Product> { pPotato } };
        var shelf20 = new Shelf { Name = "Condiments", IsInWarehouse = false, Products = new List<Product> { pMayonnaise, pKetchup, pMustard } };
        var shelves = new List<Shelf> { shelf01, shelf02, shelf03, shelf04, shelf05, shelf06, shelf07, shelf08, shelf09, shelf10, shelf11, shelf12, shelf13, shelf14, shelf15, shelf16, shelf17, shelf18, shelf19, shelf20 };

        foreach (var shelf in shelves)
        {
            var currProducts = shelf.Products;
            shelf.Products = new();
            await _shelfService.CreateAsync(shelf);
            foreach (var product in currProducts)
            {
                await _shelfService.MoveProductAsync(warehouseShelf.Id, shelf.Id, product.Id);
            }
        }

        var admin = new AppUser { UserName = "admin", Email = "admin@shop.com"};
        await _userManager.CreateAsync(admin, "Heslo.123");
        await _userManager.AddToRoleAsync(admin, nameof(UserRole.Admin));
        
        var user = new AppUser { UserName = "peto", Email = "peto@gmail.com"};
        await _userManager.CreateAsync(user, "Heslo.123");
        await _userManager.AddToRoleAsync(user, nameof(UserRole.User));

        var userList01 = new ShoppingList { Name = "Healthy", CreatedTime = DateTime.Now};
        var userList02 = new ShoppingList { Name = "Meat and potatoes",  CreatedTime = DateTime.Now};
        var userList03 = new ShoppingList { Name = "Party",  CreatedTime = DateTime.Now };
        var userLists = new List<ShoppingList> { userList01, userList02, userList03 };
        
        userList01.JoinProductShoppingLists.AddRange( 
            new List<JoinProductShoppingList>
            {
                new() { Product = pTomato, ProductId = pTomato.Id},
                new() { Product = pApple, ProductId = pApple.Id},
                new() { Product = pButter, ProductId = pButter.Id}
        });

        userList02.JoinProductShoppingLists.AddRange( 
            new List<JoinProductShoppingList>
            {
                new() { Product = pPotato, ProductId = pPotato.Id},
                new() { Product = pSalmon, ProductId = pSalmon.Id},
                new() { Product = pSalt, ProductId = pSalt.Id},
                new() { Product = pLemon, ProductId = pLemon.Id}
        });        

        userList03.JoinProductShoppingLists.AddRange( 
            new List<JoinProductShoppingList>
            {
                new() { Product = pBeef, ProductId = pBeef.Id},
                new() { Product = pCumin, ProductId = pCumin.Id},
                new() { Product = pFrenchFries, ProductId = pFrenchFries.Id},
                new() { Product = pTomato, ProductId = pTomato.Id},
                new() { Product = pCabbage, ProductId = pCabbage.Id},
                new() { Product = pPizza, ProductId = pPizza.Id}
        });
        
        foreach (var userList in userLists)
            await _shoppingListService.CreateAsync(user, userList);
    }
    
    
    private void ClearAll()
    {
        _context.Products.RemoveRange(_context.Products);
        _context.ShoppingLists.RemoveRange(_context.ShoppingLists);
        _context.Shelves.RemoveRange(_context.Shelves);
        _context.Categories.RemoveRange(_context.Categories);
        _context.Users.RemoveRange(_context.Users);
        
        _context.SaveChanges();
    }
}