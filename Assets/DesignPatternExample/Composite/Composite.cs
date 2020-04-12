using System.Collections.Generic;
using UnityEngine;

namespace DesignPattern_Composite
{
    // 复合体内含物件之界面
    public abstract class IComponent
    {
        protected string m_Value;
        public abstract void Operation();   // 一般操作
                                            // 加入节点
        public virtual void Add(IComponent theComponent)
        {
            Debug.LogWarning("子类别没实作");
        }
        // 移除节点
        public virtual void Remove(IComponent theComponent)
        {
            Debug.LogWarning("子类别没实作");
        }
        // 取得子节点
        public virtual IComponent GetChild(int Index)
        {
            Debug.LogWarning("子类别没实作");
            return null;
        }
    }

    // 代表复合结构之终端物件
    public class Leaf : IComponent
    {
        public Leaf(string Value)
        {
            m_Value = Value;
        }
        public override void Operation()
        {
            Debug.Log("Leaf[" + m_Value + "]执行Operation()");
        }
    }

    // 代表复合结构的节点之行为
    public class Composite : IComponent
    {
        List<IComponent> m_Childs = new List<IComponent>();

        public Composite(string Value)
        {
            m_Value = Value;
        }

        // 一般操作
        public override void Operation()
        {
            Debug.Log("Composite[" + m_Value + "]");
            foreach (IComponent theComponent in m_Childs)
                theComponent.Operation();
        }

        // 加入节点
        public override void Add(IComponent theComponent)
        {
            m_Childs.Add(theComponent);
        }

        // 移除节点
        public override void Remove(IComponent theComponent)
        {
            m_Childs.Remove(theComponent);
        }

        // 取得子节点
        public override IComponent GetChild(int Index)
        {
            return m_Childs[Index];
        }
    }
}
