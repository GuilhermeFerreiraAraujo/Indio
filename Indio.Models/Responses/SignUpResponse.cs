
using System.Collections.Generic;

namespace Indio.Models.Responses
{
    public class SignUpResponse
    {
        public bool IsRequestCompleted { get; set; }

        public List<string> Errors { get; set; }
    }
}
