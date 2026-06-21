namespace DfoServer.Network
{
    public static class GameNetworkConfig
    {
        public const string ChannelName = "ch.11";

        public const string ServerIp = "127.0.0.1";

        public const int ChannelServerIndex = 1;

        public const int ChannelIndex = 11;

        public const int InitialUdpPort1 = 12311;

        public const int InitialUdpPort2 = 12312;

        public const int LoginChannelPort = 10128;

        public const int LoginUnknownPort = 17200;

        public const int CommandPacketCount = 1086;

        public const int NotificationPacketCount = 1036;
    }
}