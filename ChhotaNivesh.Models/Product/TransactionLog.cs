using System;

namespace ChhotaNivesh.Models.TransactionLog
{
    public class TransactionLog : BaseModel
    {
        public string UserId { get; set; }

        public string CompanyId { get; set; }

        public string Status { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string Message { get; set; }
    }
}
