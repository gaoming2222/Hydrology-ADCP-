/************************************************************************************
* Copyright (c) 2019 All Rights Reserved.
*命名空间：Hydrology.DataMgr
*文件名： QCal
*创建人： XXX
*创建时间：2019-6-26 18:29:59
*描述
*=====================================================================
*修改标记
*修改时间：2019-6-26 18:29:59
*修改人：XXX
*描述：
************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hydrology.DataMgr
{
    public class QCal
    {
        public static double Qcalc(double waterLevel, double v1, double v2, double v3, double v4)
        {
            //====================读大断面信息：起点距，高程(先手动输入)=======================
            //起点距
            double[] d1 = { 0.0, 0.2, 1.9, 4, 5.7, 7.1, 11.1, 13.1, 16.1, 19.2, 22.1, 25.3, 28.5, 29.3, 30.6, 32.3, 37.8, 40.8, 43.1, 44.7, 46.9, 49.9, 53.3, 56.2, 60, 64.9, 66.3, 68.4, 70, 71.9 };
            //高程
            double[] d2 = { 151.03, 150.80, 150.24, 149.55, 148.99, 148.52, 147.20, 146.58, 145.58, 144.56, 143.58, 142.56, 141.50, 141.20, 141.10, 141.10, 141.12, 141.12, 141.32, 141.82, 142.50, 143.48, 144.52, 145.52, 146.78, 148.50, 148.94, 149.65, 150.20, 150.81 };

            //=========================计算过水面积==============================
            double WL = waterLevel;


            //计算各垂线之间的宽度
            double[] width = new double[d1.Length - 1];
            for (int i = 0; i < width.Length; i++)
            {
                width[i] = d1[i + 1] - d1[i];
            }

            //定义一个列数=ds1.length，行数=ds4.length的二维数组,用来存储所有水位下各垂线水深
            //每一个水位对应的各垂线的水深为一列。
            double[] DH = new double[d2.Length];//处理之前的水深,用以计算左右岸流量
            double[] dH = new double[d2.Length];//处理过的水深，用以判断水面与断面交点
                                                //根据起点距、水位，计算垂线水深。
            for (int i = 0; i < d2.Length; i++)
            {
                DH[i] = WL - d2[i];
                dH[i] = DH[i];
                if (dH[i] < 0)
                {
                    dH[i] = 0;
                }
                DH[i] = Math.Abs(DH[i]);
            }

            int min = 0;
            int max = 0;
            //不同水位下，确定水面线与左右岸交点的位置;min为左岸第一个有水深的垂线（min的数值比索引大1，所以后面流量计算时索引为min-1，同后面的max），max为右岸最后一个有水深的垂线
            for (int i = 1; i < d2.Length; i++)
            {
                if (dH[i - 1] == 0 && dH[i] > 0)
                {
                    min = i + 1;
                }
                if (dH[i] > 0)
                {
                    max = i;
                }
            }
            //过水面积
            double A = 0.0;
            for (int i = min; i <= max - 1; i++)
            {
                //断面流量=左岸流量+右岸流量+中间部分流量
                A += (0.5 * (dH[i - 1] + dH[i]) * width[i - 1]);
            }
            A += 0.5 * (Math.Pow(DH[min - 1], 2.0) / (DH[min - 1] + DH[min - 2])) * (d1[min - 1] - d1[min - 2]) + 0.5 * (Math.Pow(DH[max], 2.0) / (DH[max] + DH[max + 1])) * (d1[max + 1] - d1[max]);



            //======================计算流量=====================
            double Q = 0.5 * (v1 + v2) * A;

            return Q;




        }





    }
}
