namespace Domain.Common
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            IsActive = true;
            IsDeleted = false;
            CreatedDate = DateTime.UtcNow;
            CreatedBy = 1;
            OrganizationId = 1;
        }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
        public int? OrganizationId { get; set; }
    }
}
