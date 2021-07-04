using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using MobileStore.Controllers;
using MobileStore.IServices;
using MobileStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace MobileStoreTest
{
    public class MobileStoreControllerTest
    {
        [Fact]
        public void GetMobileRecordByDate()
        {
            var fakeRecords = A.CollectionOfDummy<MobileStoreRecord>(5).AsEnumerable();
            var dataStore = A.Fake<IMobileStoreService>();
            A.CallTo(() => dataStore.GetSellRecord()).Returns(fakeRecords);
            var controller = new MobileStoreController(dataStore);
            var actionresult = controller.GetSellRecord();
            var result = actionresult as OkObjectResult;
            var returnRecord = result.Value as IEnumerable<MobileStoreRecord>;
            Assert.Equal(5, returnRecord.Count());
        }
        private List<MobileStoreRecord> MobileSellRecord()
        {
            var testRecords = new List<MobileStoreRecord>();
            testRecords.Add(new MobileStoreRecord { Id = 1, BrandId = 1, MobileBrand = "Apple", MobileModel = "Iphone 12", Price = "85000", SellDate = DateTime.Parse("2021-04-07") });
            testRecords.Add(new MobileStoreRecord { Id = 2, BrandId = 2, MobileBrand = "OnePlus", MobileModel = "Oneplus 7T", Price = "36000", SellDate = DateTime.Parse("2021-04-01") });
            testRecords.Add(new MobileStoreRecord { Id = 3, BrandId = 1, MobileBrand = "Apple", MobileModel = "Iphone 12 pro", Price = "98000", SellDate = DateTime.Parse("2021-03-17") });
            testRecords.Add(new MobileStoreRecord { Id = 4, BrandId = 2, MobileBrand = "OnePlus", MobileModel = "Oneplus 7T", Price = "34000", SellDate = DateTime.Parse("2021-03-21") });
            testRecords.Add(new MobileStoreRecord { Id = 5, BrandId = 1, MobileBrand = "Motorola", MobileModel = "Fusion Plus", Price = "21000", SellDate = DateTime.Parse("2021-03-27") });
            return testRecords;
        }
    }
}
