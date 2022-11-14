using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio;
using Twilio.Exceptions;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace CoreAPI.AppCode.Helper
{
    public class TwilioHelper
    {
        public static void SendMessage(string phoneNumber, string codigo)
        {
            const string accountSID = "AC87f76e46843c166ef8d95b840354f534";
            const string authToken = "34a7a89e5ab8f508731e35639d5ea160";

            // Initialize the TwilioClient.
            TwilioClient.Init(accountSID, authToken);

            try
            {
                // Send an SMS message.
                var message = MessageResource.Create(
                    to: new PhoneNumber("+50684727296"),
                    from: new PhoneNumber("+19543290554"),
                    body: "Su código de verificación es:" + codigo);
            }
            catch (TwilioException ex)
            {
                // An exception occurred making the REST call
                Console.WriteLine(ex.Message);
            }
        }
    }
}
