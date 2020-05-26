﻿using Coldairarrow.Business.TD;
using Coldairarrow.Entity.TD;
using Coldairarrow.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Controllers.TD
{
    [Route("/TD/[controller]/[action]")]
    public class TD_InStorDetailController : BaseApiController
    {
        #region DI

        public TD_InStorDetailController(ITD_InStorDetailBusiness tD_InStorDetailBus)
        {
            _tD_InStorDetailBus = tD_InStorDetailBus;
        }

        ITD_InStorDetailBusiness _tD_InStorDetailBus { get; }

        #endregion

        #region 获取

        [HttpPost]
        public async Task<PageResult<TD_InStorDetail>> GetDataList(PageInput<ConditionDTO> input)
        {
            return await _tD_InStorDetailBus.GetDataListAsync(input);
        }

        [HttpPost]
        public async Task<TD_InStorDetail> GetTheData(IdInputDTO input)
        {
            return await _tD_InStorDetailBus.GetTheDataAsync(input.id);
        }

        #endregion

        #region 提交

        [HttpPost]
        public async Task SaveData(TD_InStorDetail data)
        {
            if (data.Id.IsNullOrEmpty())
            {
                InitEntity(data);

                await _tD_InStorDetailBus.AddDataAsync(data);
            }
            else
            {
                await _tD_InStorDetailBus.UpdateDataAsync(data);
            }
        }

        [HttpPost]
        public async Task DeleteData(List<string> ids)
        {
            await _tD_InStorDetailBus.DeleteDataAsync(ids);
        }

        #endregion
    }
}