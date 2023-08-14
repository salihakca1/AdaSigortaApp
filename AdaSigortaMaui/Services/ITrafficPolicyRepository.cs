using AdaSigortaMaui.Models;


namespace AdaSigortaMaui.Services
{
    public interface ITrafficPolicyRepository
    {

        Task<Traffic> TrafficPolicy(string productName, string kimlikNo, DateTime dogumTarihi, string adi, string soyadi,
            DateTime tanzimTarihi, DateTime vadeBaslangic, DateTime vadeBitis, double prim, string plakaIlKodu, string plakaKodu
            );

    }
}
