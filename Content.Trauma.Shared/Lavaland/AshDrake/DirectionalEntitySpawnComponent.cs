using Content.Shared.Actions;

namespace Content.Trauma.Shared.Lavaland.AshDrake;

/// <summary>
/// Spawns entities on top of an entity, different one depending on their cardinal direction
/// </summary>
[RegisterComponent, NetworkedComponent]
public sealed partial class DirectionalEntitySpawnComponent : Component
{
    /// <summary>
    /// The entity to spawn in north direction.
    /// </summary>
    [DataField]
    public EntProtoId? North;

    /// <summary>
    /// The entity to spawn in east direction.
    /// </summary>
    [DataField]
    public EntProtoId? East;

    /// <summary>
    /// The entity to spawn in west direction.
    /// </summary>
    [DataField]
    public EntProtoId? West;

    /// <summary>
    /// The entity to spawn in south direction.
    /// </summary>
    [DataField]
    public EntProtoId? South;

    /// <summary>
    /// Whether to predict the spawning
    /// </summary>
    [DataField]
    public bool Predicted = true;
}

public sealed partial class ActionDirectionEntitySpawnEvent : InstantActionEvent;
