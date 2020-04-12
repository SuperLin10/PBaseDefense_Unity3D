using UnityEngine;

namespace DesignPattern_Bridge
{
    // 定义作类别之共用界面
    public abstract class Implementor
    {
        public abstract void OperationImp();
    }

    // 实作Implementor所订之界面
    public class ConcreteImplementor1 : Implementor
    {
        public ConcreteImplementor1() { }

        public override void OperationImp()
        {
            Debug.Log("执行Concrete1Implementor.OperationImp");
        }
    }

    // 实作Implementor所订之界面
    public class ConcreteImplementor2 : Implementor
    {
        public ConcreteImplementor2() { }

        public override void OperationImp()
        {
            Debug.Log("执行Concrete2Implementor.OperationImp");
        }
    }

    // 抽象体的界面,维护指向Implementor的物件 reference
    public abstract class Abstraction
    {
        private Implementor m_Imp = null;

        public void SetImplementor(Implementor Imp)
        {
            m_Imp = Imp;
        }

        public virtual void Operation()
        {
            if (m_Imp != null)
                m_Imp.OperationImp();
        }
    }

    // 扩充Abstraction所订之界面
    public class RefinedAbstraction1 : Abstraction
    {
        public RefinedAbstraction1() { }

        public override void Operation()
        {
            Debug.Log("物件RefinedAbstraction1");
            base.Operation();
        }
    }

    // 扩充Abstraction所订之界面
    public class RefinedAbstraction2 : Abstraction
    {
        public RefinedAbstraction2() { }

        public override void Operation()
        {
            Debug.Log("物件RefinedAbstraction2");
            base.Operation();
        }
    }
}
