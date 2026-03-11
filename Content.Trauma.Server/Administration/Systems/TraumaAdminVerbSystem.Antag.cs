// SPDX-License-Identifier: AGPL-3.0-or-later

using Content.Server.Antag;
using Content.Shared.Administration;
using Content.Shared.Database;
using Content.Shared.Mind.Components;
using Content.Shared.Verbs;
using Content.Trauma.Server.ClockworkCult.GameTicking;
using Robust.Shared.Player;
using Robust.Shared.Prototypes;
using Robust.Shared.Utility;

namespace Content.Trauma.Server.Administration.Systems;

public sealed partial class TraumaAdminVerbSystem
{
    [Dependency] private readonly AntagSelectionSystem _antag = default!;

    private static readonly EntProtoId ClockworkCult = "ClockworkCult";

    private void AddAntagVerbs(GetVerbsEvent<Verb> args)
    {
        if (!TryComp<ActorComponent>(args.User, out var actor))
            return;

        var player = actor.PlayerSession;

        if (!_adminManager.HasAdminFlag(player, AdminFlags.Fun))
            return;

        if (!HasComp<MindContainerComponent>(args.Target) || !TryComp<ActorComponent>(args.Target, out var targetActor))
            return;

        var targetPlayer = targetActor.PlayerSession;

        Verb clockworkCultist = new()
        {
            Text = Loc.GetString("admin-verb-text-clockwork-cultist"),
            Category = VerbCategory.Antag,
            Icon = new SpriteSpecifier.Rsi(new ResPath("/Textures/Interface/Misc/job_icons.rsi"), "Syndicate"),
            Act = () =>
            {
                _antag.ForceMakeAntag<ClockworkCultistRuleComponent>(targetPlayer, ClockworkCult);
            },
            Impact = LogImpact.High,
            Message = Loc.GetString("admin-verb-make-clockwork-cultist"),
        };
        args.Verbs.Add(clockworkCultist);
    }
}
