namespace Presentation.Domain.Common
{
    public abstract class BaseEntity : IAuditable
    {
        public Guid Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }

        protected BaseEntity()
        {
            CreatedOn= DateTime.Now;
            Id = Guid.NewGuid();
        }
    }
}