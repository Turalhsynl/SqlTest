using ConsoleApp3.Context;
using ConsoleApp3.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal;
using System.Linq.Expressions;
using System.Transactions;

public class Program
{
    static async Task Add(string name, float price)
    {
        SonyStoreDbContext sonyStoreDbContext = new SonyStoreDbContext();
        Products products = new Products()
        {
            Name = name,
            Price = price,
            InsertionDate = DateTime.Now,
        };
        await sonyStoreDbContext.Products.AddAsync(products);
        await sonyStoreDbContext.SaveChangesAsync();
    }

    static async Task Delete(int Id)
    {
        SonyStoreDbContext sonyStoreDbContext = new SonyStoreDbContext();
        var product = sonyStoreDbContext.Products.FirstOrDefault(a => a.Id == Id);
        if (product != null)
        {
            product.DeletedDate = DateTime.Now;
            product.isDeleted = true;
        }
        else
        {
            Console.WriteLine("Product not found!");
        }
        await sonyStoreDbContext.SaveChangesAsync();
    }

    static async Task Update(string Name, int Id)
    {
        SonyStoreDbContext sonyStoreDbContext = new SonyStoreDbContext();
        var product = sonyStoreDbContext.Products.FirstOrDefault(a => a.Id == Id);
        if (product != null) 
        {
            product.Name = Name;
            product.UpdationDate = DateTime.Now;
        }
        else
        {
            Console.WriteLine("Product not found");
        }
        await sonyStoreDbContext.SaveChangesAsync();
    }

    static async Task Show(int Id)
    {
        SonyStoreDbContext sonyStoreDbContext = new SonyStoreDbContext();
        var product = sonyStoreDbContext.Products.FirstOrDefault(a => a.Id == Id);
        if(product != null)
        {
            Console.WriteLine(product.Name);
            Console.WriteLine(product.Price);
        }
        await sonyStoreDbContext.SaveChangesAsync();
    }

    static void Main(string[] args)
    {
        int choice;
        int choice2;
        while (true)
        {
            Console.WriteLine("1. Add");
            Console.WriteLine("2. Delete");
            Console.WriteLine("3. Show");
            Console.WriteLine("4. Update");
            Console.WriteLine("5. Unknown");
            choice = Convert.ToInt32(Console.ReadLine());
            switch (choice) 
            {
                case 1:
                    {
                        string Name;
                        Console.WriteLine("Enter the product Name: ");
                        Name = Console.ReadLine();
                        float price;
                        Console.WriteLine("Enter the product Price: ");
                        price = Convert.ToSingle(Console.ReadLine());
                        Add(Name, price);
                        break;
                    }
                case 2:
                    {
                        int Id;
                        Console.WriteLine("Enter to the Id: ");
                        Id = Convert.ToInt32(Console.ReadLine());
                        Delete(Id);
                        break;
                    }
                case 3:
                    {
                        Console.WriteLine("1. Show by Id");
                        Console.WriteLine("2. Show all");
                        Console.WriteLine("Enter the choice: ");
                        choice2 = Convert.ToInt32(Console.ReadLine());
                        switch (choice2)
                        {
                            case 1:
                                {
                                    int Id;
                                    Console.WriteLine("Enter Id to show product: ");
                                    Id= Convert.ToInt32(Console.ReadLine());
                                    Show(Id);
                                    break;
                                }
                        }
                        break;
                    }
                case 4:
                    {
                        int Id;
                        Console.WriteLine("Enter the Id to find Product: ");
                        Id = Convert.ToInt32(Console.ReadLine());
                        string Name;
                        Console.WriteLine("Enter the new Name: ");
                        Name= Console.ReadLine();
                        Update(Name, Id);
                        break;
                    }
            }
        }
    }
}