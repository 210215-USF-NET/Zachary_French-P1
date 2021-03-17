using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using OSDL;
using OSModels;
using Microsoft.EntityFrameworkCore;

namespace OSTesting
{
    /// <summary>
    /// test class for methods in my data layer
    /// </summary>
    public class OSRepoTest
    {
        private readonly DbContextOptions<OSDBContext> options;

        public OSRepoTest()
        {
            options = new DbContextOptionsBuilder<OSDBContext>()
                .UseSqlite("Filename=Test.db")
                .Options;
            Seed();
        }

        [Fact]
        public void AddCustomerShouldAddCustomer()
        {
            using (var context = new OSDBContext(options))
            {
                IStoreRepo repo = new OSRepoDB(context);
                repo.AddCustomer
                (
                    new Customer
                    {
                        Name = "testname",
                        Address = "123 test rd",
                        Phone = "800-867-5309",
                        Email = "test@test.edu"
                    }
                );
            }

            using (var assertContext = new OSDBContext(options))
            {
                var result = assertContext.Customers.FirstOrDefault(c => c.Name.Equals("testname"));
                Assert.NotNull(result);
                Assert.Equal("testname", result.Name);
            }
        }

        [Fact]
        public void GetCustomersShouldReturnAllCustomers()
        {
            using (var context = new OSDBContext(options))
            {
                //Arrange
                IStoreRepo repo = new OSRepoDB(context);

                //Act
                var customers = repo.GetCustomers();
                Assert.Equal(3, customers.Count);
            }
        }

        [Fact]
        public void GetCustomerByNameReturnsCorrectCustomer()
        {
            using (var context = new OSDBContext(options))
            {
                //Arrange
                IStoreRepo repo = new OSRepoDB(context);

                //Act
                var customer = repo.GetCustomerByName("A");
                Assert.Equal(1, customer.ID);
            }
        }

        [Fact]
        public void GetCustomerByEmailReturnsCorrectCustomer()
        {
            using (var context = new OSDBContext(options))
            {
                //Arrange
                IStoreRepo repo = new OSRepoDB(context);

                //Act
                var customer = repo.GetCustomerByEmail("a@a.a");
                Assert.Equal(1, customer.ID);
            }
        }

        [Fact]
        public void GetOrdersReturnsAllOrders()
        {
            using (var context = new OSDBContext(options))
            {
                //Arrange
                IStoreRepo repo = new OSRepoDB(context);

                //Act
                var orders = repo.GetOrders();
                Assert.Equal(6, orders.Count);
            }
        }

        [Fact]
        public void GetOrdersByLocationReturnsCorrectOrder()
        {
            using (var context = new OSDBContext(options))
            {
                //Arrange
                IStoreRepo repo = new OSRepoDB(context);

                //Act
                var orders = repo.GetOrdersByLocation("NY");

                Assert.NotNull(orders);
                Assert.Equal(2, orders.Count);
            }
        }

        [Fact]
        public void GetOrdersByCustomerReturnsCorrectOrder()
        {
            using (var context = new OSDBContext(options))
            {
                //Arrange
                IStoreRepo repo = new OSRepoDB(context);

                //Act
                var orders = repo.GetOrdersByCustomer("b@b.b");

                Assert.NotNull(orders);
                Assert.Single(orders);
            }
        }

        [Fact]
        public void AddOrderShouldAddOrder()
        {
            using (var context = new OSDBContext(options))
            {
                IStoreRepo repo = new OSRepoDB(context);
                repo.AddOrder
                (
                    new Order
                    {
                        CustID = 2,
                        LocID = 1,
                        Date = new DateTime(2025),
                        TotalPrice = 420
                    }
                );
            }

            using (var assertContext = new OSDBContext(options))
            {
                var result = assertContext.Orders.FirstOrDefault(c => c.TotalPrice.Equals(420));
                Assert.NotNull(result);
                Assert.Equal(420, result.TotalPrice);
            }
        }

        [Fact]
        public void GetItemsReturnsAllItems()
        {
            using (var context = new OSDBContext(options))
            {
                //Arrange
                IStoreRepo repo = new OSRepoDB(context);

                //Act
                var items = repo.GetItems();
                Assert.Equal(12, items.Count);
            }
        }

        [Fact]
        public void AddItemShouldAddItem()
        {
            using (var context = new OSDBContext(options))
            {
                IStoreRepo repo = new OSRepoDB(context);
                repo.AddItem
                (
                    new Item
                    {
                        OrderID = 6,
                        ProdID = 2,
                        Quantity = 69
                    }
                );
            }

            using (var assertContext = new OSDBContext(options))
            {
                var result = assertContext.Items.FirstOrDefault(c => c.Quantity == 69);
                Assert.NotNull(result);
                Assert.Equal(69, result.Quantity);
            }
        }

        [Fact]
        public void GetLocationsReturnsAllLocations()
        {
            using (var context = new OSDBContext(options))
            {
                //Arrange
                IStoreRepo repo = new OSRepoDB(context);

                //Act
                var locations = repo.GetLocations();
                Assert.Equal(3, locations.Count);
            }
        }

        [Fact]
        public void GetProductsReturnsAllProjects()
        {
            using (var context = new OSDBContext(options))
            {
                //Arrange
                IStoreRepo repo = new OSRepoDB(context);

                //Act
                var products = repo.GetProducts();
                Assert.Equal(3, products.Count);
            }
        }

        [Fact]
        public void GetProductByShortNameReturnsCorrectProduct()
        {
            using (var context = new OSDBContext(options))
            {
                //Arrange
                IStoreRepo repo = new OSRepoDB(context);

                //Act
                var product = repo.GetProductByShortName("a");
                Assert.Equal(1, product.ID);
            }
        }

        [Fact]
        public void GetProductByIDReturnsCorrectProduct()
        {
            using (var context = new OSDBContext(options))
            {
                //Arrange
                IStoreRepo repo = new OSRepoDB(context);

                //Act
                var product = repo.GetProductByID(1);
                Assert.Equal("A", product.Name);
            }
        }

        [Fact]
        public void GetInventoriesReturnsAllInventories()
        {
            using (var context = new OSDBContext(options))
            {
                //Arrange
                IStoreRepo repo = new OSRepoDB(context);

                //Act
                var inv = repo.GetInventories();
                Assert.Equal(9, inv.Count);
            }
        }

        [Fact]
        public void UpdateInventoryShouldUpdateInventory()
        {
            using (var context = new OSDBContext(options))
            {
                //Arrange
                IStoreRepo repo = new OSRepoDB(context);
                Inventory inventory = new Inventory()
                {
                    ID = 1,
                    Quantity = 42,
                    LocationID = 1,
                    ProductID = 1
                };

                //Act
                repo.UpdateInventory(inventory);
            }

            using (var assertContext = new OSDBContext(options))
            {
                var result = assertContext.Inventories.FirstOrDefault(c => c.ID == 1);
                Assert.NotNull(result);
                Assert.Equal(42, result.Quantity);
            }
        }

        [Fact]
        public void GetCartsReturnsAllCarts()
        {
            using (var context = new OSDBContext(options))
            {
                //Arrange
                IStoreRepo repo = new OSRepoDB(context);

                //Act
                var carts = repo.GetCarts();
                Assert.Equal(2, carts.Count);
            }
        }

        [Fact]
        public void EmptyCartDeletesCorrectProducts()
        {
            using (var context = new OSDBContext(options))
            {
                //Arrange
                IStoreRepo repo = new OSRepoDB(context);

                //Act
                Cart cartToBeDeleted = repo.GetCarts().FirstOrDefault();
                repo.EmptyCart(new List<Cart>() { cartToBeDeleted });

                var carts = repo.GetCarts();
                Assert.Single(carts);
            }
        }

        [Fact]
        public void AddCartShouldAddCart()
        {
            using (var context = new OSDBContext(options))
            {
                IStoreRepo repo = new OSRepoDB(context);
                repo.AddCart
                (
                    new Cart
                    {
                        CustID = 2,
                        LocID = 1,
                        ProdID = 1,
                        Quantity = 42
                    }
                );
            }

            using (var assertContext = new OSDBContext(options))
            {
                var result = assertContext.Carts.FirstOrDefault(c => c.Quantity.Equals(42));
                Assert.NotNull(result);
                Assert.Equal(42, result.Quantity);
            }
        }

        [Fact]
        public void CustomerExistsReturnsCorrectly()
        {
            using (var context = new OSDBContext(options))
            {
                //Arrange
                IStoreRepo repo = new OSRepoDB(context);

                //Act
                bool test1 = repo.CustomerExists("a@a.a");
                bool test2 = repo.CustomerExists("this@email.iswrong");

                Assert.True(test1);
                Assert.False(test2);
            }
        }

        //==================================================
        //==================================================

        private void Seed()
        {
            using (var context = new OSDBContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                //populate customers
                context.Customers.AddRange
                (
                    new Customer
                    {
                        ID = 1,
                        Name = "one",
                        Address = "111 one St",
                        Phone = "111-111-1111",
                        Email = "a@a.a"
                    },
                    new Customer
                    {
                        ID = 2,
                        Name = "two",
                        Address = "222 two St",
                        Phone = "222-222-2222",
                        Email = "b@b.b"
                    },
                    new Customer
                    {
                        ID = 3,
                        Name = "three",
                        Address = "333 three St",
                        Phone = "333-333-3333",
                        Email = "c@c.c"
                    }
                );

                //populate locations
                context.Locations.AddRange
                (
                    new Location
                    {
                        ID = 1,
                        Name = "NY",
                        Address = "456 NY Ave"
                    },
                    new Location
                    {
                        ID = 2,
                        Name = "CH",
                        Address = "456 CH Ave"
                    },
                    new Location
                    {
                        ID = 3,
                        Name = "LA",
                        Address = "456 LA Ave"
                    }
                );

                //populate products
                context.Products.AddRange
                (
                    new Product
                    {
                        ID = 1,
                        Name = "A",
                        ShortName = "a",
                        Price = 10,
                        Description = "the letter a",
                        Photo = "https://vignette.wikia.nocookie.net/letterpeople/images/f/fd/A081012A.jpg"
                    },
                    new Product
                    {
                        ID = 2,
                        Name = "B",
                        ShortName = "b",
                        Price = 20,
                        Description = "the letter b",
                        Photo = "https://static.wikia.nocookie.net/letterpeople/images/1/1c/Mrbnew.PNG"
                    },
                    new Product
                    {
                        ID = 3,
                        Name = "C",
                        ShortName = "c",
                        Price = 30,
                        Description = "the letter c",
                        Photo = "https://i.ytimg.com/vi/MIJgP1warmU/hqdefault.jpg"
                    }
                );

                //populate orders
                context.Orders.AddRange
                (
                    new Order
                    {
                        ID = 1,
                        CustID = 1,
                        LocID = 1,
                        Date = new DateTime(2021, 1, 1),
                        TotalPrice = 100
                    },
                    new Order
                    {
                        ID = 2,
                        CustID = 1,
                        LocID = 1,
                        Date = new DateTime(2022),
                        TotalPrice = 80
                    },
                    new Order
                    {
                        ID = 3,
                        CustID = 2,
                        LocID = 2,
                        Date = new DateTime(2023),
                        TotalPrice = 30
                    },
                    new Order
                    {
                        ID = 4,
                        CustID = 3,
                        LocID = 3,
                        Date = new DateTime(2024, 2, 2, 2, 2, 2),
                        TotalPrice = 140
                    },
                    new Order
                    {
                        ID = 5,
                        CustID = 1,
                        LocID = 3,
                        Date = new DateTime(2024, 3, 3, 3, 3, 3),
                        TotalPrice = 180
                    },
                    new Order
                    {
                        ID = 6,
                        CustID = 3,
                        LocID = 2,
                        Date = new DateTime(2024, 4, 4, 4, 4, 4),
                        TotalPrice = 20
                    }
                );

                //populate Inventory
                context.Inventories.AddRange
                (
                    new Inventory
                    {
                        ID = 1,
                        Quantity = 10,
                        LocationID = 1,
                        ProductID = 1
                    },
                    new Inventory
                    {
                        ID = 2,
                        Quantity = 10,
                        LocationID = 1,
                        ProductID = 2
                    },
                    new Inventory
                    {
                        ID = 3,
                        Quantity = 10,
                        LocationID = 1,
                        ProductID = 3
                    },
                    new Inventory
                    {
                        ID = 4,
                        Quantity = 10,
                        LocationID = 2,
                        ProductID = 1
                    },
                    new Inventory
                    {
                        ID = 5,
                        Quantity = 10,
                        LocationID = 2,
                        ProductID = 2
                    },
                    new Inventory
                    {
                        ID = 6,
                        Quantity = 10,
                        LocationID = 2,
                        ProductID = 3
                    },
                    new Inventory
                    {
                        ID = 7,
                        Quantity = 10,
                        LocationID = 3,
                        ProductID = 1
                    },
                    new Inventory
                    {
                        ID = 8,
                        Quantity = 10,
                        LocationID = 3,
                        ProductID = 2
                    },
                    new Inventory
                    {
                        ID = 9,
                        Quantity = 10,
                        LocationID = 3,
                        ProductID = 3
                    }
                );

                //populate items
                context.Items.AddRange
                (
                    new Item
                    {
                        ID = 1,
                        OrderID = 1,
                        ProdID = 1,
                        Quantity = 1
                    },
                    new Item
                    {
                        ID = 2,
                        OrderID = 1,
                        ProdID = 3,
                        Quantity =3
                    },
                    new Item
                    {
                        ID = 3,
                        OrderID = 2,
                        ProdID = 2,
                        Quantity =2
                    },
                    new Item
                    {
                        ID = 4,
                        OrderID = 2,
                        ProdID = 3,
                        Quantity =2
                    },
                    new Item
                    {
                        ID = 5,
                        OrderID = 3,
                        ProdID = 3,
                        Quantity =1
                    },
                    new Item
                    {
                        ID = 6,
                        OrderID = 4,
                        ProdID = 1,
                        Quantity =1
                    },
                    new Item
                    {
                        ID = 7,
                        OrderID = 4,
                        ProdID = 2,
                        Quantity =2
                    },
                    new Item
                    {
                        ID = 8,
                        OrderID = 4,
                        ProdID = 3,
                        Quantity =3
                    },
                    new Item
                    {
                        ID = 9,
                        OrderID = 5,
                        ProdID = 1,
                        Quantity =3
                    },
                    new Item
                    {
                        ID = 10,
                        OrderID = 5,
                        ProdID = 2,
                        Quantity =3
                    },
                    new Item
                    {
                        ID = 11,
                        OrderID = 5,
                        ProdID = 3,
                        Quantity =3
                    },
                    new Item
                    {
                        ID = 12,
                        OrderID = 6,
                        ProdID = 2,
                        Quantity =1
                    }
                );

                //populate carts
                context.Carts.AddRange
                (
                    new Cart
                    {
                        ID = 1,
                        CustID = 1,
                        LocID = 2,
                        ProdID = 1,
                        Quantity = 4
                    },
                    new Cart
                    {
                        ID = 2,
                        CustID = 1,
                        LocID = 2,
                        ProdID = 2,
                        Quantity = 2
                    }
                );
            }
        }
    }
}
