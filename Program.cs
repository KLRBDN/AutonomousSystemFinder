using System;

namespace Internet_Protocols._Task_1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Здесь вы можете поменять defaultArg на нужный вам ip
            // Например "74.125.77.147" - ip Google
            string defaultArg = null;
            if (args.Length != 1 && defaultArg == null)
            {
                throw new ArgumentException(
                    "Incorrect input, there must be one parameter which is an ip or a domain name");
            }

            var data = Processor.ProcessIp(defaultArg is null ? args[0] : defaultArg);
            TableBuilder.Build(data);
        }
    }
}