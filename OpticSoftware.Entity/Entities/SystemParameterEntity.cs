using System;
using System.Collections.Generic;
using System.Text;

namespace OpticSoftware.Entity.Entities
{
    public class SystemParameterEntity : BaseEntity
    {
        public string ParameterName { get; set; }
        public string ParameterValue { get; set; }
    }
}
