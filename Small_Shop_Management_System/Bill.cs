using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Small_Shop_Management_System
{
    [DataContract]
    public class Bill
    { 
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string CustomerName { get; set; }
        [DataMember]
        public long MobileNo { get; set; }
        [DataMember]
        public DateTime Date { get; set; }
        [DataMember]
        public int TotalAmount { get; set; }
    }
}
