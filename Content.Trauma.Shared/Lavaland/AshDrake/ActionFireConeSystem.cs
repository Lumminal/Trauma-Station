namespace Content.Trauma.Shared.Lavaland.AshDrake;

public sealed partial class DirectionalEntitySpawnSystem : EntitySystem
{
    [Dependency] private INetManager _net = default!;

    public override void Initialize()
    {
        base.Initialize();

        SubscribeLocalEvent<DirectionalEntitySpawnComponent, ActionDirectionEntitySpawnEvent>(OnAction);
    }

    private void OnAction(Entity<DirectionalEntitySpawnComponent> ent, ref ActionDirectionEntitySpawnEvent args)
    {
        if (_net.IsClient && !ent.Comp.Predicted)
            return;

        var performer = args.Performer;

        var xform = Transform(performer);
        var coords = xform.Coordinates;
        var cardinalDir = xform.LocalRotation.GetCardinalDir();

        switch (cardinalDir)
        {
            case Direction.North:
                PredictedSpawnAtPosition(ent.Comp.North, coords);
                break;
            case Direction.East:
                PredictedSpawnAtPosition(ent.Comp.East, coords);
                break;
            case Direction.South:
                PredictedSpawnAtPosition(ent.Comp.South, coords);
                break;
            case Direction.West:
                PredictedSpawnAtPosition(ent.Comp.West, coords);
                break;
        }
    }
}

