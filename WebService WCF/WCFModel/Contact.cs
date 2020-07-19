using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WCFModel
{
    [DataContract]
    public class Contact
    {
        [DataMember]
        public string Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string PhoneNo { get; set; }
        [DataMember]
        public string EmailAddress { get; set; }
        [DataMember]
        public string Address { get; set; }
    }
}
