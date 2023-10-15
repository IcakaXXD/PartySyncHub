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
    public class LocationContext : IDb<Location, int>
    {
        private readonly PartySyncHubDBContext dBContext;
        public LocationContext()
        {
            this.dBContext = dBContext;
        }
        public async Task CreateAsync(Location item)
        {
            try
            {
                Admin adminFromDB = await dBContext.Admins.FindAsync(item.AdminId);
                if (adminFromDB != null)
                {
                    item.Admin = adminFromDB;
                }
                dBContext.Locations.Add(item);
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
                Location locationFromDB = await ReadAsync(key, false, false);
                if (locationFromDB == null)
                {
                    throw new ArgumentException("This location does not exist");
                }
                dBContext.Locations.Remove(locationFromDB);
                await dBContext.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ICollection<Location>> ReadAllAsync(bool useNavigationalProperties = false, bool isReadOnly = true)
        {
            IQueryable<Location> query = dBContext.Locations;
            if (useNavigationalProperties)
            {
                query = query.Include(a => a.Admin);
            }
            if (isReadOnly)
            {
                query = query.AsNoTrackingWithIdentityResolution();
            }
            return await query.ToListAsync();
        }

        public async Task<Location> ReadAsync(int key, bool useNavigationalProperties = false, bool isReadOnly = true)
        {
            try
            {
                IQueryable<Location> query = dBContext.Locations;
                if (useNavigationalProperties)
                {
                    query = query.Include(a => a.Admin);
                }
                if (isReadOnly)
                {
                    query = query.AsNoTrackingWithIdentityResolution();
                }
                return await query.FirstOrDefaultAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task UpdateAsync(Location item, bool useNavigationalProperties = false)
        {
            try
            {
                Location locationFromDb = await ReadAsync(item.Id, useNavigationalProperties, false);

                locationFromDb.Name = item.Name;
                locationFromDb.Workig_time = item.Workig_time;

                if (useNavigationalProperties)
                {
                    Admin adminFromDb = await dBContext.Admins.FirstAsync(item.Admin.Id);
                    if (adminFromDb != null)
                    {
                        locationFromDb.Admin = adminFromDb;
                    }
                    else
                    {
                        locationFromDb.Admin = item.Admin;
                    }
                }
                await dBContext.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
