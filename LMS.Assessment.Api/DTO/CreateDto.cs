public class CreateDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public int CreatedBy { get; set; }
    public DateTime CreatedAt { get; set; }
    public string Type { get; set; }
}
