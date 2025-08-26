using Microsoft.AspNetCore.Mvc;
using MonthlyRevenueAPI.DTOs;
using MonthlyRevenueAPI.Services.Interface;

namespace MonthlyRevenueAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class MonthlyRevenuesController : ControllerBase
    {
        private readonly IMonthlyRevenueService _monthlyRevenueService;

        public MonthlyRevenuesController(IMonthlyRevenueService monthlyRevenueService)
        {
            _monthlyRevenueService = monthlyRevenueService;
        }

        /// <summary>
        /// 取得上市公司每月營業收入
        /// </summary>
        /// <param name="request">上市公司每月營業收入查詢請求模型</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<QueryMonthlyRevenueReq>> GetPublicCompanyMonthlyRevenue(QueryMonthlyRevenueReq? request)
        {
            if (request == null)
            {
                request = new QueryMonthlyRevenueReq(); // 給一個預設值
            }

            List<QueryMonthlyRevenueReq> result = await _monthlyRevenueService.GetPublicCompanyMonthlyRevenue(request);
            return Ok(result);
        }

        /// <summary>
        /// 新增上市公司每月營業收入
        /// </summary>
        /// <param name="request">上市公司每月營業收入新增請求模型</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> InsertMonthlyRevenue([FromBody] MonthlyRevenueReq request)
        {
            var result = await _monthlyRevenueService.InsertMonthlyRevenue(request);

            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }
    }
}
