using Bisness_Layer;
using Business_Layer;
using Data_Layer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Layer__CRUD_
{
    public class UserContext : IDb<User, int>
    {
        private readonly PartySyncHubDBContext dBContext;
        public UserContext()
        {
            this.dBContext = dBContext;
        }
        public async Task CreateAsync(User item)
        {
            try
            {
                //mai nqma nujda ot tova. tva e za 1:mnogo
                //PartySession partySessionFromDB = await dBContext.PartySessions.FindAsync(item.PartySession);
                //if (partySessionFromDB != null)
                //{
                //    item.PartySession = partySessionFromDB;
                //}
                dBContext.Users.Add(item);
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
                User userFromDB = await ReadAsync(key,false,false);
                if (userFromDB==null)
                {
                    throw new ArgumentException("This User does not exist");
                }
                dBContext.Users.Remove(userFromDB);
                await dBContext.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ICollection<User>> ReadAllAsync(bool useNavigationalProperties = false, bool isReadOnly = true)
        {
            IQueryable<User> query = dBContext.Users;
            if (useNavigationalProperties)
            {
                query = query.Include(p => p.PartySessions);
            }
            if (isReadOnly)
            {
                query = query.AsNoTrackingWithIdentityResolution();
            }
            return await query.ToListAsync();
        }

        public async Task<User> ReadAsync(int key, bool useNavigationalProperties = false, bool isReadOnly = true)
        {
            try
            {
                IQueryable<User> query = dBContext.Users;
                if (useNavigationalProperties)
                {
                    query = query.Include(p => p.PartySessions);
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

        public async Task UpdateAsync(User item, bool useNavigationalProperties = false)
        {
            try
            {
                User userFromDb = await ReadAsync(item.Id, useNavigationalProperties,false);

                if (userFromDb==null)
                {
                    await CreateAsync(item);
                    return;
                }
                userFromDb.Nickname = item.Nickname;
                userFromDb.Password = item.Password;
                userFromDb.Email = item.Email;
                userFromDb.Phone = item.Phone;
                //userFromDb.CreditCard = item.CreditCard
                if (useNavigationalProperties)
                {
                    List<UserPartySession> userPartySessions = new List<UserPartySession>();
                    foreach(UserPartySession ups in item.UserPartySessions)
                    {
                        UserPartySession upsFromDb = dBContext.UserPartySessions.Find(ups.PartySessionId, ups.UserId);
                        if (upsFromDb != null)
                        {
                            userPartySessions.Add(upsFromDb);
                        }
                        else
                        {
                            userPartySessions.Add(ups);
                        }
                    }
                    //mai nqma nujda ot tova. tva e za 1:mnogo
                    //PartySession partySessionFromDb = await dBContext.PartySessions.FindAsync(item.PartySessions.Id);
                    //if (partySessionFromDb != null)
                    //{
                    //    userFromDb.PartySessions = partySessionFromDb;
                    //}
                    //else
                    //{
                    //    userFromDb.PartySessions = item.PartySessions;
                    //}
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
