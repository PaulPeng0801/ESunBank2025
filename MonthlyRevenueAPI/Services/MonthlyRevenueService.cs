using MonthlyRevenueAPI.Services.Interface;
using MonthlyRevenueAPI.DTOs;
using MonthlyRevenueAPI.Repositories.Interface;
using AutoMapper;
using MonthlyRevenueAPI.Models;

namespace MonthlyRevenueAPI.Services
{
    public class MonthlyRevenueService: IMonthlyRevenueService
    {
        private readonly IMonthlyRevenueRepository _monthlyRevenueRepository;
        private readonly IMapper _mapper;

        public MonthlyRevenueService( IMonthlyRevenueRepository monthlyRevenueRepository
            , IMapper mapper)
        {
            _monthlyRevenueRepository = monthlyRevenueRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// 取得上市公司每月營業收入
        /// </summary>
        /// <param name="request">上市公司每月營業收入查詢請求模型</param>
        /// <returns></returns>
        public async Task<List<QueryMonthlyRevenueReq>> GetPublicCompanyMonthlyRevenue(QueryMonthlyRevenueReq request)
        {
            // 用AutoMapper，DTO => Entity
            var entity = _mapper.Map<MonthlyRevenue>(request);

            var results = await _monthlyRevenueRepository.FindPublicCompanyMonthlyRevenue(entity);

            // Entity => DTO
            var dtoResults = _mapper.Map<List<QueryMonthlyRevenueReq>>(results);

            return dtoResults;
        }

        /// <summary>
        /// 新增上市公司每月營業收入
        /// </summary>
        /// <param name="request">上市公司每月營業收入新增請求模型</param>
        /// <returns></returns>
        public async Task<ReturnResult> InsertMonthlyRevenue(MonthlyRevenueReq request)
        {
            // 檢查CompanyCode是否必填
            if (string.IsNullOrWhiteSpace(request.CompanyCode))
            {
                return new ReturnResult
                {
                    Success = false,
                    Message = "CompanyCode 為必填欄位"
                };
            }

            // DTO => Entity
            var entity = _mapper.Map<MonthlyRevenue>(request);

            // 新增
            var result = await _monthlyRevenueRepository.InsertMonthlyRevenue(entity);

            return result;
        }
    }
}
