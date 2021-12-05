using System;
using System.Collections.Generic;
using System.Text;

namespace PriceCompare.Business
{
    public class AppSettingManager
    {
        public string Secret { get; set; }
        public string CompanyDetailJsonUploadPath { get; set; }
        public string ProductPriceJsonUploadPath { get; set; }
        public string EmailHost { get; set; }
        public string EmailFromAlias { get; set; }
        public string EmailPort { get; set; }
        public string EmailPassword { get; set; }
        public string EmailUsername { get; set; }
    }
}
