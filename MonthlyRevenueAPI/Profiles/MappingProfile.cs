using AutoMapper;
using MonthlyRevenueAPI.Models;
using MonthlyRevenueAPI.DTOs;

namespace MonthlyRevenueAPI.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region ===== 查詢 =====
            // DTO => Entity
            CreateMap<QueryMonthlyRevenueReq, MonthlyRevenue>();

            // Entity => DTO
            CreateMap<MonthlyRevenue, QueryMonthlyRevenueReq>();
            #endregion

            #region ===== 新增 =====
            // DTO => Entity
            CreateMap<MonthlyRevenueReq, MonthlyRevenue>();

            // Entity => DTO
            CreateMap<MonthlyRevenue, MonthlyRevenueReq>();
            #endregion
        }
    }
}
