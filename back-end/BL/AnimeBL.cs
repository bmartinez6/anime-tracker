using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DL;

namespace BL
{
    public class AnimeBL : IBL
    {
        readonly private IRepo _repo;

        public AnimeBL(IRepo repo)
        {
            _repo = repo;
        }

        //--------------- Methods for Getting List ---------------
        public List<Anime> GetAllAnime()
        {
            return _repo.GetAllAnime();
        }

        //--------------- Methods for Getting Data by Id ---------------
        public Anime GetAnimeById(int id)
        {
            return _repo.GetAnimeById(id);
        }

        //--------------- Methods for Adding Data ---------------
        public Anime AddAnime(Anime anime)
        {
            return _repo.AddAnime(anime);
        }

        //--------------- Methods for Updating DB ---------------
        public Anime UpdateAnime(Anime anime)
        {
            return _repo.UpdateAnime(anime);
        }

        //--------------- Methods for Deleting Data ---------------
        public void DeleteAnime(int id)
        {
            _repo.DeleteAnime(id);
        }
    }
}
