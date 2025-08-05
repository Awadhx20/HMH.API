using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMH.Core.Sharing
{
    public class OperationResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }

        public static OperationResult Ok(string message = "Success") => new() { Success = true, Message = message };
        public static OperationResult Fail(string message) => new() { Success = false, Message = message };
    
    }
}
