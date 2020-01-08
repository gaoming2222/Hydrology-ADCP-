/************************************************************************************
* Copyright (c) 2018 All Rights Reserved.
*命名空间：Entity
*文件名： CEntityRainAndWater
*创建人： XXX
*创建时间：2018-12-25 8:25:06
*描述
*=====================================================================
*修改标记
*修改时间：2018-12-25 8:25:06
*修改人：XXX
*描述：
************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hydrology.Entity
{
    public class CEntityRainAndWater
    {
        #region PROPERTY

        public string rainStationId { get; set; }

        public DateTime rainTimeCollect { get; set; }

        public Nullable<Decimal> TotalRain { get; set; }

        public string waterStationId { get; set; }

        public DateTime waterTimeCollect { get; set; }

        public Nullable<Decimal> WaterStage { get; set; }

        #endregion
    }
}