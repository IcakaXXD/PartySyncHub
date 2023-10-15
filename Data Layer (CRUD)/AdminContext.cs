using Bisness_Layer;
using Data_Layer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
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
  
        public async Task CreateAsync(Admin item)
        {
            try
            {
                dBContext.Admins.Add(item);
                await dBContext.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public async Task DeleteAsync(int key)
        {
            try
            {
                Admin adminFromDb = await ReadAsync(key,false,false);
                if (adminFromDb == null)
                {
                    throw new ArgumentException("This admin does not exist");
                }
                dBContext.Admins.Remove(adminFromDb);
                await dBContext.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ICollection<Admin>> ReadAllAsync(bool useNavigationalProperties = false, bool isReadOnly = true)
        {
            IQueryable<Admin> query = dBContext.Admins;
            if (useNavigationalProperties)
            {
                query = query.Include(l => l.Locations);
            }
            if (isReadOnly)
            {
                query= query.AsNoTrackingWithIdentityResolution();
            }
            return await query.ToListAsync();
        }

        public async Task<Admin> ReadAsync(int key, bool useNavigationalProperties = false, bool isReadOnly = true)
        {
            IQueryable<Admin> query = dBContext.Admins;
            if (useNavigationalProperties)
            {
                query = query.Include(l => l.Locations);
            }
            if (isReadOnly)
            {
                query = query.AsNoTrackingWithIdentityResolution();
            }
            return await query.FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(Admin item, bool useNavigationalProperties = false)
        {
            Admin adminFromDb = await ReadAsync(item.Id, useNavigationalProperties,false);
            adminFromDb.Name = item.Name;
            adminFromDb.Password = item.Password;
            if (useNavigationalProperties)
            {
                List<Location> locations = new List<Location>();
                foreach (Location l in item.Locations)
                {
                    Location locationFromDb = await dBContext.Locations.FindAsync(l.Id);
                    if (locationFromDb != null)
                    {
                        locations.Add(locationFromDb);
                    }
                    else
                    {
                        locations.Add(l);
                    }
                }
                adminFromDb.Locations = locations;
            }
            await dBContext.SaveChangesAsync();
        }
    }
}
