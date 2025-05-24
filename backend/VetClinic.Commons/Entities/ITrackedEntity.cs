namespace VetClinic.Commons.Entities
{
    internal interface ITrackedEntity
    {
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public Guid CreatedByUserId { get; set; }
        public Guid ModifiedByUserId { get; set;}
    }
}
