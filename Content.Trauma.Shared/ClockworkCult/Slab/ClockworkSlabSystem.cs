// SPDX-License-Identifier: AGPL-3.0-or-later

using Content.Shared.Interaction.Events;
using Content.Trauma.Shared.ClockworkCult.Scripture;
using Robust.Shared.Containers;

namespace Content.Trauma.Shared.ClockworkCult.Slab;

/// <summary>
/// Handles UI messages, and functions unique to the Clockwork Slab
/// </summary>
public sealed class ClockworkSlabSystem : EntitySystem
{
    [Dependency] private readonly ScriptureSystem _scripture = default!;

    /// <inheritdoc/>
    public override void Initialize()
    {
        base.Initialize();

        SubscribeLocalEvent<ClockworkSlabComponent, MapInitEvent>(OnMapInit);
    }

    private void OnMapInit(Entity<ClockworkSlabComponent> ent, ref MapInitEvent args)
    {
        // Add all scripture prototypes that are available
        foreach (var scripture in _scripture.AllScriptures)
        {
            _scripture.TryAddScripture(ent.Owner, scripture);
        }
    }

}
