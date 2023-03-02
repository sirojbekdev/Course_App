namespace Presentation.Domain.Common
{
    public interface IAuditable
    {
        Guid Id { get; set; }
        DateTime CreatedOn { get; set; }
        DateTime? ModifiedOn { get; set; }
    }
}