using System;

namespace ChhotaNivesh.Models.Product
{
    public class ProductListByCompetitorModel : BaseModel
    {
        public string CompetitorId { get; set; }

        public string CompetitorName { get; set; }

        public string CompetitorDomain { get; set; }

        public string ProductCode { get; set; }

        public string Name { get; set; }

        public string URL { get; set; }

        public string Xpath { get; set; }

        public string Price { get; set; }
        public string OldPrice { get; set; }

        public DateTime? PriceUpdatedDate { get; set; }

        public string Error { get; set; }
    }
}
