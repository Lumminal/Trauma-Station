using Content.Shared.EntityEffects;
using Robust.Shared.GameStates;

namespace Content.Medical.Shared.Actions;

/// <summary>
/// Performs entity effects when an action is handled.
/// Make sure to put this on an entity with an <see cref="ActionComponent"/>.
/// </summary>
[RegisterComponent, NetworkedComponent]
[AutoGenerateComponentState]
public sealed partial class EntityEffectActionComponent : Component
{
    /// <summary>
    /// Whether to apply effects on the performer of the action.
    /// </summary>
    [DataField]
    public bool TargetUser;

    /// <summary>
    /// The list of effects to apply on the performer of the action,
    /// if <see cref="TargetUser"/> is set to true.
    /// </summary>
    [DataField]
    public List<EntityEffect> UserEffects = new();

    /// <summary>
    /// The list of effects to apply on the target
    /// </summary>
    [DataField]
    public List<EntityEffect> TargetEffects = new();

    /// <summary>
    /// The target entity that will be affected
    /// </summary>
    [AutoNetworkedField]
    public EntityUid? TargetEntity;
}
