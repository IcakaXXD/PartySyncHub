using Bisness_Layer;
using Data_Layer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Layer__CRUD_
{
    public class AdminContext : IDb<Admin, int>
    {
        private readonly PartySyncHubDBContext dBContext;
        public AdminContext(PartySyncHubDBContext dBContext)
        {
            this.dBContext = dBContext;
        }
        public void Create(Admin item)
        {
            dBContext.Admins.Add(item);
            dBContext.SaveChanges();
        }

        public void Delete(int key, bool readOnly = false)
        {
            throw new NotImplementedException();
        }

        public Admin Read(int key, bool useNavigationalProperties = false)
        {
            try
            {
                if (useNavigationalProperties)
                {
                    return dBContext.Admins.Include(l => l.Locations).FirstOrDefault(l => l.Id == key);
                }
                else
                {
                    return dBContext.Admins.Find(key);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Admin> ReadAll(bool useNavigationalProperties = false)
        {
            try
            {
                IQueryable<Admin> query = dBContext.Admins;
                if (useNavigationalProperties)
                {
                    query = query.Include(l => l.Locations);
                }
                return query.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Update(Admin item, bool useNavigationalProperties = false, bool readOnly = false)
        {
            throw new NotImplementedException();
        }
    }
}
