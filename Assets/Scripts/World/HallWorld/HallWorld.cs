public class HallWorld: World
{
    public override void OnCreate()
    {
        base.OnCreate();
        UIModule.Instance.Initialize();
        UIModule.Instance.PopUpWindow<LoginWindow>();
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
    }

    public override void OnDestroy()
    {
        base.OnDestroy();
    }
}