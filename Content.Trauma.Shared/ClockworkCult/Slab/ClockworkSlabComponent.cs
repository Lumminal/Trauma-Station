using Robust.Shared.GameStates;
using Robust.Shared.Serialization;

namespace Content.Trauma.Shared.ClockworkCult.Slab;

/// <summary>
/// Holds data about the Clockwork Slab entity
/// </summary>
[RegisterComponent, NetworkedComponent]
public sealed partial class ClockworkSlabComponent : Component
{

}

[Serializable, NetSerializable]
public enum ClockworkSlabUiKey : byte
{
    Key
}
