using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismUnityApp1.Entity
{
    public class FacebookUser
    {
        public DateTime birthday { get; set; }
        public string email { get; set; }
        public string name { get; set; }
        public string id { get; set; }
        public byte[] profile_image { get; set; }        
    }
}
