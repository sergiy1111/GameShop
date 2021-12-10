using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace GamesShop.Models
{

    // В профиль пользователя можно добавить дополнительные данные, если указать больше свойств для класса ApplicationUser. Подробности см. на странице https://go.microsoft.com/fwlink/?LinkID=317594.
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public virtual Cart Cart { get; set; }
        public virtual List<Order> Orders { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Обратите внимание, что authenticationType должен совпадать с типом, определенным в CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Здесь добавьте утверждения пользователя
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        
        public DbSet<Product> Products { get; set; }
        public DbSet<OperatingSystem> OperatingSystems { get; set; }
        public DbSet<Developer> Developers { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Key> Keys { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }

    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public double Rating { get; set; }
        public DateTime ReleaseDate { get; set; }
        public double Price { get; set; }
        public string Processor { get; set; }
        public string RAM { get; set; }
        public string VideoCard { get; set; }
        public string DriveSpace { get; set; }
        public string Other { get; set; }
        public virtual List<OperatingSystem> OperatingSystems { get; set; }
        public virtual Publisher Publisher { get; set; }
        public virtual Developer Developer { get; set; }
        public virtual List<File> Files { get; set; }
        public virtual List<Category> Categories { get; set; }
        public virtual List<Comment> Comments { get; set; }
        public virtual List<Key> Keys { get; set; }
        public virtual List<Cart> Cart { get; set; }

        public Product()
        {
            OperatingSystems = new List<OperatingSystem>();
            Files = new List<File>();
            Categories = new List<Category>();
            Comments = new List<Comment>();
            Keys = new List<Key>();
            Cart = new List<Cart>();
        }
    }

    public class OperatingSystem
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Display(Name="Назва")]
        [Required(ErrorMessage = "Поле 'Назва' має бути введено")]
        public string Name { get; set; }
        public virtual List<Product> Products { get; set; }

        public OperatingSystem()
        {
            Products = new List<Product>();
        }
    }


    public class Publisher
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        [Display(Name = "Назва")]
        [Required(ErrorMessage = "Поле 'Назва' має бути введено")]
        public string PublisherName { get; set; } 
    }

    public class Developer
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        [Display(Name = "Назва")]
        [Required(ErrorMessage = "Поле 'Назва' має бути введено")]
        public string DeveloperName { get; set; }
    }

    public class File
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public virtual Product Product { get; set; }
    }

    public class Category
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        [Display(Name = "Назва")]
        [Required(ErrorMessage = "Поле 'Назва' має бути введено")]
        public string CategoryName { get; set; }
        public virtual List<Product> Products { get; set; }

        public Category()
        { 
            Products = new List<Product>(); 
        }
    }


    public class Comment
    {
        public int Id { get; set; }
        public string CommentText { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual Product Product { get; set; }
        public DateTime Date { get; set; }
    }

    public class Key
    {
        public int Id { get; set; }
        public string KeyString { get; set; }
        public bool IsUsed { get; set; }
        public virtual Product Product { get; set; }
    }

    public class Order
    {
        public int Id { get; set; }
        public virtual List<Key> Keys { get; set; }
        public virtual ApplicationUser User { get; set; }
        public double Summary { get; set; }

        public Order()
        {
            Keys = new List<Key>();
        }
    }


    public class Cart
    {
        public int Id { get; set; }
        public virtual List<Product> Products { get; set; }
        
        public virtual ApplicationUser User { get; set; }

        public Cart()
        {
            Products = new List<Product>();
        }
    }
}