using UnityEngine;

namespace DesignPattern_Mediator
{
    // 用来管理Colleague物件的界面
    public abstract class Mediator
    {
        public abstract void SendMessage(Colleague theColleague, string Message);
    }

    // Mediator所控管的Colleague
    public abstract class Colleague
    {
        protected Mediator m_Mediator = null;
        public Colleague(Mediator theMediator)
        {
            m_Mediator = theMediator;
        }

        // Mediator通知请求
        public abstract void Request(string Message);

    }

    // 实作Colleague的类别1
    public class ConcreateColleague1 : Colleague
    {
        public ConcreateColleague1(Mediator theMediator) : base(theMediator)
        { }

        // 执行动作
        public void Action()
        {
            // 执行后需要通知其它Colleageu
            m_Mediator.SendMessage(this, "Colleage1发出通知");
        }

        // Mediator通知请求
        public override void Request(string Message)
        {
            Debug.Log("ConcreateColleague1.Request:" + Message);
        }
    }

    // 实作Colleague的类别2
    public class ConcreateColleague2 : Colleague
    {
        public ConcreateColleague2(Mediator theMediator) : base(theMediator)
        { }

        // 执行动作
        public void Action()
        {
            // 执行后需要通知其它Colleageu
            m_Mediator.SendMessage(this, "Colleage2发出通知");
        }

        // Mediator通知请求
        public override void Request(string Message)
        {
            Debug.Log("ConcreateColleague2.Request:" + Message);
        }
    }

    // 实作Mediator界面，并集合管理Colleague物件
    public class ConcreteMediator : Mediator
    {
        ConcreateColleague1 m_Colleague1 = null;
        ConcreateColleague2 m_Colleague2 = null;

        public void SetColleageu1(ConcreateColleague1 theColleague)
        {
            m_Colleague1 = theColleague;
        }

        public void SetColleageu2(ConcreateColleague2 theColleague)
        {
            m_Colleague2 = theColleague;
        }

        // 收到由Colleague通知请求
        public override void SendMessage(Colleague theColleague, string Message)
        {
            // 收到Colleague1通知Colleague2
            if (m_Colleague1 == theColleague)
            {
                m_Colleague2.Request(Message);
            }

            // 收到Colleague2通知Colleague1
            if (m_Colleague2 == theColleague)
            {
                m_Colleague1.Request(Message);
            }
        }
    }
}