// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;

internal static partial class Interop
{
    internal static partial class Winsock
    {
        [DllImport(Interop.Libraries.Ws2_32, CharSet = CharSet.Unicode, BestFitMapping = false, ThrowOnUnmappableChar = true, SetLastError = true)]
        internal static extern SocketError GetNameInfoW(
            [In]         byte[] sa,
            [In]         int salen,
            [In, Out]     StringBuilder host,
            [In]         int hostlen,
            [In, Out]     StringBuilder serv,
            [In]         int servlen,
            [In]         int flags);
    }
}
