using System;
using System.Collections.Generic;

namespace Lab_Core3._1
{
    public partial class Service
    {
        public Service()
        {
            ServiceRequest = new HashSet<ServiceRequest>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public double? Price { get; set; }

        public virtual ICollection<ServiceRequest> ServiceRequest { get; set; }
    }
}
