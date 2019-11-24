using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Model.comman
{
   public class ReturnInfo<T>
    {
        public T ReturnData { get; set; }
        public string ErrorMessage { get; set; }
        public string SuccessMessage { get; set; }
    }
}
