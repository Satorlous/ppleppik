using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Newtonsoft.Json;

namespace WcfService
{   
    public class UserService : IUserService
    {
        DbEntities ctx = new DbEntities();

        public string Find(int id)
        {
            return JsonConvert.SerializeObject(ctx.Users.Find(id));
        }

        public void Create(User user)
        {
            ctx.Users.Add(new User()
            {
                name = user.name,
                phone = user.phone,
                Requests = user.Requests
            });
            ctx.SaveChanges();
        }

        public bool Update(User user)
        {
            var existingUser = ctx.Users.Find(user.id);
            if (existingUser != null)
            {
                existingUser.name = user.name;
                existingUser.phone = user.phone;
                existingUser.Requests = user.Requests;
                ctx.SaveChanges();
            }
            else
                return false;
            return true;
        }

        public bool Delete(int id)
        {
            var existingUser = ctx.Users.Find(id);
            if (existingUser != null)
            {
                ctx.Users.Remove(existingUser);
                ctx.SaveChanges();
                return true;
            }
            return false;
        }               
    }
}
