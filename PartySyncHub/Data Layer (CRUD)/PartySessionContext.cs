using Business_Layer;
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
    public class PartySessionContext : IDb<PartySession, int>
    {
        private readonly PartySyncHubDBContext dBContext;
        public PartySessionContext()
        {
            this.dBContext = new PartySyncHubDBContext();
        }
        public async Task CreateAsync(PartySession item)
        {
            try
            {
                Admin adminFromDb = await dBContext.Admins.FindAsync(item);
                if (adminFromDb != null)
                {
                    item.Admin = adminFromDb;
                }
                Location locationFromDb = await dBContext.Locations.FindAsync(item);
                if (locationFromDb != null)
                {
                    item.Location = locationFromDb;
                }
                dBContext.PartySessions.Add(item);
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
                PartySession partySessionFromDb = await ReadAsync(key);
                if (partySessionFromDb == null)
                {
                    throw new ArgumentException("This session does not excist!!");
                }
                dBContext.PartySessions.Remove(partySessionFromDb);
                await dBContext.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        public async Task<ICollection<PartySession>> ReadAllAsync(bool useNavigationalProperties = false, bool isReadOnly = true)
        {
            try
            {
                IQueryable<PartySession> query = dBContext.PartySessions;
                if (useNavigationalProperties)
                {
                    query = query.Include(a => a.Admin).Include(l => l.Location).Include(u=>u.Users)
                    .Include(ns => ns.NotAprovedSongs).Include(s => s.AcceptedSongs);
                }
                if (isReadOnly)
                {
                    query = query.AsNoTrackingWithIdentityResolution();
                }
                return await query.ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public async Task<PartySession> ReadAsync(int key, bool useNavigationalProperties = false, bool isReadOnly = true)
        {
            try
            {
                IQueryable<PartySession> query = dBContext.PartySessions;
                if (useNavigationalProperties)
                {
                    query = query.Include(a => a.Admin).Include(l => l.Location).Include(u=>u.Users)
                        .Include(ns => ns.NotAprovedSongs).Include(s => s.AcceptedSongs);
                }
                if (isReadOnly)
                {
                    query = query.AsNoTrackingWithIdentityResolution();
                }
                return await query.FirstOrDefaultAsync(f => f.Id == key);
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public async Task UpdateAsync(PartySession item, bool useNavigationalProperties = false)
        {
            try
            {
                PartySession partySessionFromDb= await ReadAsync(item.Id, useNavigationalProperties);
                dBContext.Entry(partySessionFromDb).CurrentValues.SetValues(item);
                if (useNavigationalProperties)
                {
                    Admin adminFromDb = await dBContext.Admins.FindAsync(item.Admin.Id);

                    if (adminFromDb!=null)
                    {
                        partySessionFromDb.Admin = adminFromDb;
                    }
                    else
                    {
                        partySessionFromDb.Admin=item.Admin;
                    }

                    Location locationFromDb = await dBContext.Locations.FindAsync(item.Location.Id);
                    if (locationFromDb!=null)
                    {
                        partySessionFromDb.Location = locationFromDb;
                    }
                    else
                    {
                        partySessionFromDb.Location=item.Location;
                    }

                    List<User> users= new List<User>(item.Users.Count);
                    foreach(User user in item.Users)
                    {
                        User userFromDb= await dBContext.Users.FindAsync(user.Id);
                        if (userFromDb==null)
                        {
                            users.Add(user);
                        }
                        else
                        {
                            users.Add(userFromDb);
                        }
                    }  
                    // ot tuk stava mazalo
                    List<Song> notAsongs= new List<Song>(item.NotAprovedSongs.Count);
                    foreach (Song notsong in item.NotAprovedSongs)
                    {
                        Song notsongFromDb = await dBContext.Songs.FindAsync(notsong.Id);
                        if (notsongFromDb is null)
                        {
                            notAsongs.Add(notsong);
                        }
                        else
                        {
                            notAsongs.Add(notsongFromDb);
                        }
                    }

                    List<Song> songs = new List<Song>(item.AcceptedSongs.Count);
                    foreach(Song song in item.AcceptedSongs)
                    {
                        Song songFromDB = await dBContext.Songs.FindAsync(song.Id);
                        if (songFromDB ==null)
                        {
                            songs.Add(song);
                        }
                        else
                        {
                            songs.Add(songFromDB);
                        }
                    }
                    partySessionFromDb.Users= users;
                    partySessionFromDb.NotAprovedSongs = notAsongs;
                    partySessionFromDb.AcceptedSongs = songs;
                    await dBContext.SaveChangesAsync();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
