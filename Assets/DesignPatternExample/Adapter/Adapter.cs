using UnityEngine;

namespace DesignPattern_Adapter
{
    // 应用领域(Client)所需的界面
    public abstract class Target
    {
        public abstract void Request();
    }

    // 不同于应用领域(Client)的实作,需要被转换
    public class Adaptee
    {
        public Adaptee() { }

        public void SpecificRequest()
        {
            Debug.Log("呼叫Adaptee.SpecificRequest");
        }
    }

    // 将Adaptee转换成Target界面
    public class Adapter : Target
    {
        private Adaptee m_Adaptee = new Adaptee();

        public Adapter() { }

        public override void Request()
        {
            m_Adaptee.SpecificRequest();
        }
    }
}
