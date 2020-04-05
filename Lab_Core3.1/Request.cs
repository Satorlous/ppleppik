using System;
using System.Collections.Generic;

namespace Lab_Core3._1
{
    public partial class Request
    {
        public Request()
        {
            ServiceRequest = new HashSet<ServiceRequest>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<ServiceRequest> ServiceRequest { get; set; }
    }
}
