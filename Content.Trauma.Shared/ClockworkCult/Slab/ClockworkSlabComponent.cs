// SPDX-License-Identifier: AGPL-3.0-or-later

using Robust.Shared.Containers;
using Robust.Shared.GameStates;
using Robust.Shared.Serialization;

namespace Content.Trauma.Shared.ClockworkCult.Slab;

/// <summary>
/// Holds scriptures and related data
/// </summary>
[RegisterComponent, NetworkedComponent]
[Access(typeof(ClockworkSlabSystem))]
public sealed partial class ClockworkSlabComponent : Component
{
}

[Serializable, NetSerializable]
public enum ClockworkSlabUiKey : byte
{
    Key
}
