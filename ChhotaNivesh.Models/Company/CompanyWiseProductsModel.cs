using ChhotaNivesh.Models.Product;
using System.Collections.Generic;

namespace ChhotaNivesh.Models.Company
{
    public class CompanyWiseProductsModel : BaseModel
    {
        public string CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyURL { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }

        public IList<ProductListByCompetitorModel> ProductLists { get; set; }
    }
}
