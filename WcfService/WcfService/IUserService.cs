using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfService
{
    [ServiceContract]
    public interface IUserService
    {
        [OperationContract]
        string Find(int id);

        [OperationContract]
        void Create(User user);

        [OperationContract]
        bool Update(User user);

        [OperationContract]
        bool Delete(int id);
    }
}
