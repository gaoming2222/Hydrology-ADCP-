using Entity;
using Hydrology.DBManager.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBManager.Interface
{
    public interface IStationMapProxy : IMultiThread
    {
        /// <summary>
        /// 添加站点映射信息
        /// </summary>
        /// <param name="listUser"></param>
        /// <returns></returns>
        bool AddRange(List<CEntityStationMap> stationMapList);

        /// <summary>
        /// 更新站点映射信息
        /// </summary>
        /// <param name="listUser"></param>
        /// <returns></returns>
        bool UpdateRange(List<CEntityStationMap> stationMapList);

        /// <summary>
        /// 删除站点映射信息
        /// </summary>
        /// <param name="listUser"></param>
        /// <returns></returns>
        bool DeleteRange(List<string> stationIDList);

        /// <summary>
        /// 查询所有站点映射信息
        /// </summary>
        /// <returns></returns>
        List<CEntityStationMap> QueryAll();
    }
}
