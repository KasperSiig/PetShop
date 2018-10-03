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

            ctx.SaveChanges();
        }
    }
}