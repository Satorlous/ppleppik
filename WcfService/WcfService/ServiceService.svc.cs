using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Newtonsoft.Json;

namespace WcfService
{
    public class ServiceService : IServiceService
    {
        DbEntities ctx = new DbEntities();

        public void Create(Service service)
        {
            ctx.Services.Add(new Service()
            {
                price = service.price,
                name = service.name,
                Requests = service.Requests
            });
            ctx.SaveChanges();
        }

        public bool Delete(int id)
        {
            var existingModel = ctx.Services.Find(id);
            if(existingModel != null)
            {
                ctx.Services.Remove(existingModel);
                ctx.SaveChanges();
                return true;
            }
            return false;
        }

        public string Find(int id)
        {
            return JsonConvert.SerializeObject(ctx.Services.Find(id));
        }

        public bool Update(Service service)
        {
            var existingModel = ctx.Services.Find(service.id);
            if (existingModel != null)
            {
                existingModel.name = service.name;
                existingModel.price = service.price;
                existingModel.Requests = service.Requests;
                ctx.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
