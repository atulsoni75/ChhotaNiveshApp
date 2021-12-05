using System;

namespace ChhotaNivesh.Models.Product
{
    public class ProductListModel : BaseModel
    {
        public string ProductCode { get; set; }

        public string Name { get; set; }

        public string URL { get; set; }

        public string CompetitorId { get; set; }

        public string Xpath { get; set; }

        public string Price { get; set; }

        public DateTime? PriceUpdatedDate { get; set; }

        public DateTime? CreatedDate { get; set; }
                
        public bool IsActive { get; set; }

        // Competitor Details
        public string CompetitorName { get; set; }

        public string CompetitorDomain { get; set; }
    }
}
