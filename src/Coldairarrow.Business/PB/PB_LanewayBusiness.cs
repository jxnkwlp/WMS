﻿using Coldairarrow.Entity.PB;
using Coldairarrow.Util;
using EFCore.Sharding;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace Coldairarrow.Business.PB
{
    public class PB_LanewayBusiness : BaseBusiness<PB_Laneway>, IPB_LanewayBusiness, ITransientDependency
    {
        public PB_LanewayBusiness(IRepository repository)
            : base(repository)
        {
        }

        #region 外部接口

        public async Task<PageResult<PB_Laneway>> GetDataListAsync(PageInput<PB_LanewayQM> input)
        {
            var q = GetIQueryable();
            var where = LinqHelper.True<PB_Laneway>();
            var search = input.Search;

            //筛选
            //if (!search.Condition.IsNullOrEmpty() && !search.Keyword.IsNullOrEmpty())
            //{
            //    var newWhere = DynamicExpressionParser.ParseLambda<PB_Laneway, bool>(
            //        ParsingConfig.Default, false, $@"{search.Condition}.Contains(@0)", search.Keyword);
            //    where = where.And(newWhere);
            //}
            if (!search.Name.IsNullOrEmpty())
                where = where.And(w => w.Name.Contains(search.Name));
            if (!search.Code.IsNullOrEmpty())
                where = where.And(w => w.Code.Contains(search.Code));

            return await q.Where(where).GetPageResultAsync(input);
        }

        public async Task<PB_Laneway> GetTheDataAsync(string id)
        {
            return await GetEntityAsync(id);
        }

        public async Task AddDataAsync(PB_Laneway data)
        {
            await InsertAsync(data);
        }

        public async Task UpdateDataAsync(PB_Laneway data)
        {
            await UpdateAsync(data);
        }

        public async Task DeleteDataAsync(List<string> ids)
        {
            await DeleteAsync(ids);
        }

        #endregion

        #region 私有成员

        #endregion
    }
}