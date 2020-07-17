using UnityEngine;
using UnityEngine.SceneManagement;

// 场景状态控制者
public class SceneStateController
{
    private ISceneState m_State; // 当前的状态
    private bool m_bRunBegin = false;
    AsyncOperation m_Async; // 场景加载的异步数据

    public SceneStateController()
    { }

    // 设定状态
    public void SetState(ISceneState State, string LoadSceneName)
    {
        //Debug.Log ("SetState:"+State.ToString());
        m_bRunBegin = false;

        // 载入场景
        LoadScene(LoadSceneName);

        // 通知前一个State结束
        if (m_State != null)
            m_State.StateEnd();

        // 设定
        m_State = State;
    }

    // 载入场景
    private void LoadScene(string LoadSceneName)
    {
        if (LoadSceneName == null || LoadSceneName.Length == 0)
        {
            return;
        }
        // 异步加载场景
        m_Async = SceneManager.LoadSceneAsync(LoadSceneName);
    }

    // 更新
    public void StateUpdate()
    {
        // 是否还在载入
        if (m_Async != null && m_Async.isDone)
        {
            m_Async = null;
            // 通知新的State开始
            if (m_State != null && m_bRunBegin == false)
            {
                m_State.StateBegin();
                m_bRunBegin = true;
            }

            if (m_State != null)
                m_State.StateUpdate();
        }
    }
}
