namespace Dto.Outgoing
{
    public class UserExtendedDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public List<int> PermissionIds { get; set; }
    }
}
