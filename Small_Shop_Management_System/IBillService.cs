using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Small_Shop_Management_System
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IBillService" in both code and config file together.
    [ServiceContract]
    public interface IBillService
    {
        [OperationContract]
        DataSet GetBills();

        [OperationContract]
        string GenerateBill(Bill bill);
    }
}
