using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmailSenderMicroservice
{
    public class EmailRequest
    {
        public string FromAddress { get; set; }
        public string FromDisplay { get; set; }

        public string ToAddress { get; set; }
        public string ToDisplay { get; set; }

        public string Subject { get; set; }

        public string HtmlMessage { get; set; }
    }
}
