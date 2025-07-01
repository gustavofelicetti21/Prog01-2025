using Modelo;
using Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

FillCostumerData();

FillProductData();

FillOrderData();

app.Run();

static void FillCostumerData()
{
    for (int i = 1; i <= 10; i++)
    {
        Customer customer = new()
        {
            Id = i,
            Name = $"Customer {i}",
            HomeAddres = new Address()
            {
                AddressType = "Casa",
                City = "Videira",
                Country = "HU3HU3BR",
                State = "SC",
                PostalCode = "89650-000",
                Street1 = "Rua da minha casa",
                Street2 = "Sua casa"
            },
            WorkAddres = new Address()
            {
                AddressType = "Predio",
                City = "Videira",
                Country = "HU3HU3BR",
                State = "SC",
                PostalCode = "89650-001",
                Street1 = "Rua do meu trabalho",
                Street2 = "Seu trabalho"
            }
        };

        CustomerData.Customers.Add(customer);
    }
}

static void FillProductData()
{
    for (int i = 1; i <= 10; i++)
    {
        Product product = new()
        {
            Id = i,
            ProductName = $"Product {i}",
            Description = $"Description Product {i}",
            CurrentPrice = i
        };

        CustomerData.Products.Add(product);
    }
}

static void FillOrderData()
{
    var customer1 = CustomerData.Customers[0];
    var customer2 = CustomerData.Customers[1];
    var product1 = CustomerData.Products[0];
    var product2 = CustomerData.Products[1];
    var product3 = CustomerData.Products[2];

    Order order1 = new()
    {
        Id = 1,
        Customer = customer1,
        OrderDate = DateTime.Now,
        ShippingAddress = customer1.HomeAddres,
        OrderItems = new List<OrderItem>
        {
            new OrderItem
            {
                Id = 1,
                Product = product1,
                Quantity = 2,
                PurchasePrice = product1.CurrentPrice
            }
        }
    };

    Order order2 = new()
    {
        Id = 2,
        Customer = customer2,
        OrderDate = DateTime.Now,
        ShippingAddress = customer2.HomeAddres,
        OrderItems = new List<OrderItem>
        {
            new OrderItem
            {
                Id = 1,
                Product = product2,
                Quantity = 1,
                PurchasePrice = product2.CurrentPrice
            },
            new OrderItem
            {
                Id = 2,
                Product = product3,
                Quantity = 2,
                PurchasePrice = product3.CurrentPrice * 2
            }
        }
    };

    CustomerData.Orders.Add(order1);
    CustomerData.Orders.Add(order2);
}