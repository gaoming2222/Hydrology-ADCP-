using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;
using Hydrology.Entity;

namespace Hydrology.DBManager.Interface
{
    public interface IEvaProxy : IMultiThread
    { /// <summary>
      /// 异步添加雨量记录
      /// </summary>
      /// <param name="rain"></param>
        void AddNewRow(CEntityEva eva);

        /// <summary>
        /// 异步添加新的雨量记录
        /// </summary>
       // /// <param name="rains"></param>
        void AddNewRows(List<CEntityEva> evas);

        // 异步添加新的一个电压记录,不需等待1分钟
        void AddNewRows_DataModify(List<CEntityEva> evas);

        bool DeleteRows(List<String> evas_StationId, List<String> evas_StationDate);

        void SetFilter(string stationId, DateTime timeStart, DateTime timeEnd, bool TimeSelect);

        /// <summary>
        /// 获取当前选择条件下，总共页面数
        /// </summary>
        /// <returns>-1 表示查询失败</returns>
        int GetPageCount();

        /// <summary>
        /// 获取当前选择条件下，总共的行数
        /// </summary>
        /// <returns>-1 表示查询失败</returns>
        int GetRowCount();


        bool UpdateRows(string sqlStr);

        List<CEntityEva> GetPageData(int pageIndex,bool irefresh);

        List<CEntityEva> getEvabyTime(string stationid, DateTime start, DateTime end);
    }
}
