using System;

namespace ChhotaNivesh.Models.Company
{
    public class CompanyAddModel : BaseModel
    {
        public string CompanyName { get; set; }

        public string CompanyURL { get; set; }

        public string SubscriptionPlanId { get; set; }

        public DateTime? PlanExpiryDate { get; set; }
    }
}
