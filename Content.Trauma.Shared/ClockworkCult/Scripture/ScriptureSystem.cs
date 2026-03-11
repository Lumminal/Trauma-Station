using Content.Shared.Prototypes;
using Robust.Shared.Prototypes;

namespace Content.Trauma.Shared.ClockworkCult.Scripture;

/// <summary>
/// This handles the Scripture system.
/// A scripture is a <see cref="EntityPrototype"/> that holds another entity as a "produced result".
/// Scriptures can produce a result by getting recited via an entity with <see cref="ClockworkSlabComponent"/>.
/// A scripture can hold actions, structures, and other entities.
/// </summary>
public sealed class ScriptureSystem : EntitySystem
{
    [Dependency] private readonly IPrototypeManager _proto = default!;

    /// <summary>
    /// All entity prototypes with <see cref="ScriptureComponent"/>.
    /// </summary>
    [ViewVariables]
    public List<EntProtoId> AllScriptures = new();

    /// <inheritdoc/>
    public override void Initialize()
    {
        base.Initialize();

        SubscribeLocalEvent<PrototypesReloadedEventArgs>(OnPrototypesReloaded);

        LoadPrototypes();
    }

    private void OnPrototypesReloaded(PrototypesReloadedEventArgs args)
    {
        if (!args.WasModified<EntityPrototype>())
            return;

        LoadPrototypes();
    }

    private void LoadPrototypes()
    {
        AllScriptures.Clear();
        var scripture = Factory.GetComponentName<ScriptureComponent>();
        foreach (var proto in _proto.EnumeratePrototypes<EntityPrototype>())
        {
            if (!proto.Components.ContainsKey(scripture))
                return;

            var id = proto.ID;
            AllScriptures.Add(id);
        }
    }
}
