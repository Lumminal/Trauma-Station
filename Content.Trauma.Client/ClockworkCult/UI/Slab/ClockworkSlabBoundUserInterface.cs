namespace Content.Trauma.Client.ClockworkCult.UI.Slab;

public sealed class ClockworkSlabBoundUserInterface : BoundUserInterface
{
    [ViewVariables]
    private ClockWorkSlabWindow? _window;

    public ClockworkSlabBoundUserInterface(EntityUid owner, Enum uiKey) : base(owner, uiKey)
    {
    }

    protected override void Open()
    {
        base.Open();
        _window = new ClockWorkSlabWindow(this);
        _window.OnClose += Close;
        _window.OpenCenteredLeft();
    }
}
