namespace ChhotaNivesh.Models.Product
{
    public class ProductAddModel : BaseModel
    {
        public string ProductCode { get; set; }

        public string Name { get; set; }

        public string URL { get; set; }

        public string CompetitorId { get; set; }

        public string Xpath { get; set; }
    }
}
