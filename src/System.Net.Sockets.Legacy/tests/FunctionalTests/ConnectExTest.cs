﻿using System.Threading;

using Xunit;

namespace System.Net.Sockets.Tests
{
    public class ConnectExTest
    {
        private const int TestPortBase = 8030;

        private static void OnConnectAsyncCompleted(object sender, SocketAsyncEventArgs args)
        {
            ManualResetEvent complete = (ManualResetEvent)args.UserToken;
            complete.Set();
        }

        [Fact]
        public void Success()
        {
            SocketTestServer server = SocketTestServer.SocketTestServerFactory(new IPEndPoint(IPAddress.Loopback, TestPortBase));
            SocketTestServer server6 = SocketTestServer.SocketTestServerFactory(new IPEndPoint(IPAddress.IPv6Loopback, TestPortBase));

            Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            SocketAsyncEventArgs args = new SocketAsyncEventArgs();
            args.RemoteEndPoint = new IPEndPoint(IPAddress.Loopback, TestPortBase);
            args.Completed += OnConnectAsyncCompleted;

            ManualResetEvent complete = new ManualResetEvent(false);
            args.UserToken = complete;

            Assert.True(sock.ConnectAsync(args));

            Assert.True(complete.WaitOne(5000), "IPv4: Timed out while waiting for connection");

            Assert.True(args.SocketError == SocketError.Success);

            sock.Dispose();

            sock = new Socket(AddressFamily.InterNetworkV6, SocketType.Stream, ProtocolType.Tcp);
            args.RemoteEndPoint = new IPEndPoint(IPAddress.IPv6Loopback, TestPortBase);
            complete.Reset();

            Assert.True(sock.ConnectAsync(args));

            Assert.True(complete.WaitOne(5000), "IPv6: Timed out while waiting for connection");

            Assert.True(args.SocketError == SocketError.Success);

            sock.Dispose();

            server.Dispose();
            server6.Dispose();
        }

        #region GC Finalizer test
        // This test assumes sequential execution of tests and that it is going to be executed after other tests
        // that used Sockets. 
        [Fact]
        public void TestFinalizers()
        {
            // Making several passes through the FReachable list.
            for (int i = 0; i < 3; i++)
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }
        #endregion 
    }
}
