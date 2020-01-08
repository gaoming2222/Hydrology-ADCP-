using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Hydrology.DataMgr
{
    public class TCPHelper
    {
        #region 单例模式
        private static TCPHelper m_sInstance;
        private static String ipAddress = "112.112.18.212";
        private static int port = 20020;
        private Socket clientSocket;
        private TCPHelper()
        {
            initSocket();
        }
        public static TCPHelper GetInstance()
        {
            if (m_sInstance == null)
            {
                m_sInstance = new TCPHelper();
            }
            return m_sInstance;
        }
        #endregion

        #region 初始化socket连接
        public bool initSocket()
        {
            bool flag = false;
            IPAddress ip = IPAddress.Parse(ipAddress);
            try
            {
                clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Udp);
                clientSocket.Connect(new IPEndPoint(IPAddress.Parse(ipAddress), port)); //配置服务器IP与端口  
                flag = true;
                CSystemInfoMgr.Instance.AddInfo("TCP连接成功");
            }
            catch (Exception e)
            {
                flag = false;
            }
            return flag;
        }
        #endregion

        public bool sendMsgTcp(String msg)
        {
            bool flag = true;
            if (clientSocket == null)
            {
                initSocket();
            }
            try
            {
                CSystemInfoMgr.Instance.AddInfo("TCP发送" + msg);
                clientSocket.Send(this.hexStringToByte(msg));
            }
            catch (Exception e)
            {
                clientSocket.Shutdown(SocketShutdown.Both);
                clientSocket.Close();
                flag = false;
            }
            return flag;

        }


        public string recvData()
        {
            String result = String.Empty;
            byte[] data = new byte[1024];
            //传递一个byte数组，用于接收数据。length表示接收了多少字节的数据
            int length = clientSocket.Receive(data);
            string message = this.byteToHexStr(data, length);//只将接收到的数据进行转化
            return result;
        }

        public bool shutDown()
        {
            try
            {
                if (clientSocket != null)
                {
                    clientSocket.Shutdown(SocketShutdown.Both);
                    clientSocket.Close();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                CSystemInfoMgr.Instance.AddInfo("关闭TCP连接失败");
                return false;
            }
        }
        /// <summary>
        /// 16进制（规约中使用过）
        /// </summary>
        /// <param name="hex"></param>
        /// <returns></returns>
        private byte[] hexStringToByte(String hex)
        {
            int len = (hex.Length / 2);
            byte[] result = new byte[len];
            char[] achar = hex.ToCharArray();
            for (int i = 0; i < len; i++)
            {
                int pos = i * 2;
                result[i] = (byte)(toByte(achar[pos]) << 4 | toByte(achar[pos + 1]));
            }
            return result;
        }
        private int toByte(char c)
        {
            byte b = (byte)"0123456789ABCDEF".IndexOf(c);
            return b;
        }
        /// <summary>
        /// 网络download
        /// </summary>
        /// <param name="hexString"></param>
        /// <returns></returns>
        // 16进制字符串转字节数组   格式为 string sendMessage = "00 01 00 00 00 06 FF 05 00 64 00 00";
        private byte[] HexStrTobyte(string hexString)
        {
            hexString = hexString.Replace(" ", "");
            if ((hexString.Length % 2) != 0)
                hexString += " ";
            byte[] returnBytes = new byte[hexString.Length / 2];
            for (int i = 0; i < returnBytes.Length; i++)
                returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2).Trim(), 16);
            return returnBytes;
        }

        // 字节数组转16进制字符串   
        private string byteToHexStr(byte[] bytes, int length)
        {
            string returnStr = "";
            if (bytes != null)
            {
                for (int i = 0; i < length; i++)
                {
                    returnStr += bytes[i].ToString("X2");//ToString("X2") 为C#中的字符串格式控制符
                }
            }
            return returnStr;
        }

    }
}
