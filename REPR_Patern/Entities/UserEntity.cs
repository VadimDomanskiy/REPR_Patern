namespace REPR_Pattern.Entities
{
    public class UserEntity
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
