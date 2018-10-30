namespace PetShop.Core.Entity
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int AccessLvl { get; set; }
    }
}