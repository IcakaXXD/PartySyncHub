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
    public class DJContext : IDb<DJ, int>
    {
        private readonly PartySyncHubDBContext dBContext;
        public DJContext()
        {
            this.dBContext = dBContext;
        }
        public async Task CreateAsync(DJ item)
        {
            try
            {
                PartySession partySessionFromDB = await dBContext.PartySessions.FindAsync(item.PartySessionID);
                if (partySessionFromDB != null)
                {
                    item.PartySession = partySessionFromDB;
                }
                dBContext.DJs.Add(item);
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
                DJ djFromDB = await ReadAsync(key,false,false);
                if (djFromDB==null)
                {
                    throw new ArgumentException("This Dj does not exist");
                }
                dBContext.DJs.Remove(djFromDB);
                await dBContext.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ICollection<DJ>> ReadAllAsync(bool useNavigationalProperties = false, bool isReadOnly = true)
        {
            IQueryable<DJ> query = dBContext.DJs;
            if (useNavigationalProperties)
            {
                query = query.Include(p => p.PartySession);
            }
            if (isReadOnly)
            {
                query = query.AsNoTrackingWithIdentityResolution();
            }
            return await query.ToListAsync();
        }

        public async Task<DJ> ReadAsync(int key, bool useNavigationalProperties = false, bool isReadOnly = true)
        {
            try
            {
                IQueryable<DJ> query = dBContext.DJs;
                if (useNavigationalProperties)
                {
                    query = query.Include(p => p.PartySession);
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

        public async Task UpdateAsync(DJ item, bool useNavigationalProperties = false)
        {
            try
            {
                DJ djFromDb = await ReadAsync(item.Id, useNavigationalProperties,false);
                djFromDb.Nickname = item.Nickname;
                djFromDb.Password = item.Password;
                djFromDb.Email = item.Email;
                djFromDb.Phone = item.Phone;
                //djFromDb.CreditCard = item.CreditCard
                if (useNavigationalProperties)
                {
                    PartySession partySessionFromDb = await dBContext.PartySessions.FirstAsync(item.PartySession.Id);
                    if (partySessionFromDb != null)
                    {
                        djFromDb.PartySession = partySessionFromDb;
                    }
                    else
                    {
                        djFromDb.PartySession = item.PartySession;
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
