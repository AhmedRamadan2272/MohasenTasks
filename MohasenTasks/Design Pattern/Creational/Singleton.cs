using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MohasenTasks.Design_Pattern.Creational
{
    public class FawryIntegration
    {
        private static FawryIntegration _instance;
        private static readonly object _lock = new object();

        public string ApiKey { get; private set; }
        public string SecretKey { get; private set; }
        public string Endpoint { get; private set; }

        private FawryIntegration()
        {
            ApiKey = "your_api_key";
            SecretKey = "your_secret_key";
            Endpoint = "Payment Get way link ";   
        }

        public static FawryIntegration Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new FawryIntegration();
                        }
                    }
                }
                return _instance;
            }
        }
        public void ProcessPayment(string paymentData)
        {
             Console.WriteLine("Processing payment with Fawry API...");
        }
    }

    public class PaymentPage
    {
        // Client  code
 
        public void InitiatePayment()
        {
            var fawry = FawryIntegration.Instance;
            string paymentData = "sample_payment_data";
            fawry.ProcessPayment(paymentData);
        }

    }
}
