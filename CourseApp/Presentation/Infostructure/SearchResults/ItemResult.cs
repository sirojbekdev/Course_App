namespace Presentation.Infostructure.SearchResults
{
    public class ItemResult
    {
        public Guid? Id { get; set; }
        public string? Title { get; set; }
        public Guid? CollectionId { get; set; }
        public string? CollectionTitle { get; set; }
        public Guid? AppUserId { get; set; }
        public string? AppUserName { get; set; }
    }
}
