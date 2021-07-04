using MobileStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileStore.IServices
{
    public interface IMobileStoreService
    {
        IEnumerable<MobileStoreRecord> GetSellRecord();
        Task<MobileSellRecord> GetSellRecordById(int _id);
        IEnumerable<MobileStoreReport> GetSellReport(DateTime fromdt, DateTime todt);
        IEnumerable<MobileStoreRecord> GetSellRecord(DateTime _fromdt, DateTime _dtto);
        Task<MobileStoreRecord> AddSellRecord(MobileStoreRecord _record);
        Task<MobileStoreRecord> UpdateSellRecord(MobileStoreRecord _record);
        Task<string> DeleteSellRecord(int _id);
        Task<string> GetBestPrice(int _brandId, string _model);
    }
}
