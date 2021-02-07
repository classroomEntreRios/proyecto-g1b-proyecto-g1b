namespace Viajar360Api.Models.Users
{
  public class UpdateModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool Active { get; set; }
        public long RoleId { get; set; }
    }
}