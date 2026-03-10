using Content.Server.Administration.Managers;
using Content.Shared.Verbs;

namespace Content.Trauma.Server.Administration.Systems;

public sealed partial class TraumaAdminVerbSystem : EntitySystem
{
    [Dependency] private readonly IAdminManager _adminManager = default!;

    public override void Initialize()
    {
        base.Initialize();

        SubscribeLocalEvent<GetVerbsEvent<Verb>>(GetVerbs);
    }

    private void GetVerbs(GetVerbsEvent<Verb> ev)
    {
        AddAntagVerbs(ev);
    }
}
