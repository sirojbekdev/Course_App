﻿namespace Presentation.Domain.Entities
{
    public class ItemTags
    {
        public Guid ItemId { get; set; }
        public virtual Item Item { get; set; }
        public Guid TagId { get; set; }
        public virtual Tag Tag { get; set; }
    }
}
