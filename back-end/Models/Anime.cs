using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Anime
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool Watched { get; set; }
        public bool Watching { get; set; }
        public bool toWatch { get; set; }
    }
}
