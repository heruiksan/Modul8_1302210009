using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Modul8_1302210009
{
    internal class BankTransferConfig
    {
        public bankConfig config;
        public const string filepath = @"bank_transfer_config.json";
        //cc

        public BankTransferConfig()
        {
            try
            {
                ReadConfig();
            }
            catch
            {
                SetDefault();
                writeConfig();
            }
        }
        public void ReadConfig()
        {
            string hasil = File.ReadAllText(filepath);
        }

        public void writeConfig()
        {
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                WriteIndented = true,
            };
            string tulis = JsonSerializer.Serialize(config, options);
        }

        public void SetDefault()
        {
            config = new bankConfig("en", new Transfer(25000000, 6500, 15000),
                new List<string> { "RTO(real - time)", "SKN", "RTGS", "BI", "FAST" },
                new Confirmation("yes", "ya"));
        }

        public class Confirmation
        {
            public string en { get; set; }
            public string id { get; set; }

            public Confirmation() { }
            public Confirmation(string en, string id)
            {
                this.en = en;
                this.id = id;
            }
        }

        public class Transfer
        {
            public int threshold { get; set; }
            public int low_fee { get; set; }
            public int high_fee { get; set; }

            public Transfer() { }
            public Transfer(int threshold, int low_fee, int high_fee)
            {
                this.threshold = threshold;
                this.low_fee = low_fee;
                this.high_fee = high_fee;
            }
        }
        public class bankConfig
        {
            public string lang { get; set; }
            public Transfer transfer { get; set; }
            public List<string> methods { get; set; }
            public Confirmation confirmation { get; set; }

            public bankConfig() { }
            public bankConfig(string lang, Transfer transfer, List<string> methods, Confirmation confirmation)
            {
                this.lang = lang;
                this.transfer = transfer;
                this.methods = methods;
                this.confirmation = confirmation;
            }
        }
    }
}
