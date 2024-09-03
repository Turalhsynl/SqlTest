namespace ConsoleApp3.Entities;

public class BaseEntity
{
    public int Id { get; set; }
    public DateTime InsertionDate { get; set; }
    public DateTime UpdationDate { get; set; }
    public DateTime DeletedDate { get; set; }
    public bool isDeleted { get; set; }
}
