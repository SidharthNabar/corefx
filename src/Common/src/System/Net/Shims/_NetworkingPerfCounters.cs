// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Net.Sockets;
using System.Diagnostics;
using System.Threading;

namespace System.Net
{
    internal enum NetworkingPerfCounterName
    {
        SocketConnectionsEstablished = 0, // these enum values are used as index
        SocketBytesReceived,
        SocketBytesSent,
        SocketDatagramsReceived,
        SocketDatagramsSent,
        HttpWebRequestCreated,
        HttpWebRequestAvgLifeTime,
        HttpWebRequestAvgLifeTimeBase,
        HttpWebRequestQueued,
        HttpWebRequestAvgQueueTime,
        HttpWebRequestAvgQueueTimeBase,
        HttpWebRequestAborted,
        HttpWebRequestFailed
    }

    internal sealed class NetworkingPerfCounters
    {
        private static NetworkingPerfCounters instance;
        private static object lockObject = new object();

        public static NetworkingPerfCounters Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockObject)
                    {
                        if (instance == null)
                        {
                            instance = new NetworkingPerfCounters();
                        }
                    }
                }
                return instance;
            }
        }

        public static long GetTimestamp()
        {
            return Stopwatch.GetTimestamp();
        }

        public bool Enabled
        {
            get { return false; }
        }

        public void Increment(NetworkingPerfCounterName perfCounter)
        {
        }

        public void Increment(NetworkingPerfCounterName perfCounter, long amount)
        {
        }
    }

    internal class PerformanceCounter
    {
    }
}

