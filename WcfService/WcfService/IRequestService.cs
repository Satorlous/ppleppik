using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfService
{
    [ServiceContract]
    public interface IRequestService
    {
        [OperationContract]
        string Find(int id);

        [OperationContract]
        void Create(Request request);

        [OperationContract]
        bool Update(Request request);

        [OperationContract]
        bool Delete(int id);
    }
}
