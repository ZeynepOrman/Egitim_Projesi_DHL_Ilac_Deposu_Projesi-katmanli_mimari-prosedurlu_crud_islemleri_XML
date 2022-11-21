using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class EGeriGelenİlac
    {
        public int GeriGelenİlacNo { get; set; }
        public string GeriGelenİlacAdi { get; set; }
        public int GeriGelenİlacBarkodNo { get; set; }
        public DateTime GeriGelenİlacUretimTarihi { get; set; }
        public DateTime GeriGelenİlacTuketimTarihi { get; set; }
        public string GeriGelenİlacSatilanFirmaAdi { get; set; }
        public int FirmaNo { get; set; }
    }
}
