// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.


/// <summary><para>
///    Provides support for ip configuation information and statistics.
///</para></summary>     
///


using System.Net.Sockets;
using System;
using System.ComponentModel;

namespace System.Net.NetworkInformation
{
    internal enum IcmpV6StatType
    {
        DestinationUnreachable = 1,
        PacketTooBig = 2,
        TimeExceeded = 3,
        ParameterProblem = 4,
        EchoRequest = 128,
        EchoReply = 129,
        MembershipQuery = 130,
        MembershipReport = 131,
        MembershipReduction = 132,
        RouterSolicit = 133,
        RouterAdvertisement = 134,
        NeighborSolict = 135,
        NeighborAdvertisement = 136,
        Redirect = 137,
    };



    /// <summary>Icmp statistics for Ipv6.</summary>
    internal class SystemIcmpV6Statistics : IcmpV6Statistics
    {
        private MibIcmpInfoEx _stats;

        internal SystemIcmpV6Statistics()
        {
            uint result = UnsafeNetInfoNativeMethods.GetIcmpStatisticsEx(out _stats, AddressFamily.InterNetworkV6);

            if (result != IpHelperErrors.Success)
            {
                throw new NetworkInformationException((int)result);
            }
        }

        public override long MessagesSent { get { return (long)_stats.outStats.dwMsgs; } }
        public override long MessagesReceived { get { return (long)_stats.inStats.dwMsgs; } }
        public override long ErrorsSent { get { return (long)_stats.outStats.dwErrors; } }
        public override long ErrorsReceived { get { return (long)_stats.inStats.dwErrors; } }
        public override long DestinationUnreachableMessagesSent
        {
            get
            {
                return _stats.outStats.rgdwTypeCount[(long)IcmpV6StatType.DestinationUnreachable];
            }
        }
        public override long DestinationUnreachableMessagesReceived
        {
            get
            {
                return _stats.inStats.rgdwTypeCount[(long)IcmpV6StatType.DestinationUnreachable];
            }
        }
        public override long PacketTooBigMessagesSent
        {
            get
            {
                return _stats.outStats.rgdwTypeCount[(long)IcmpV6StatType.PacketTooBig];
            }
        }
        public override long PacketTooBigMessagesReceived
        {
            get
            {
                return _stats.inStats.rgdwTypeCount[(long)IcmpV6StatType.PacketTooBig];
            }
        }
        public override long TimeExceededMessagesSent
        {
            get
            {
                return _stats.outStats.rgdwTypeCount[(long)IcmpV6StatType.TimeExceeded];
            }
        }
        public override long TimeExceededMessagesReceived
        {
            get
            {
                return _stats.inStats.rgdwTypeCount[(long)IcmpV6StatType.TimeExceeded];
            }
        }
        public override long ParameterProblemsSent
        {
            get
            {
                return _stats.outStats.rgdwTypeCount[(long)IcmpV6StatType.ParameterProblem];
            }
        }
        public override long ParameterProblemsReceived
        {
            get
            {
                return _stats.inStats.rgdwTypeCount[(long)IcmpV6StatType.ParameterProblem];
            }
        }
        public override long EchoRequestsSent
        {
            get
            {
                return _stats.outStats.rgdwTypeCount[(long)IcmpV6StatType.EchoRequest];
            }
        }
        public override long EchoRequestsReceived
        {
            get
            {
                return _stats.inStats.rgdwTypeCount[(long)IcmpV6StatType.EchoRequest];
            }
        }
        public override long EchoRepliesSent
        {
            get
            {
                return _stats.outStats.rgdwTypeCount[(long)IcmpV6StatType.EchoReply];
            }
        }
        public override long EchoRepliesReceived
        {
            get
            {
                return _stats.inStats.rgdwTypeCount[(long)IcmpV6StatType.EchoReply];
            }
        }
        public override long MembershipQueriesSent
        {
            get
            {
                return _stats.outStats.rgdwTypeCount[(long)IcmpV6StatType.MembershipQuery];
            }
        }
        public override long MembershipQueriesReceived
        {
            get
            {
                return _stats.inStats.rgdwTypeCount[(long)IcmpV6StatType.MembershipQuery];
            }
        }
        public override long MembershipReportsSent
        {
            get
            {
                return _stats.outStats.rgdwTypeCount[(long)IcmpV6StatType.MembershipReport];
            }
        }
        public override long MembershipReportsReceived
        {
            get
            {
                return _stats.inStats.rgdwTypeCount[(long)IcmpV6StatType.MembershipReport];
            }
        }
        public override long MembershipReductionsSent
        {
            get
            {
                return _stats.outStats.rgdwTypeCount[(long)IcmpV6StatType.MembershipReduction];
            }
        }
        public override long MembershipReductionsReceived
        {
            get
            {
                return _stats.inStats.rgdwTypeCount[(long)IcmpV6StatType.MembershipReduction];
            }
        }
        public override long RouterAdvertisementsSent
        {
            get
            {
                return _stats.outStats.rgdwTypeCount[(long)IcmpV6StatType.RouterAdvertisement];
            }
        }
        public override long RouterAdvertisementsReceived
        {
            get
            {
                return _stats.inStats.rgdwTypeCount[(long)IcmpV6StatType.RouterAdvertisement];
            }
        }
        public override long RouterSolicitsSent
        {
            get
            {
                return _stats.outStats.rgdwTypeCount[(long)IcmpV6StatType.RouterSolicit];
            }
        }
        public override long RouterSolicitsReceived
        {
            get
            {
                return _stats.inStats.rgdwTypeCount[(long)IcmpV6StatType.RouterSolicit];
            }
        }
        public override long NeighborAdvertisementsSent
        {
            get
            {
                return _stats.outStats.rgdwTypeCount[(long)IcmpV6StatType.NeighborAdvertisement];
            }
        }
        public override long NeighborAdvertisementsReceived
        {
            get
            {
                return _stats.inStats.rgdwTypeCount[(long)IcmpV6StatType.NeighborAdvertisement];
            }
        }
        public override long NeighborSolicitsSent
        {
            get
            {
                return _stats.outStats.rgdwTypeCount[(long)IcmpV6StatType.NeighborSolict];
            }
        }
        public override long NeighborSolicitsReceived
        {
            get
            {
                return _stats.inStats.rgdwTypeCount[(long)IcmpV6StatType.NeighborSolict];
            }
        }
        public override long RedirectsSent
        {
            get
            {
                return _stats.outStats.rgdwTypeCount[(long)IcmpV6StatType.Redirect];
            }
        }
        public override long RedirectsReceived
        {
            get
            {
                return _stats.inStats.rgdwTypeCount[(long)IcmpV6StatType.Redirect];
            }
        }
    }
}

