﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Pipes;
using System.Threading;
using System.Diagnostics;

namespace Cosmos.Debug.HostProcess
{
    public class Program
    {
        static int Main(string[] args)
        {
            Console.ReadLine();
            var xStartInfo = new ProcessStartInfo();
            xStartInfo.FileName = args[0];
            xStartInfo.Arguments = String.Join(" ", args.Skip(1).ToArray());
            xStartInfo.RedirectStandardError = true;
            xStartInfo.RedirectStandardOutput = true;
            xStartInfo.UseShellExecute = false;
            var xProcess = Process.Start(xStartInfo);
            xProcess.WaitForExit();
            Console.WriteLine(xProcess.StandardError.ReadToEnd());
            Console.WriteLine(xProcess.StandardOutput.ReadToEnd());
            return xProcess.ExitCode;
        }
    }
}