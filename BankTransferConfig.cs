using System;
using System.IO;
using System.Text.Json;

public class BankTransferConfig
{
    public string lang { get; set; }
    public Transfer transfer { get; set; }
    public string[] methods { get; set; }
    public Confirmation confirmation { get; set; }

    public class Transfer
    {
        public int threshold { get; set; }
        public int low_fee { get; set; }
        public int high_fee { get; set; }
    }

    public class Confirmation
    {
        public string en { get; set; }
        public string id { get; set; }
    }

    public static BankTransferConfig LoadConfig()
    {
        string path = "bank_transfer_config.json";

        if (!File.Exists(path))
        {
            // default config
            return new BankTransferConfig
            {
                lang = "en",
                transfer = new Transfer
                {
                    threshold = 25000000,
                    low_fee = 6500,
                    high_fee = 15000
                },
                methods = new string[]
                {
                    "RTO (real-time)", "SKN", "RTGS", "BI FAST"
                },
                confirmation = new Confirmation
                {
                    en = "yes",
                    id = "ya"
                }
            };
        }

        string json = File.ReadAllText(path);
        return JsonSerializer.Deserialize<BankTransferConfig>(json);
    }
}