using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfService
{
    [ServiceContract]
    public interface IServiceService
    {
        [OperationContract]
        string Find(int id);

        [OperationContract]
        void Create(Service service);

        [OperationContract]
        bool Update(Service service);

        [OperationContract]
        bool Delete(int id);
    }
}
