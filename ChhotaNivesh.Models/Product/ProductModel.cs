using System;

namespace ChhotaNivesh.Models.Product
{
    public class Product : BaseModel
    {
        public string ProductCode { get; set; }

        public string Name { get; set; }

        public string URL { get; set; }

        public string CompetitorId { get; set; }

        public string Xpath { get; set; }

        public string Price { get; set; }

        public DateTime? PriceUpdatedDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }
        public string Error { get; set; }
    }
}
