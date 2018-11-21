using System;

namespace PetShop.Core.Entity
{
    public class Pet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public DateTime Birthdate { get; set; }
        public DateTime SoldDate { get; set; }
        public string Color { get; set; }
        public Owner PreviousOwner { get; set; }
        public double Price { get; set; }

        public Pet()
        {
        }

        public Pet(Pet pet)
        {
            Id = pet.Id;
            Name = pet.Name;
            Type = pet.Type;
            Birthdate = pet.Birthdate;
            SoldDate = pet.SoldDate;
            Color = pet.Color;
            PreviousOwner = pet.PreviousOwner;
            Price = pet.Price;
        }

        public override string ToString()
        {
            return "Id: " + Id + "\r\n"
                   + "Name: " + Name + "\r\n"
                   + "Type: " + Type + "\r\n"
                   + "BirthDate: " + Birthdate + "\r\n"
                   + "SoldDate: " + SoldDate + "\r\n"
                   + "Color: " + Color + "\r\n"
                   + "PreviousOwner: " + PreviousOwner.FirstName + ' ' + PreviousOwner.LastName + "\r\n"
                   + "Price: " + Price + "\r\n"
                   + "______________________________";
        }

        public string ShortFormatString()
        {
            return "Id: " + Id + "\r\n"
                   + "Name: " + Name + "\r\n"
                   + "Type: " + Type.ToString() + "\r\n"
                   + "______________________________";
        }
    }
}