namespace SH.Domain;
public abstract class AuditableEntity<TKey>
{
    public TKey Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? ModifiedDate { get; set; }
    public bool IsDeleted { get; set; }

    public void DeleteItem()
    {
        IsDeleted = true;
    }

    public void RestoreItem()
    {
        IsDeleted = false;
    }
}

public abstract class AuditableEntity : AuditableEntity<long>
{

}
