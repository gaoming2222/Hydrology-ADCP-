using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity.Protocol.Channel
{
    public class CRouter
    {
        public int dataLength { get; set; }

        public string dutid { get; set; }

        public string sessionid { get; set; }

        public string data { get; set; }

        public byte[] rawData { get; set; }

        public byte[] receiveTime { get; set; }
    }
}
