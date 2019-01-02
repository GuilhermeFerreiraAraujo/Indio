using System;
using System.Collections.Generic;
using System.Text;

namespace Indio.Services.Contracts
{
    public interface ISmsService
    {
        void SendSms(string message, string destPhone);
    }
}
