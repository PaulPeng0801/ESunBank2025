using MonthlyRevenueAPI.DTOs;
using MonthlyRevenueAPI.Models;

namespace MonthlyRevenueAPI.Services.Interface
{
    public interface IMonthlyRevenueService
    {
        /// <summary>
        /// 取得上市公司每月營業收入
        /// </summary>
        /// <param name="request">上市公司每月營業收入查詢請求模型</param>
        /// <returns></returns>
        Task<List<QueryMonthlyRevenueReq>> GetPublicCompanyMonthlyRevenue(QueryMonthlyRevenueReq request);

        /// <summary>
        /// 新增上市公司每月營業收入
        /// </summary>
        /// <param name="request">上市公司每月營業收入新增請求模型</param>
        /// <returns></returns>
        Task<ReturnResult> InsertMonthlyRevenue(MonthlyRevenueReq request);
    }
}
