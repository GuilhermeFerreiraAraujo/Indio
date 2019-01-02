using Indio.Models._2FactAuth;
using Indio.Services.Contracts;
using Microsoft.Extensions.Options;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace Indio.Services
{
    public class SmsService : ISmsService
    {
        private readonly SMSOptions _options;

        public SmsService(IOptions<SMSOptions> options)
        {
            _options = options.Value;
        }

        public async void SendSms(string message, string destPhone)
        {
            var accountSid = _options.SMSAccountIdentification;
            var authToken = _options.SMSAccountPassword;

            TwilioClient.Init(accountSid, authToken);

            var result = await MessageResource.CreateAsync(
              to: new PhoneNumber(destPhone),
              from: new PhoneNumber(_options.SMSAccountFrom),
              body: message);
        }
    }
}
