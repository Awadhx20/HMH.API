using HMH.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMH.Core.Services
{
    public interface IGenerateToken
    {
       string GetAndGenerateToken(ApplicationUser user);
    }
}
