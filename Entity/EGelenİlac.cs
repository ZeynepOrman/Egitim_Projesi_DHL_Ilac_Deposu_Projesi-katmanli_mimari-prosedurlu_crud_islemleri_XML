using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class EGelenİlac
    {
        public int GelenİlacNo { get; set; }
        public string GelenİlacAdi { get; set; }
        public int GelenİlacBarkodNo { get; set; }
        public DateTime GelenİlacUretimTarihi { get; set; } 
        public DateTime GelenİlacTuketimTarihi { get; set; }
        public string GelenİlacAlinanFirma { get; set; }
        public string GelenİlacSatilanFirma { get; set; }
        public int DepoNo { get; set; }
        public int FirmaNo { get; set; }


    }
}
