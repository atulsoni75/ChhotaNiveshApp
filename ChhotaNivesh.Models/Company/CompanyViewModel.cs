using System;

namespace ChhotaNivesh.Models.Company
{
    public class CompanyViewModel : BaseModel
    {
        public string CompanyName { get; set; }
        public string CompanyURL { get; set; }
        public string SubscriptionPlanId { get; set; }
        public DateTime? PlanExpiryDate { get; set; }        
        public bool IsActive { get; set; }

        //Extra Properties
        public string SubscriptionPlanName { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
    }
}
