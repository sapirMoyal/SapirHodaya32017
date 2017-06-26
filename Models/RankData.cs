using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Models
{
    public class RankData
    {
        public int Rank { get; set; }
        public string UserName { get; set; }
        public int Win { get; set; }
        public int Loose { get; set; }
        public RankData(int rank, string userN, int w, int l)
        {
            Rank = rank;
            UserName = userN;
            Win = w;
            Loose = l;

        }

    }
}