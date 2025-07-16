using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindBackend.Data.ResultViews
{
    public class SPValidateDisabledUserResultDTO
    {
        public bool Success { get; set; }
        public bool? IsDisabled { get; set; } = null;
        public string Message { get; set; }
    }
}
