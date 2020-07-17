using System;
using UnityEngine;

// 游戏主循环
public class GameLoop : MonoBehaviour
{
    // 场景状态
    SceneStateController m_SceneStateController = new SceneStateController();

    // 
    void Awake()
    {
        // 切换场景不会被刪除
        GameObject.DontDestroyOnLoad(this.gameObject);

        // 设置伪随机数种子
        UnityEngine.Random.InitState((int)DateTime.Now.Ticks);
    }

    // Use this for initialization
    void Start()
    {
        // 设定起始的场景
        m_SceneStateController.SetState(new StartState(m_SceneStateController), "MainMenuScene");
    }

    // Update is called once per frame
    void Update()
    {
        m_SceneStateController.StateUpdate();
    }
}
