using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace viBank_Api.DTO
{
    public class EmailDto
    {
        public string[] To { get; set; } = Array.Empty<string>();
        public string Subject { get; set; } = string.Empty;
        public string? Message { get; set; }
        public string? Template { get; set; }
        public Dictionary<string, string?>? TemplateData { get; set; }

    }
}