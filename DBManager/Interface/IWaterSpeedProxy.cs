using Entity;
using Hydrology.DBManager.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBManager.Interface
{
    public interface IWaterSpeedProxy : IMultiThread
    {
        List<CEntityWaterSpeed> QueryByTime(string station, DateTime start, DateTime end);


        void batchInsertRows(List<CEntityWaterSpeed> waterSpeedList);
        void batchInsertRows2(List<CEntityWaterSpeed> waterSpeedList);
    }
}
