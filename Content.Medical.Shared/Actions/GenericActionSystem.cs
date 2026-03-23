using Content.Shared.Actions;

namespace Content.Medical.Shared.Actions;

/// <summary>
/// A generic system that automatically handles some generic action events.
/// </summary>
public sealed class GenericActionSystem : EntitySystem
{
    /// <inheritdoc/>
    public override void Initialize()
    {
        base.Initialize();

        SubscribeLocalEvent<InstantActionHandledEvent>(OnInstantAction);
        SubscribeLocalEvent<TargetActionHandledEvent>(OnTargetAction);
        SubscribeLocalEvent<WorldTargetActionEvent>(OnWorldTargetAction);
    }

    private void OnInstantAction(InstantActionEvent args)
    {
        args.Handled = true;
    }

    private void OnTargetAction(EntityTargetActionEvent args)
    {
        args.Handled = true;
    }

    private void OnWorldTargetAction(WorldTargetActionEvent args)
    {
        args.Handled = true;
    }
}

#region Generic Action Events
/// <summary>
/// A generic instant action event that gets automatically handled.
/// </summary>
public sealed partial class InstantActionHandledEvent : InstantActionEvent;

/// <summary>
/// A generic target action event that gets automatically handled.
/// </summary>
public sealed partial class TargetActionHandledEvent : EntityTargetActionEvent;

/// <summary>
/// A generic world target action event that gets automatically handled.
/// </summary>
public sealed partial class WorldTargetActionHandledEvent : WorldTargetActionEvent;
#endregion
