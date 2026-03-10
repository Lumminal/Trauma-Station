using Content.Server.Antag;
using Content.Server.GameTicking.Rules;
using Content.Shared.NPC.Systems;
using Robust.Shared.Prototypes;

namespace Content.Trauma.Server.ClockworkCult.GameTicking;

public sealed class ClockworkCultRuleSystem : GameRuleSystem<ClockworkCultistRuleComponent>
{
    [Dependency] private readonly NpcFactionSystem _faction = default!;

    private static readonly EntProtoId NanotrasenFaction = "NanoTrasen";
    private static readonly EntProtoId ClockworkCultFaction = "ClockworkCult";

    /// <inheritdoc/>
    public override void Initialize()
    {
        base.Initialize();

        SubscribeLocalEvent<ClockworkCultistRuleComponent, AfterAntagEntitySelectedEvent>(AfterEntitySelected);
    }

    private void AfterEntitySelected(Entity<ClockworkCultistRuleComponent> ent, ref AfterAntagEntitySelectedEvent args)
    {
        _faction.RemoveFaction(ent.Owner, NanotrasenFaction);
        _faction.AddFaction(ent.Owner, ClockworkCultFaction);
    }
}
