using System;
using PetShop.Core.Entity;

namespace PetShop.Infrastructure.Data
{
    public class DBInitializer
    {
        public static void SeedDB(PetShopContext ctx)
        {
            ctx.Database.EnsureDeleted();
            ctx.Database.EnsureCreated();
            var jens = ctx.Owners.Add(new Owner
            {
                FirstName = "Jens",
                LastName = "Jensen",
                Address = "Jensen Street 22",
                PhoneNumber = "89598765",
                Email = "jens@jensen.dk"
            }).Entity;
            
            var hans = ctx.Owners.Add(new Owner
            {
                FirstName = "Hans",
                LastName = "Hansen",
                Address = "Hansen Street 22",
                PhoneNumber = "89758679",
                Email = "hans@hansen.dk"
            }).Entity;
            
            var lars = ctx.Owners.Add(new Owner
            {
                FirstName = "Lars",
                LastName = "Larsen",
                Address = "Larsen Street 22",
                PhoneNumber = "64778957",
                Email = "lars@jysk.dk"
            }).Entity;

            var pet1 = ctx.Pets.Add(new Pet
            {
                Name = "Børge",
                Type = Pet.PetType.Bird,
                Birthdate = new DateTime(1995, 01, 30),
                SoldDate = new DateTime(2008, 05, 16),
                Color = "Black",
                PreviousOwner = hans,
                Price = 200.69
            });
            
            var pet2 = ctx.Pets.Add(new Pet
            {
                Name = "Karin",
                Type = Pet.PetType.Goat,
                Birthdate = new DateTime(1992, 07, 18),
                SoldDate = new DateTime(2006, 05, 24),
                Color = "Yellow",
                PreviousOwner = jens,
                Price = 180.69
            });

            var admin = ctx.Users.Add(new User()
            {
                Username = "Admin",
                Password = "8C6976E5B5410415BDE908BD4DEE15DFB167A9C873FC4BB8A81F6F2AB448A918",
                AccessLvl = 0
            });
            
            var user = ctx.Users.Add(new User()
            {
                Username = "User",
                Password = "04F8996DA763B7A969B1028EE3007569EAF3A635486DDAB211D512C85B9DF8FB",
                AccessLvl = 5
            });
            ctx.SaveChanges();
        }
    }
}