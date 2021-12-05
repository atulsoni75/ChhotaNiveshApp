using System;

namespace ChhotaNivesh.Models.Company
{
    public class Company : BaseModel
    {
        public string CompanyName { get; set; }

        public string CompanyURL { get; set; }

        public string SubscriptionPlanId { get; set; }

        public DateTime? PlanExpiryDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }
    }
}
