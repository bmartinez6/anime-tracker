using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
using Microsoft.EntityFrameworkCore;

namespace DL
{
    public class DBRepo : IRepo
    {
        readonly private AnimeDB _context;

        public DBRepo(AnimeDB context)
        {
            _context = context;
        }

        //--------------- Methods For Getting List ---------------

        public List<Anime> GetAllAnime()
        {
            List<Anime> animes = _context.Animes
                .Select(a => new Anime()
                {
                    Id = a.Id,
                    Title = a.Title,
                    Watched = a.Watched,
                    Watching = a.Watching,
                    toWatch = a.toWatch
                }).ToList();

            return animes;
        }

        //--------------- Methods for Getting Data by Id ---------------
        public Anime GetAnimeById(int id)
        {
            Anime aAnime = _context.Animes
                .AsNoTracking()
                .Select(a => new Anime()
                {
                    Id = a.Id,
                    Title = a.Title,
                    Watched = a.Watched,
                    Watching = a.Watching,
                    toWatch = a.toWatch
                })
                .FirstOrDefault(a => a.Id == id);

            return aAnime;
        }

        //--------------- Methods for Adding Data ---------------
        public Anime AddAnime(Anime anime)
        {
            _context.Add(anime);
            _context.SaveChanges();
            _context.ChangeTracker.Clear();
            return anime;
        }

        //--------------- Methods for Updating DB ---------------
        public Anime UpdateAnime(Anime anime)
        {
            _context.Animes.Update(anime);
            _context.SaveChanges();
            _context.ChangeTracker.Clear();

            return new Anime()
            {
                Id = anime.Id,
                Title = anime.Title,
                Watched = anime.Watched,
                Watching = anime.Watching,
                toWatch = anime.toWatch
            };
        }

        //--------------- Methods for Deleting Data ---------------
        public void DeleteAnime(int id)
        {
            _context.Animes.Remove(GetAnimeById(id));
            _context.SaveChanges();
            _context.ChangeTracker.Clear();
        }
    }
}
