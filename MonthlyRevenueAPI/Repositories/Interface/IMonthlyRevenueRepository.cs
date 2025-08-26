using MonthlyRevenueAPI.Models;

namespace MonthlyRevenueAPI.Repositories.Interface
{
    public interface IMonthlyRevenueRepository
    {
        /// <summary>
        /// 取得上市公司每月營業收入
        /// </summary>
        /// <param name="request">上市公司每月營業收入查詢請求模型</param>
        /// <returns></returns>
        Task<List<MonthlyRevenue>> FindPublicCompanyMonthlyRevenue(MonthlyRevenue request);

        /// <summary>
        /// 新增上市公司每月營業收入
        /// </summary>
        /// <param name="request">上市公司每月營業收入新增請求模型</param>
        /// <returns></returns>
        Task<ReturnResult> InsertMonthlyRevenue(MonthlyRevenue request);
    }
}
