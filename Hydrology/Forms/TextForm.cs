using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Hydrology.CControls;
using Hydrology.Entity;
using Hydrology.DataMgr;
using System.Globalization;
using System.IO;
using Hydrology.DBManager.Interface;
using Hydrology.DBManager.DB.SQLServer;

namespace Hydrology.Forms
{
    public partial class TextForm : Form
    {
        #region 静态常量
        private static readonly string CS_Subcenter_All = "所有分中心";
        #endregion 静态常量

        #region 方法变量
        private IWaterProxy m_proxyWater;
        private IRainProxy m_proxyRain;
        #endregion

        public TextForm()
        {
            m_proxyWater = new CSQLWater();
            m_proxyRain = new CSQLRain();
            InitializeComponent();
            InitUI();
        }

        private void InitUI()
        {
            this.SuspendLayout();
            this.checkBox1.CheckedChanged += new EventHandler(EHCheckAllChanged);
            InitDate();
            InitSubCenter();
        }
        // 获取表格类型
        private string getType()
        {
            string result = "";
            foreach (var item in TableType.Controls)
            {
                if (item is RadioButton)
                {
                    RadioButton radioButton = item as RadioButton;
                    if (radioButton.Checked)
                    {
                        result = radioButton.Text.Trim();
                    }
                }
            }
            return result;
        }
        private void InitDate()
        {
            //DateTimer.CustomFormat = "yyyy年MM月";
            DateTimer.Value = DateTime.Now;
            endDateTime.Value = DateTime.Now;
        }
        private void InitSubCenter()
        {
            // 初始化分中心
            List<CEntitySubCenter> subcenter = CDBDataMgr.Instance.GetAllSubCenter();
            SubCenter.Items.Add(CS_Subcenter_All);
            for (int i = 0; i < subcenter.Count; ++i)
            {
                SubCenter.Items.Add(subcenter[i].SubCenterName);
            }
            this.SubCenter.SelectedIndex = 0;
            List<CEntityStation> iniStations = getStations(SubCenter.Text);
            List<CEntitySoilStation> iniSoilStations = getSoilStations(SubCenter.Text);
            //InitStations(iniStations);
            //InitSoilStations(iniSoilStations);

        }
        private List<CEntityStation> getStations(string subCenter)
        {
            List<CEntityStation> stations = new List<CEntityStation>();
            if (SubCenter.Text == CS_Subcenter_All)
            {
                // 统计所有站点的畅通率
                stations = CDBDataMgr.Instance.GetAllStation();
            }
            else
            {
                // 统计某个分中心的畅通率
                List<CEntityStation> stationsAll = CDBDataMgr.Instance.GetAllStation();
                CEntitySubCenter centerName = CDBDataMgr.Instance.GetSubCenterByName(subCenter);
                for (int i = 0; i < stationsAll.Count; ++i)
                {
                    if (stationsAll[i].SubCenterID == centerName.SubCenterID)
                    {
                        // 该测站在分中心内，添加到要查询的列表中
                        stations.Add(stationsAll[i]);
                    }
                }
            }
            return stations;
        }
        private List<CEntitySoilStation> getSoilStations(string subCenter)
        {
            List<CEntitySoilStation> stations = new List<CEntitySoilStation>();
            if (SubCenter.Text == CS_Subcenter_All)
            {
                // 统计所有的站点
                stations = CDBSoilDataMgr.Instance.GetAllSoilStation();
            }
            else
            {
                // 统计某个中心下的所有站点
                List<CEntitySoilStation> stationsAll = CDBSoilDataMgr.Instance.GetAllSoilStation();
                CEntitySubCenter centerName = CDBDataMgr.Instance.GetSubCenterByName(subCenter);
                for (int i = 0; i < stationsAll.Count; ++i)
                {
                    if (stationsAll[i].SubCenterID == centerName.SubCenterID)
                    {
                        // 该测站在分中心内，添加到要查询的列表中
                        stations.Add(stationsAll[i]);
                    }
                }
            }
            return stations;
        }
        private void InitStations(List<CEntityStation> stations)
        {
            this.StationSelect.Items.Clear();
            //this.StationSelect.Items.Add("所有站点");
            for (int i = 0; i < stations.Count; i++)
            {
                this.StationSelect.Items.Add(stations[i].StationID + "|" + stations[i].StationName);
            }
        }
        private void InitSoilStations(List<CEntitySoilStation> stations)
        {
            if (stations.Count > 0)
            {
                //this.stationSelect.Items.Clear();
                for (int i = 0; i < stations.Count; i++)
                {
                    this.StationSelect.Items.Add(stations[i].StationID + "|" + stations[i].StationName);
                }
                if (this.StationSelect.Items.Count > 0)
                {
                    this.StationSelect.SetItemChecked(0, true);
                }
            }
        }

        private void search_Click(object sender, EventArgs e)
        {
            //获取 radioButton 的table类型值；
            string tableType = "";
            foreach (var item in TableType.Controls)
            {
                if (item is RadioButton)
                {
                    RadioButton radioButton = item as RadioButton;
                    if (radioButton.Checked)
                    {
                        tableType = radioButton.Text.Trim();
                    }
                }
            }
            // 获取分中心
            string subcenterName = SubCenter.Text;
            //获取时间  date.value;
            // 获取站点信息 默认为全部站点
            List<string> stationSelected = new List<string>();

            int flagInt = 0;
            for (int i = 0; i < StationSelect.Items.Count; i++)
            {
                if (StationSelect.GetItemChecked(i))
                {
                    flagInt++;
                }
            }
            if (flagInt == 0)
            {
                for (int i = 0; i < StationSelect.Items.Count; i++)
                {
                    stationSelected.Add(StationSelect.GetItemText(StationSelect.Items[i]));
                }
            }
            else
            {
                for (int i = 0; i < StationSelect.Items.Count; i++)
                {
                    if (StationSelect.GetItemChecked(i))
                    {
                        stationSelected.Add(StationSelect.GetItemText(StationSelect.Items[i]));
                    }
                }
            }

            DateTime dt1 = DateTimer.Value;
            DateTime dt = dt1.Date;
            string type = getType();

            if (type.Equals("普通文本"))
            {
                CMessageBox box = new CMessageBox();
                box.MessageInfo = "正在查询数据库";
                box.ShowDialog(this);
                this.Enabled = false;
                this.Enabled = true;
                box.CloseDialog();
            }
            if (type.Equals("中澳格式"))
            {

                CMessageBox box = new CMessageBox();
                box.MessageInfo = "正在查询数据库";
                box.ShowDialog(this);
                this.Enabled = false;
                this.Enabled = true;
                box.CloseDialog();
            }
            if (type.Equals("墒    情"))
            {
                CMessageBox box = new CMessageBox();
                box.MessageInfo = "正在查询数据库";
                box.ShowDialog(this);
                this.Enabled = false;
                this.Enabled = true;
                box.CloseDialog();
            }
            this.Enabled = true;
        }

        private void export_Click(object sender, EventArgs e)
        {
            DateTime startTimeTmp = DateTimer.Value;
            DateTime endTimeTmp = endDateTime.Value;
            DateTime startTime = new DateTime(startTimeTmp.Year, startTimeTmp.Month, startTimeTmp.Day, 0, 0, 0);
            DateTime endTime = new DateTime(endTimeTmp.Year, endTimeTmp.Month, endTimeTmp.Day, 0, 0, 0);
            // 获取是雨量还是水位类型
            string type = getType();
            // 获取被选择的站点
            // 获取站点信息 默认为全部站点
            List<string> stationSelected = new List<string>();

            int flagInt = 0;
            for (int i = 0; i < StationSelect.Items.Count; i++)
            {
                if (StationSelect.GetItemChecked(i))
                {
                    flagInt++;
                }
            }
            if (flagInt == 0)
            {
                for (int i = 0; i < StationSelect.Items.Count; i++)
                {
                    stationSelected.Add(StationSelect.GetItemText(StationSelect.Items[i]));
                }
            }
            else
            {
                for (int i = 0; i < StationSelect.Items.Count; i++)
                {
                    if (StationSelect.GetItemChecked(i))
                    {
                        stationSelected.Add(StationSelect.GetItemText(StationSelect.Items[i]));
                    }
                }
            }
            #region 雨量数据
            if (type.Equals("雨  量"))
            {
                CMessageBox box = new CMessageBox();
                box.MessageInfo = "正在导出雨量数据";
                box.ShowDialog(this);
                try
                {
                    for (int i = 0; i < stationSelected.Count; i++)
                    {
                        string stationid = stationSelected[i].Split('|')[0];
                        string stationname = stationSelected[i].Split('|')[1];
                        List<CEntityRain> rainList = new List<CEntityRain>();
                        List<string> rainInfoText = new List<string>();
                        rainList = CDBDataMgr.GetInstance().getListRainByTime(stationid, startTime, endTime);
                        for (int j = 0; j < rainList.Count; j++)
                        {
                            DateTime dataAndTime = rainList[j].TimeCollect;
                            string rainInfo = string.Empty;
                            rainInfo = rainInfo + "\"";
                            string tmp = dataAndTime.ToString("d").Substring(2);
                            string year = dataAndTime.Year.ToString().Substring(2);
                            rainInfo = rainInfo + year + "/";
                            string month = dataAndTime.Month.ToString();
                            if (month.Length < 2)
                            {
                                month = "0" + month;
                            }
                            rainInfo = rainInfo + month + "/";
                            string day = dataAndTime.Day.ToString();
                            if (day.Length < 2)
                            {
                                day = "0" + day;
                            }
                            rainInfo = rainInfo + day + " ";
                            string hour = dataAndTime.Hour.ToString();
                            if (hour.Length < 2)
                            {
                                hour = "0" + hour;
                            }
                            rainInfo = rainInfo + hour;
                            string minute = dataAndTime.Minute.ToString();
                            if (minute.Length < 2)
                            {
                                minute = "0" + minute;
                            }
                            rainInfo = rainInfo + ":" + minute;

                            rainInfo = rainInfo + " ";
                            string rain = rainList[j].TotalRain.ToString();
                            for (int k = 0; k < 6 - rain.Length; k++)
                            {
                                rainInfo = rainInfo + "0";
                            }
                            rainInfo = rainInfo + rain;
                            rainInfo = rainInfo + "\"";
                            rainInfoText.Add(rainInfo);
                        }
                        if (rainInfoText != null && rainInfoText.Count > 1)
                        {
                            string fileName = "rainData" + "\\" + stationname + "站" + startTime.ToString("D") + "到" + endTime.ToString("D") + "雨量.Dat";
                            exportTxt(rainInfoText, fileName);
                        }

                    }
                    box.CloseDialog();
                    MessageBox.Show("导出雨量数据成功");
                }
                catch (Exception e1)
                {
                    box.CloseDialog();
                    MessageBox.Show("导出水位数据失败");
                }
            }
            #endregion

            #region 水位数据
            if (type.Equals("水  位"))
            {


                CMessageBox box = new CMessageBox();
                box.MessageInfo = "正在导出水位数据";
                box.ShowDialog(this);
                try
                {
                    for (int i = 0; i < stationSelected.Count; i++)
                    {
                        List<CEntityWater> waterList = new List<CEntityWater>();
                        string stationid = stationSelected[i].Split('|')[0];
                        string stationname = stationSelected[i].Split('|')[1];
                        List<string> waterInfoText = new List<string>();
                        waterList = CDBDataMgr.GetInstance().GetWaterByTime(stationid, startTime, endTime);
                        for (int j = 0; j < waterList.Count; j++)
                        {

                            DateTime dataAndTime = waterList[j].TimeCollect;
                            string waterInfo = string.Empty;
                            waterInfo = waterInfo + "\"";
                            string year = dataAndTime.Year.ToString().Substring(2);
                            waterInfo = waterInfo + year + "/";
                            string month = dataAndTime.Month.ToString();
                            if (month.Length < 2)
                            {
                                month = "0" + month;
                            }
                            waterInfo = waterInfo + month + "/";
                            string day = dataAndTime.Day.ToString();
                            if (day.Length < 2)
                            {
                                day = "0" + day;
                            }
                            waterInfo = waterInfo + day + " ";
                            string hour = dataAndTime.Hour.ToString();
                            if (hour.Length < 2)
                            {
                                hour = "0" + hour;
                            }
                            waterInfo = waterInfo + hour;
                            string minute = dataAndTime.Minute.ToString();
                            if (minute.Length < 2)
                            {
                                minute = "0" + minute;
                            }
                            waterInfo = waterInfo + ":" + minute;

                            waterInfo = waterInfo + " ";
                            decimal waterd = waterList[j].WaterStage;

                            string water = ((int)(waterd * 100)).ToString();
                            for (int k = 0; k < 6 - water.Length; k++)
                            {
                                waterInfo = waterInfo + "0";
                            }
                            waterInfo = waterInfo + water;
                            waterInfo = waterInfo + "\"";
                            waterInfoText.Add(waterInfo);
                        }
                        if (waterInfoText != null && waterInfoText.Count > 1)
                        {
                            string fileName = "waterData" + "\\" + stationname + "站" + startTime.ToString("D") + "到" + endTime.ToString("D") + "水位.Dat";
                            exportTxt(waterInfoText, fileName);
                        }

                    }
                    box.CloseDialog();
                    MessageBox.Show("导出水位数据成功");
                }
                catch (Exception e2)
                {
                    box.CloseDialog();
                    MessageBox.Show("导出水位数据失败");

                }


            }
            #endregion

            #region 中澳格式数据
            if (type.Equals("中澳格式"))
            {
                CMessageBox box = new CMessageBox();
                box.MessageInfo = "正在导出中澳格式数据";
                box.ShowDialog(this);
                try
                {
                    for (int i = 0; i < stationSelected.Count; i++)
                    {
                        List<CEntityRainAndWater> rainWaterList = new List<CEntityRainAndWater>();

                        string stationid = stationSelected[i].Split('|')[0];
                        string stationname = stationSelected[i].Split('|')[1];
                        List<string> hydroInfoText = new List<string>();
                        rainWaterList = CDBDataMgr.GetInstance().getRainAndWaterList(stationid, startTime, endTime);
                        if (rainWaterList == null || rainWaterList.Count == 0)
                        {
                            continue;
                        }

                        for (int j = 0; j < rainWaterList.Count; j++)
                        {
                            DateTime dataAndTime = DateTime.Now; ;
                            if (rainWaterList[j].rainTimeCollect <= DateTime.Now)
                            {
                                dataAndTime = rainWaterList[j].rainTimeCollect;
                            }
                            else if (rainWaterList[j].waterTimeCollect <= DateTime.Now)
                            {
                                dataAndTime = rainWaterList[j].waterTimeCollect;
                            }
                            else
                            {
                                continue;
                            }
                            string hydroInfo = string.Empty;
                            hydroInfo = hydroInfo + "1,";
                            hydroInfo = hydroInfo + dataAndTime.Year.ToString() + ",";
                            hydroInfo = hydroInfo + getDayOfYear(dataAndTime).ToString() + ",";
                            string hour = dataAndTime.Hour.ToString();
                            if (hour.Length < 2)
                            {
                                hour = "0" + hour;
                            }
                            string minute = dataAndTime.Minute.ToString();
                            if (minute.Length < 2)
                            {
                                minute = "0" + minute;
                            }
                            hydroInfo = hydroInfo + hour + minute + ",";
                            hydroInfo = hydroInfo + stationid.ToString() + ",";
                            if (rainWaterList[j].WaterStage != -9999)
                            {
                                hydroInfo = hydroInfo + rainWaterList[j].WaterStage.ToString() + ",";
                            }
                            else
                            {
                                hydroInfo = hydroInfo + ",";
                            }
                            if (rainWaterList[j].TotalRain != -9999)
                            {
                                hydroInfo = hydroInfo + rainWaterList[j].TotalRain.ToString() + ",";
                            }
                            else
                            {
                                hydroInfo = hydroInfo + ",";
                            }
                            hydroInfo = hydroInfo + "12.85";
                            hydroInfoText.Add(hydroInfo);
                        }
                        if (hydroInfoText != null && hydroInfoText.Count > 1)
                        {
                            string fileName = "specData" + "\\" + stationname + "站" + startTime.ToString("D") + "到" + endTime.ToString("D") + "数据.Dat";
                            exportTxt(hydroInfoText, fileName);
                        }

                    }
                    box.CloseDialog();
                    MessageBox.Show("导出中澳数据成功");
                }
                catch (Exception e2)
                {
                    box.CloseDialog();
                    MessageBox.Show("导出中澳数据失败");

                }
            }
            #endregion
            this.Focus();
        }

        private void center_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<CEntityStation> iniStations = getStations(SubCenter.Text);
            InitStations(iniStations);
            List<CEntitySoilStation> iniSoilStations = getSoilStations(SubCenter.Text);
            InitSoilStations(iniSoilStations);
        }
        private void TableTypeChanged(object sender, EventArgs e)
        {
            string type = getType();
        }

        private void EHCheckAllChanged(object sender, EventArgs e)
        {
            if (checkBox1.CheckState == CheckState.Checked)
            {
                // 全选
                for (int i = 0; i < StationSelect.Items.Count; i++)
                {
                    this.StationSelect.SetItemChecked(i, true);
                }

            }
            else
            {
                // 全不选
                for (int i = 0; i < StationSelect.Items.Count; i++)
                {
                    this.StationSelect.SetItemChecked(i, false);
                }

            }
        }

        #region 帮助方法
        public int getDayOfYear(DateTime date)
        {
            DateTime startDate = new DateTime(DateTime.Now.Year, 1, 1, 0, 0, 0);
            int dayOfYear = (date - startDate).Days + 1;
            return dayOfYear;
        }

        public void exportTxt(List<string> list, string txtFile)
        {
            FileStream fs = new FileStream(txtFile, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            try
            {
                sw.Flush();
                // 使用StreamWriter来往文件中写入内容 
                sw.BaseStream.Seek(0, SeekOrigin.Begin);
                for (int i = 0; i < list.Count; i++)
                {
                    sw.WriteLine(list[i]);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("导出水位数据失败11");
            }
            finally
            {
                //关闭此文件t 
                sw.Flush();
                sw.Close();
                fs.Close();
            }
        }

        #endregion


    }
}
