using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMH.Core.Sharing
{
    public class DoctorParam
    {
        public int? clinicsId { get; set; }
        public string? search { get; set; }
        public int MaxPageSize { get; set; } = 6;
        private int _PageSize=3;
        public int PageNumber { get; set; } = 1;
        public int pageSize
        {
            get
            {
                return _PageSize;
            }
            set
            {
                _PageSize = value > MaxPageSize ? MaxPageSize : value;
            }
        }

    }
}
