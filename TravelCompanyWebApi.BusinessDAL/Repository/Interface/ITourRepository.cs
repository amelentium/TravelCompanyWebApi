﻿using TravelCompanyWebApi.BusinessDAL.Entity;
using TravelCompanyWebApi.BusinessDAL.Repositories.Interfaces;

namespace TravelCompanyWebApi.BusinessDAL.Repository.Interface
{
    public interface ITourRepository : IGenericRepository<Tour, int>
    {
    }
}
