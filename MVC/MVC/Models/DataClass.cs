using System.Collections.Generic;

namespace MVC.Models
{
    public class Data
    {
        public string Account { get; set; }
        public IEnumerable<message> message { get; set; }
        public IEnumerable<ReMessage> remessage { get; set; }
    }
}