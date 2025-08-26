using Microsoft.EntityFrameworkCore;
using MonthlyRevenueAPI.Models;
using MonthlyRevenueAPI.Repositories.Interface;

namespace MonthlyRevenueAPI.Repositories
{
    public class MonthlyRevenueRepository : IMonthlyRevenueRepository
    {
        private readonly PublicCompanyContext _dbContext;

        public MonthlyRevenueRepository( PublicCompanyContext context)
        {
            _dbContext = context;
        }

        /// <summary>
        /// 取得上市公司每月營業收入
        /// </summary>
        /// <param name="request">上市公司每月營業收入查詢請求模型</param>
        /// <returns></returns>
        public async Task<List<MonthlyRevenue>> FindPublicCompanyMonthlyRevenue(MonthlyRevenue request)
        {
            var query = _dbContext.MonthlyRevenues.AsQueryable();

            // 取得MonthlyRevenue所有屬性
            var properties = typeof(MonthlyRevenue).GetProperties();

            // 利用迴圈，將request中有的值，組成對應的query條件
            foreach (var prop in properties)
            {
                var value = prop.GetValue(request) as string;
                if (!string.IsNullOrEmpty(value))
                {
                    query = query.Where(x => EF.Property<string>(x, prop.Name) == value);
                }
            }
            return await query.ToListAsync();
        }

        /// <summary>
        /// 新增上市公司每月營業收入
        /// </summary>
        /// <param name="request">上市公司每月營業收入新增請求模型</param>
        /// <returns></returns>
        public async Task<ReturnResult> InsertMonthlyRevenue(MonthlyRevenue request)
        {
            try
            {
                _dbContext.MonthlyRevenues.Add(request);
                await _dbContext.SaveChangesAsync();

                return new ReturnResult
                {
                    Success = true,
                    Message = "新增成功"
                };
            }
            catch (Exception ex)
            {
                return new ReturnResult
                {
                    Success = false,
                    Message = $"新增失敗: {ex.Message}"
                };
            }
        }
    }
}
