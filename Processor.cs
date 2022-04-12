using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Internet_Protocols._Task_1
{
    public static class Processor
    {
        public static List<string[]> ProcessIp(string ip)
        {
            var ipAddresses = TraceRoute.GetTraceRoute(ip).ToArray();
            if (ipAddresses.Length == 0)
            {
                throw new WebException("Ping didn't provide any info, traceroute didn't respond\n");
            }

            var asnList = new List<string[]>();
            for (int i = 0; i < ipAddresses.Length; i++)
            {
                var info = new string[5];
                var ipAsString = ipAddresses[i].ToString();
                var asnFinder = new DataFinder(ipAsString);
                info[0] = (i + 1).ToString();
                info[1] = ipAsString;
                info[2] = asnFinder.GetAsnFromIp();
                info[3] = asnFinder.GetCountryFromIp();
                info[4] = asnFinder.GetProviderFromIp();
                asnList.Add(info);
            }

            return asnList;
        }
    }
}