using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatServer.Models
{
    public class Message
    {
        public string msg { get; set; }
        public DateTime date { get; set; } = DateTime.Now;
        public string sender { get; set; }
    }
}
