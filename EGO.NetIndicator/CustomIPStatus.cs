namespace EGO.NetIndicator
{
    public enum CustomIPStatus
    {
        None = -2,
        Unknown = -1,
        Success = 0,
        DestinationNetworkUnreachable = 11000 + 2,
        DestinationHostUnreachable = 11000 + 3,
        DestinationProhibited = 11000 + 4,
#pragma warning disable CA1069 // Enums values should not be duplicated
        DestinationProtocolUnreachable = 11000 + 4,
#pragma warning restore CA1069 // Enums values should not be duplicated
        DestinationPortUnreachable = 11000 + 5,
        NoResources = 11000 + 6,
        BadOption = 11000 + 7,
        HardwareError = 11000 + 8,
        PacketTooBig = 11000 + 9,
        TimedOut = 11000 + 10,
        BadRoute = 11000 + 12,
        TtlExpired = 11000 + 13,
        TtlReassemblyTimeExceeded = 11000 + 14,
        ParameterProblem = 11000 + 15,
        SourceQuench = 11000 + 16,
        BadDestination = 11000 + 18,
        DestinationUnreachable = 11000 + 40,
        TimeExceeded = 11000 + 41,
        BadHeader = 11000 + 42,
        UnrecognizedNextHeader = 11000 + 43,
        IcmpError = 11000 + 44,
        DestinationScopeMismatch = 11000 + 45
    }
}
