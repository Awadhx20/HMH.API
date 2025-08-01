using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMH.Core.Services
{
    public interface IimageserviceMangment
    {
        Task<string> AddImageAsync(IFormFile file , string src)    ;
        void DeleteImageAsync(string src);

    }
}
