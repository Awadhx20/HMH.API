using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMH.Core.DTO
{
    public record EmailDTO
    {
        public EmailDTO(string to, string from, string subject, string Content)
        {
            To = to;
            From = from;
            Subject = subject;
            content = Content;
        }

        public string To { get; set; }
        public string From { get; set; }
        public string Subject { get; set; }
        public string content { get; set; }
    }
}
