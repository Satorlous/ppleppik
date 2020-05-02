using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfService
{
    public class RequestService : IRequestService
    {
        DbEntities ctx = new DbEntities();

        public void Create(Request request)
        {
            ctx.Requests.Add(new Request()
            {
                user_id = request.user_id,
                Services = request.Services
            });
        }

        public bool Delete(int id)
        {
            var existingModel = ctx.Requests.Find(id);
            if (existingModel != null)
            {
                ctx.Requests.Remove(existingModel);
                ctx.SaveChanges();
                return true;
            }
            return false;
        }

        public string Find(int id)
        {
            return JsonConvert.SerializeObject(ctx.Requests.Find(id));
        }

        public bool Update(Request request)
        {
            var existingModel = ctx.Requests.Find(request.id);
            if (existingModel != null)
            {
                existingModel.user_id = request.user_id;
                existingModel.Services = request.Services;
                ctx.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
