using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BL;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace AnimeWebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimeController : ControllerBase
    {
        readonly private IBL _bl;

        public AnimeController(IBL bl)
        {
            _bl = bl;
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<Anime> animeList = _bl.GetAllAnime();
            if (animeList != null)
            {
                return Ok(animeList);
            }
            else
            {
                return NoContent();
            }
        }


        // GET api/<PostController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Anime selectedAnime = _bl.GetAnimeById(id);
            if (selectedAnime != null)
            {
                return Ok(selectedAnime);
            }
            else
            {
                return NoContent();
            }
        }


        // POST api/<PostController>/5
        [HttpPost]
        public IActionResult Post([FromBody] Anime anime)
        {
            Anime addAnime = _bl.AddAnime(anime);
            return Created("api/[controller]", addAnime);
        }


        // PUT api/<PostController>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Anime newAnime)
        {
            Anime updatedAnime = _bl.UpdateAnime(newAnime);
            return Ok(updatedAnime);
        }


        // DELETE api/<PostController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Anime deleteAnime = _bl.GetAnimeById(id);
            _bl.DeleteAnime(id);
            return Ok(deleteAnime);
        }
    }
}
