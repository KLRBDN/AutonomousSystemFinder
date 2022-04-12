using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;

namespace Internet_Protocols._Task_1
{
    public static class TraceRoute
    {
        private const int BufferSize = 32;
        private const int Timeout = 50;
        private const int Ttl = 30;

        public static IEnumerable<IPAddress> GetTraceRoute(string hostname)
        {
            var buffer = Enumerable.Repeat<byte>(0, BufferSize).ToArray();

            using var pinger = new Ping();
            for (var count = 1; count < Ttl + 1; count++)
            {
                var options = new PingOptions(count, true);

                PingReply reply;

                try
                {
                    reply = pinger.Send(hostname, Timeout, buffer, options);
                }
                catch (PingException)
                {
                    Console.WriteLine($"Can't ping server. There are several reasons for this problem: \n 1. Wrong IP or domain name \n 2. Internet connection lost \n 3. Timeout \n\n Ip/Domain Name was {hostname}\n");
                    throw;
                }

                if (reply is null)
                {
                    continue;
                }

                if (reply.Status is IPStatus.Success or IPStatus.TtlExpired)
                    yield return reply.Address;

                if (reply.Status != IPStatus.TtlExpired && reply.Status != IPStatus.TimedOut)
                    break;
            }
        }
    }
}