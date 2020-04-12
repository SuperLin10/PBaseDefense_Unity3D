using UnityEngine;

namespace DesignPattern_Decorator
{
    // 制订可被Decorator动态增加权责的物件界面
    public abstract class Component
    {
        public abstract void Operator();
    }

    // 定义可被Decorator动态增加权责的物件
    public class ConcreteComponent : Component
    {
        public override void Operator()
        {
            Debug.Log("ConcreteComponent.Operator");
        }
    }

    // 持有指向Component的reference，須符合Component的界面
    public class Decorator : Component
    {
        Component m_Component;
        public Decorator(Component theComponent)
        {
            m_Component = theComponent;
        }

        public override void Operator()
        {
            m_Component.Operator();
        }
    }

    // 增加额外的权责/功能
    public class ConcreteDecoratorA : Decorator
    {
        Component m_Component;
        public ConcreteDecoratorA(Component theComponent) : base(theComponent)
        {
        }

        public override void Operator()
        {
            base.Operator();
            AddBehaivor();
        }

        private void AddBehaivor()
        {
            Debug.Log("ConcreteDecoratorA.AddBehaivor");
        }
    }

    // 增加额外的权责/功能
    public class ConcreteDecoratorB : Decorator
    {
        Component m_Component;
        public ConcreteDecoratorB(Component theComponent) : base(theComponent)
        {
        }

        public override void Operator()
        {
            AddBehaivor();
            base.Operator();
        }

        private void AddBehaivor()
        {
            Debug.Log("ConcreteDecoratorB.AddBehaivor");
        }
    }
}