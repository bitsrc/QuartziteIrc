using System;
using System.Net;
using System.Collections.Generic;

namespace Quartzite
{
    public class Base64
    {
        public static String EncodeIp(string ip)
        {
            IPAddress address = IPAddress.Parse(ip);
            return Convert.ToBase64String(address.GetAddressBytes());
        }

        public static String DecodeIp(string ip)
        {
            byte[] ipNum = Convert.FromBase64String(ip);
            IPAddress address = new IPAddress(ipNum);
            return address.ToString();
        }
    }
}
