using AdaSigortaMaui.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaSigortaMaui.Services
{
    public interface IDaskPolicyRepository
    {
        Task<Dask> DaskPolicy(string productName, string kimlikNo, DateTime dogumTarihi, string adi, string soyadi,
            DateTime tanzimTarihi, DateTime vadeBaslangic, DateTime vadeBitis, double prim, string address, string il, string ilce
            );
    }
}
