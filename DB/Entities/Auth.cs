namespace DB.Entities;

public class Auth : BaseEntity
{
    public string Token { get; set; }
    public DateTime End { get; set; }
    public ulong UserID { get; set; }
    public string Ip { get; set; }
    public byte TypeID { get; set; }
}