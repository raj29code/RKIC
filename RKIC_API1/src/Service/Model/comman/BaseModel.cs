using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Model.comman
{
    public class BaseModel
    {
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedDateTime { get; set; }
        public string LastUpdatedBy { get; set; }
        public string LastUpdatedDateTime { get; set; }

    }
}
