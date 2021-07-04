using Microsoft.EntityFrameworkCore;
using MobileStore.IServices;
using MobileStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileStore.Services
{
    public class MobileStoreService : IMobileStoreService
    {
        MobileStoreDBContext dbContext;
        public MobileStoreService(MobileStoreDBContext _db)
        {
            dbContext = _db;
        }
        public async Task<string> AddSellRecord(MobileStoreRecord record)
        {
            MobileSellRecord sellrecord = new MobileSellRecord();
            sellrecord.Id = record.Id;
            sellrecord.BrandId = record.BrandId;
            sellrecord.MobileModel = record.MobileModel;
            sellrecord.Price = record.Price;
            sellrecord.SellDate = record.SellDate;
            dbContext.MobileSellRecords.Add(sellrecord);
            var result = await dbContext.SaveChangesAsync();
            return "Data has been saved with id" + result;
        }
        public async Task<string> DeleteSellRecord(int id)
        {
            try
            {
                var record = await dbContext.MobileSellRecords.FirstOrDefaultAsync(x => x.Id == id);
                if (record != null)
                {
                    dbContext.Entry(record).State = EntityState.Deleted;
                    await dbContext.SaveChangesAsync();
                    return "Success";
                }
                else
                {
                    throw new Exception("Record Not Found");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<string> GetBestPrice(int _brandId, string _model)
        {
            string bestPrice = await dbContext.MobileSellRecords.Where(x => x.BrandId == _brandId && x.MobileModel == _model).MinAsync(p => p.Price);
            return bestPrice;
        }
        public IEnumerable<MobileStoreRecord> GetSellRecord()
        {
            return from sr in dbContext.MobileSellRecords
                         join br in dbContext.MobileBrandRecords
                         on sr.BrandId equals br.Id
                         select new MobileStoreRecord { Id = sr.Id, BrandId = br.Id, MobileBrand = br.MobileBrand, MobileModel = sr.MobileModel, Price = sr.Price, SellDate = sr.SellDate };
        }
        public IEnumerable<MobileStoreRecord> GetSellRecord(DateTime fromdt, DateTime todt)
        {
            return (from sr in dbContext.MobileSellRecords
                    where sr.SellDate >= fromdt && sr.SellDate <= todt
                    select new MobileStoreRecord { Id = sr.Id, BrandId = sr.Brand.Id, MobileBrand = sr.Brand.MobileBrand, MobileModel = sr.MobileModel, Price = sr.Price, SellDate = sr.SellDate }).ToList();
        }
        public async Task<MobileSellRecord> GetSellRecordById(int _id)
        {
            return await dbContext.MobileSellRecords.Where(x => x.Id == _id).FirstOrDefaultAsync();
        }
        public async Task<string> UpdateSellRecord(MobileStoreRecord record)
        {
            MobileSellRecord sellrecord = new MobileSellRecord();
            sellrecord.Id = record.Id;
            sellrecord.BrandId = record.BrandId;
            sellrecord.MobileModel = record.MobileModel;
            sellrecord.Price = record.Price;
            sellrecord.SellDate = record.SellDate;
            dbContext.Entry(sellrecord).State = EntityState.Modified;
            var result = await dbContext.SaveChangesAsync();
            return "Record Updated Successfully";
        }
        public IEnumerable<MobileStoreReport> GetSellReport(DateTime fromdt, DateTime todt)
        {
            return (from sr in dbContext.MobileBrandRecords
                    select new MobileStoreReport { MobileBrand = sr.MobileBrand, SellRecord = sr.MobileSellRecords.Where(x => x.SellDate >= fromdt && x.SellDate <= todt).ToList() }).ToList();
        }
    }
}
