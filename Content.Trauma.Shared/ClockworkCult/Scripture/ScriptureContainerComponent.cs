// SPDX-License-Identifier: AGPL-3.0-or-later

using Robust.Shared.Containers;
using Robust.Shared.GameStates;

namespace Content.Trauma.Shared.ClockworkCult.Scripture;

/// <summary>
/// A container to hold scriptures on an entity
/// </summary>
[RegisterComponent, NetworkedComponent]
[Access(typeof(ScriptureSystem))]
public sealed partial class ScriptureContainerComponent : Component
{
    public const string ContainerId = "scriptures";

    [ViewVariables]
    public Container? Scriptures;
}
