using UnityEngine;

namespace DesignPattern_Proxy
{
    // 制订RealSubject和Proxy所共用遵偱的界面
    public abstract class Subject
    {
        public abstract void Request();
    }

    // 定义Proxy所代表的真正物件
    public class RealSubject : Subject
    {
        public RealSubject() { }

        public override void Request()
        {
            Debug.Log("RealSubject.Request");
        }
    }

    // 持有指向RealSubject物件的reference以便存取真正的物件
    public class Proxy : Subject
    {
        RealSubject m_RealSubject = new RealSubject();

        // 权限控制
        public bool ConnectRemote { get; set; }

        public Proxy()
        {
            ConnectRemote = false;
        }

        public override void Request()
        {
            // 依目前状态決定是否存取RealSubject
            if (ConnectRemote)
                m_RealSubject.Request();
            else
                Debug.Log("Proxy.Request");
        }
    }
}
