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
    public class MemberContext : IDb<Member, int>
    {
        private readonly PartySyncHubDBContext dBContext;
        public MemberContext()
        {
            this.dBContext = dBContext;
        }
        public async Task CreateAsync(Member item)
        {
            try
            {
                PartySession partySessionFromDB = await dBContext.PartySessions.FindAsync(item.PartySessionID);
                if (partySessionFromDB != null)
                {
                    item.PartySession = partySessionFromDB;
                }
                dBContext.Members.Add(item);
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
                Member memberFromDB = await ReadAsync(key, false, false);
                if (memberFromDB == null)
                {
                    throw new ArgumentException("This member does not exist");
                }
                dBContext.Members.Remove(memberFromDB);
                await dBContext.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ICollection<Member>> ReadAllAsync(bool useNavigationalProperties = false, bool isReadOnly = true)
        {
            IQueryable<Member> query = dBContext.Members;
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

        public async Task<Member> ReadAsync(int key, bool useNavigationalProperties = false, bool isReadOnly = true)
        {
            try
            {
                IQueryable<Member> query = dBContext.Members;
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

        public async Task UpdateAsync(Member item, bool useNavigationalProperties = false)
        {
            try
            {
                Member memberFromDb = await ReadAsync(item.Id, useNavigationalProperties, false);
                memberFromDb.Nickname = item.Nickname;
                memberFromDb.Password = item.Password;
                memberFromDb.Email = item.Email;
                memberFromDb.Phone = item.Phone;
                //djFromDb.CreditCard = item.CreditCard
                if (useNavigationalProperties)
                {
                    PartySession partySessionFromDb = await dBContext.PartySessions.FirstAsync(item.PartySession.Id);
                    if (partySessionFromDb != null)
                    {
                        memberFromDb.PartySession = partySessionFromDb;
                    }
                    else
                    {
                        memberFromDb.PartySession = item.PartySession;
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
