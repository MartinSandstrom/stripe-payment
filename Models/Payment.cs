namespace dotnet_core_test.Models {

    public class Payment {
        public string email { get; set; }
        public string validation_type { get; set; }
        public string payment_user_agent { get; set; }
        public string pasted_fields { get; set; }
        public string key { get; set; }
        public string card { get; set; }
        public string time_on_page { get; set; }
        public string guid { get; set; }
        public string muid { get; set; }
        public string sid { get; set; }
        public string merchant_name { get; set; }
        public string remember_me { get; set; }
        public string phone { get; set; }
        public Token token { get; set; }
        public string locale { get; set; }

        public class Token
        {
            public string id { get; set; }
        }
    }
}
