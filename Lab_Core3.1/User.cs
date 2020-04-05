using System;
using System.Collections.Generic;

namespace Lab_Core3._1
{
    public partial class User
    {
        public User()
        {
            Requests = new HashSet<Request>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<Request> Requests { get; set; }
    }
}
