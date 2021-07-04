using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MobileStore.IServices;
using MobileStore.Models;

namespace MobileStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MobileStoreController : ControllerBase
    {
        private readonly IMobileStoreService MobileStoreService;

        public MobileStoreController(IMobileStoreService mobilestore)
        {
            MobileStoreService = mobilestore;
        }
        [HttpGet]
        [Route("[action]")]
        [Route("api/MobileStore/GetSellRecord")]
        public IActionResult GetSellRecord()
        {
            try
            {
                var record = MobileStoreService.GetSellRecord();
                if (record != null)
                {
                    return Ok(record);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet]
        [Route("[action]")]
        [Route("api/MobileStore/GetSellRecordByDate")]
        public IActionResult GetSellRecordByDate(DateTime from, DateTime to)
        {
            try
            {
                var record = MobileStoreService.GetSellRecord(from, to);
                if (record.Count() > 0)
                {
                    return Ok(record);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet]
        [Route("[action]")]
        [Route("api/MobileStore/GetSellReport")]
        public IActionResult GetSellReport(DateTime from, DateTime to)
        {
            try
            {
                var record = MobileStoreService.GetSellReport(from, to);
                if (record.Count() > 0)
                {
                    return Ok(record);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet]
        [Route("[action]")]
        [Route("api/MobileStore/GetBestPrice")]
        public async Task<IActionResult> GetBestPrice(int BrandId, string Model)
        {
            try
            {
                var record = await MobileStoreService.GetBestPrice(BrandId, Model);
                if (record != null)
                {
                    return Ok(record);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost]
        [Route("[action]")]
        [Route("api/MobileStore/AddSellRecord")]
        public async Task<IActionResult> AddSellRecord(MobileStoreRecord record)
        {
            try
            {
                var result = await MobileStoreService.AddSellRecord(record);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPut]
        [Route("[action]")]
        [Route("api/MobileStore/UpdateSellRecord")]
        public async Task<IActionResult> UpdateSellRecord(MobileStoreRecord record)
        {
            try
            {
                
                if (record != null)
                {
                    var result = await MobileStoreService.UpdateSellRecord(record);
                    return Ok(result);
                }
                else
                {
                    return BadRequest("Data not found to be update.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpDelete]
        [Route("[action]")]
        [Route("api/MobileStore/DeleteSellRecord")]
        public async Task<IActionResult> DeleteSellRecord(int id)
        {
            try
            {
                var checkData = await MobileStoreService.GetSellRecordById(id);
                if (checkData != null)
                {
                    var result = await MobileStoreService.DeleteSellRecord(id);
                    return Ok(result);
                }
                else
                {
                    return BadRequest("Data not found to be deleted.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
