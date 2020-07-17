/// <summary>
/// 开始状态
/// </summary>
public class StartState : ISceneState
{
    public StartState(SceneStateController Controller) : base(Controller)
    {
        this.StateName = "StartState";
    }

    // 开始
    public override void StateBegin()
    {
        // 可在此进行游戏资料载入及初始...等
    }

    // 更新
    public override void StateUpdate()
    {
        // 更换为
        m_Controller.SetState(new MainMenuState(m_Controller), "MainMenuScene");
    }
}
