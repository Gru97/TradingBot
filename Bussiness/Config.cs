using System;
using System.Collections.Generic;

namespace Bussiness
{
    public class Config
    {
        public string Trading_Secret { get; set; }
        public string Source_Secret { get; set; }
        public string Asset_Code_A { get; set; }
        public string Issuer_A { get; set; }
        public string Asset_Code_B { get; set; }
        public string Issuer_B { get; set; }
        public string Tick_Interval_Second { get; set; }
        public string Random_Delay { get; set; }
        public string DATA_TYPE_A { get; set; }
        public string Data_Feed_A_URL { get; set; }
        public string DATA_TYPE_B { get; set; }
        public string Data_Feed_B_URL { get; set; }
        public string Price_Tolerance { get; set; }
        public string Amount_Tolerance { get; set; }
        public string HORIZON_URL { get; set; }
        public string AMOUNT_OF_A_BASE { get; set; }
        public List<Level> Levels { get; set; }
    }
}
