using System.Collections.Generic;

namespace PetShop.Core.Entity
{
    public class Owner
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public List<Pet> Pets { get; set; }

        public Owner() { }

        public Owner(Owner owner)
        {
            Id = owner.Id;
            FirstName = owner.FirstName;
            LastName = owner.LastName;
            Address = owner.Address;
            PhoneNumber = owner.PhoneNumber;
            Email = owner.Email;
            Pets = owner.Pets;
        }

        public override string ToString()
        {
            return "Id: " + Id + "\r\n"
                   + "FirstName: " + FirstName + "\r\n"
                   + "LastName: " + LastName + "\r\n"
                   + "Address: " + Address + "\r\n"
                   + "PhoneNumber: " + PhoneNumber + "\r\n"
                   + "Email: " + Email + "\r\n"
                   + "______________________________";
        }

        public string ShortFormatString()
        {
            return "Id: " + Id + "\r\n"
                   + "Name: " + FirstName + ' ' + LastName + "\r\n"
                   + "______________________________";
        }
    }
}