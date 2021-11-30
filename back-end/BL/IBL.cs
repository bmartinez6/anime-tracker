using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DL;

namespace BL
{
    public interface IBL
    {
        //--------------- Methods for Getting List ---------------
        List<Anime> GetAllAnime();

        //--------------- Methods for Getting Data by Id ---------------
        Anime GetAnimeById(int id);

        //--------------- Methods for Adding Data ---------------
        Anime AddAnime(Anime anime);

        //--------------- Methods for Updating DB ---------------
        Anime UpdateAnime(Anime anime);

        //--------------- Methods for Deleting Data ---------------
        void DeleteAnime(int id);
    }
}