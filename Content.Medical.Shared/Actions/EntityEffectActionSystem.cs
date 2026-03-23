using Content.Shared.Actions;
using Content.Shared.Actions.Events;
using Content.Shared.EntityEffects;

namespace Content.Medical.Shared.Actions;

public sealed class EntityEffectActionSystem : EntitySystem
{
    [Dependency] private readonly SharedEntityEffectsSystem _entityEffects = default!;

    public override void Initialize()
    {
        base.Initialize();

        SubscribeLocalEvent<EntityEffectActionComponent, ActionPerformedEvent>(OnPerformed);

        SubscribeLocalEvent<EntityEffectActionComponent, EntityTargetActionEvent>(OnTargetAction);
        SubscribeLocalEvent<EntityEffectActionComponent, WorldTargetActionEvent>(OnWorldTargetAction);
    }

    private void OnPerformed(Entity<EntityEffectActionComponent> ent, ref ActionPerformedEvent args)
    {
        if (ent.Comp.TargetUser)
        {
            _entityEffects.ApplyEffects(args.Performer, ent.Comp.UserEffects.ToArray(), user: args.Performer);
        }

        if (ent.Comp.TargetEntity is not { } target)
            return;

        _entityEffects.ApplyEffects(target, ent.Comp.TargetEffects.ToArray(), user: args.Performer);

        ent.Comp.TargetEntity = null;
        Dirty(ent);
    }

    private void OnTargetAction(Entity<EntityEffectActionComponent> ent, ref EntityTargetActionEvent args)
    {
        ent.Comp.TargetEntity = args.Target;
        Dirty(ent);
    }

    private void OnWorldTargetAction(Entity<EntityEffectActionComponent> ent, ref WorldTargetActionEvent args)
    {
        ent.Comp.TargetEntity = args.Entity;
        Dirty(ent);
    }
}

