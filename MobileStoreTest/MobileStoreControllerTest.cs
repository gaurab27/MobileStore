using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using MobileStore.Controllers;
using MobileStore.IServices;
using MobileStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace MobileStoreTest
{
    public class MobileStoreControllerTest
    {
        [Fact]
        public void GetMobileRecord()
        {
            int count = 5;
            var fakeRecords = A.CollectionOfDummy<MobileStoreRecord>(count).AsEnumerable();
            var dataStore = A.Fake<IMobileStoreService>();
            A.CallTo(() => dataStore.GetSellRecord()).Returns(fakeRecords);
            var controller = new MobileStoreController(dataStore);
            var actionresult = controller.GetSellRecord();
            var result = actionresult as OkObjectResult;
            var returnRecord = result.Value as IEnumerable<MobileStoreRecord>;
            Assert.Equal(count, returnRecord.Count());
        }
        [Fact]
        public void GetMobileRecordByDate()
        {
            int count = 5;
            DateTime fromdt = DateTime.Parse("2021-07-04");
            DateTime todt = DateTime.Parse("2021-07-07");
            var fakeRecords = A.CollectionOfDummy<MobileStoreRecord>(count).AsEnumerable();
            var dataStore = A.Fake<IMobileStoreService>();
            A.CallTo(() => dataStore.GetSellRecord(fromdt, todt)).Returns(fakeRecords);
            var controller = new MobileStoreController(dataStore);
            var actionresult = controller.GetSellRecordByDate(fromdt, todt);
            var result = actionresult as OkObjectResult;
            var returnRecord = result.Value as IEnumerable<MobileStoreRecord>;
            Assert.Equal(count, returnRecord.Count());
        }
        [Fact]
        public async Task GetBestPrice()
        {
            int BrandId = 2;
            string model = "Oneplus 7 Pro";
            string price = "32000";
            var dataStore = A.Fake<IMobileStoreService>();
            A.CallTo(() => dataStore.GetBestPrice(BrandId, model)).Returns(Task.FromResult("32000"));
            var controller = new MobileStoreController(dataStore);
            var actionresult = await controller.GetBestPrice(BrandId, model);
            var result = actionresult as OkObjectResult;
            var returnPrice = result.Value as string;
            Assert.Equal(price, returnPrice);
        }
        [Fact]
        public void GetSellReport()
        {
            int count = 5;
            DateTime fromdt = DateTime.Parse("2021-07-04");
            DateTime todt = DateTime.Parse("2021-07-07");
            var fakeRecords = A.CollectionOfDummy<MobileStoreDiscountReport>(count).AsEnumerable();
            var dataStore = A.Fake<IMobileStoreService>();
            A.CallTo(() => dataStore.GetSellReport(fromdt, todt)).Returns(fakeRecords);
            var controller = new MobileStoreController(dataStore);
            var actionresult = controller.GetSellReport(fromdt, todt);
            var result = actionresult as OkObjectResult;
            var returnRecord = result.Value as IEnumerable<MobileStoreDiscountReport>;
            Assert.Equal(count, returnRecord.Count());
        }
        [Fact]
        public async Task AddSellRecord()
        {
            string message = "Data Added Successfully";
            var fakeRecords = A.Fake<MobileStoreRecord>();
            var dataStore = A.Fake<IMobileStoreService>();
            A.CallTo(() => dataStore.AddSellRecord(fakeRecords)).Returns(Task.FromResult(message));
            var controller = new MobileStoreController(dataStore);
            var actionresult = await controller.AddSellRecord(fakeRecords);
            var result = actionresult as OkObjectResult;
            var returnMessgae = result.Value as string;
            Assert.Equal(message, returnMessgae);
        }
        [Fact]
        public async Task DeleteSellRecord()
        {
            int id = 1;
            string message = "Deleted Successfully";
            var fakeRecords = A.Fake<MobileStoreRecord>();
            var dataStore = A.Fake<IMobileStoreService>();
            A.CallTo(() => dataStore.DeleteSellRecord(id)).Returns(Task.FromResult(message));
            var controller = new MobileStoreController(dataStore);
            var actionresult = await controller.DeleteSellRecord(id);
            var result = actionresult as OkObjectResult;
            var returnMessgae = result.Value as string;
            Assert.Equal(message, returnMessgae);
        }
        [Fact]
        public async Task UpdateSellRecord()
        {
            int id = 1;
            string message = "Data Updated Successfully";
            var fakeRecords = A.Fake<MobileStoreRecord>();
            var dataStore = A.Fake<IMobileStoreService>();
            A.CallTo(() => dataStore.UpdateSellRecord(fakeRecords)).Returns(Task.FromResult(message));
            var controller = new MobileStoreController(dataStore);
            var actionresult = await controller.UpdateSellRecord(fakeRecords);
            var result = actionresult as OkObjectResult;
            var returnMessgae = result.Value as string;
            Assert.Equal(message, returnMessgae);
        }
        //private List<MobileStoreRecord> MobileSellRecord()
        //{
        //    var testRecords = new List<MobileStoreRecord>();
        //    testRecords.Add(new MobileStoreRecord { Id = 1, BrandId = 1, MobileBrand = "Apple", MobileModel = "Iphone 12", Price = "85000", SellDate = DateTime.Parse("2021-04-07") });
        //    testRecords.Add(new MobileStoreRecord { Id = 2, BrandId = 2, MobileBrand = "OnePlus", MobileModel = "Oneplus 7T", Price = "36000", SellDate = DateTime.Parse("2021-04-01") });
        //    testRecords.Add(new MobileStoreRecord { Id = 3, BrandId = 1, MobileBrand = "Apple", MobileModel = "Iphone 12 pro", Price = "98000", SellDate = DateTime.Parse("2021-03-17") });
        //    testRecords.Add(new MobileStoreRecord { Id = 4, BrandId = 2, MobileBrand = "OnePlus", MobileModel = "Oneplus 7T", Price = "34000", SellDate = DateTime.Parse("2021-03-21") });
        //    testRecords.Add(new MobileStoreRecord { Id = 5, BrandId = 1, MobileBrand = "Motorola", MobileModel = "Fusion Plus", Price = "21000", SellDate = DateTime.Parse("2021-03-27") });
        //    return testRecords;
        //}
    }
}
