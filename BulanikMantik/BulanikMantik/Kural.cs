using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulanikMantik
{
    class Kural
    {
        public string hassaslik;
        public string miktar;
        public string kirlilik;
        public string donus_hizi;
        public string sure;
        public string deterjan;

        public Kural(string hassaslik, string miktar, string kirlilik, string donus_hizi, string sure, string deterjan)
        {
            this.hassaslik = hassaslik;
            this.miktar = miktar;
            this.kirlilik = kirlilik;
            this.donus_hizi = donus_hizi;
            this.sure = sure;
            this.deterjan = deterjan;
        }
    }
}
