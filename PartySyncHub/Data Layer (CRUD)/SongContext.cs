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
    public class SongContext : IDb<Song, int>
    {
        private readonly PartySyncHubDBContext dBContext;
        public SongContext()
        {
            this.dBContext = dBContext;
        }
        public async Task CreateAsync(Song item)
        {
            try
            {   //mai nqma nujda ot tova. tva e za 1:mnogo
                //PartySession partySessionFromDB = await dBContext.PartySessions.FindAsync(item.PartySessionID);
                //if (partySessionFromDB != null)
                //{
                //    item.PartySession = partySessionFromDB;
                //}
                dBContext.Songs.Add(item);
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
                Song songFromDB = await ReadAsync(key, false, false);
                if (songFromDB == null)
                {
                    throw new ArgumentException("This song does not exist");
                }
                dBContext.Songs.Remove(songFromDB);
                await dBContext.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ICollection<Song>> ReadAllAsync(bool useNavigationalProperties = false, bool isReadOnly = true)
        {
            IQueryable<Song> query = dBContext.Songs;
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

        public async Task<Song> ReadAsync(int key, bool useNavigationalProperties = false, bool isReadOnly = true)
        {
            try
            {
                IQueryable<Song> query = dBContext.Songs;
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

        public async Task UpdateAsync(Song item, bool useNavigationalProperties = false)
        {
            try
            {
                Song songFromDb = await ReadAsync(item.Id, useNavigationalProperties, false);
                if (songFromDb==null)
                {
                    await CreateAsync(item);
                    return;
                }
                
                songFromDb.Name = item.Name;
                songFromDb.Singer=item.Singer;
                songFromDb.Description = item.Description;
                songFromDb.LikesCount = item.LikesCount;

                if (useNavigationalProperties)
                {
                    List<SongPartySession> songPartySessions = new List<SongPartySession>();
                    foreach (SongPartySession sps in item.SongPartySessions)
                    {
                        SongPartySession spsFromDb = dBContext.SongPartySessions.Find(sps.PartySessionId, sps.SongId);
                        if (spsFromDb!=null)
                        {
                            songPartySessions.Add(spsFromDb);
                        }
                        else
                        {
                            songPartySessions.Add(sps);
                        }
                    }
                    //mai nqma nujda ot tova. tva e za 1:mnogo
                    //PartySession partySessionFromDb = await dBContext.PartySessions.FindAsync(item.PartySession.Id);
                    //if (partySessionFromDb != null)
                    //{
                    //    songFromDb.PartySession = partySessionFromDb;
                    //}
                    //else
                    //{
                    //    songFromDb.PartySession = item.PartySession;
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
