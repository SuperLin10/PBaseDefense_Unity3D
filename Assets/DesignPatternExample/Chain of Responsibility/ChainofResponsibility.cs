﻿using UnityEngine;

namespace DesignPattern_ChainofResponsibility
{
    // 处理信息的界面
    public abstract class Handler
    {
        protected Handler m_NextHandler = null;

        public Handler(Handler theNextHandler)
        {
            m_NextHandler = theNextHandler;
        }

        public virtual void HandleRequest(int Cost)
        {
            if (m_NextHandler != null)
            {
                m_NextHandler.HandleRequest(Cost);
            }
        }
    }

    // 处理所负责的信息1
    public class ConcreteHandler1 : Handler
    {
        private int m_CostCheck = 10;

        public ConcreteHandler1(Handler theNextHandler) : base(theNextHandler)
        { }

        public override void HandleRequest(int Cost)
        {
            if (Cost <= m_CostCheck)
            {
                Debug.Log("ConcreteHandler1.核准");
            }
            else
            {
                base.HandleRequest(Cost);
            }
        }
    }

    // 处理所负责的信息2
    public class ConcreteHandler2 : Handler
    {
        private int m_CostCheck = 20;

        public ConcreteHandler2(Handler theNextHandler) : base(theNextHandler)
        { }

        public override void HandleRequest(int Cost)
        {
            if (Cost <= m_CostCheck)
            {
                Debug.Log("ConcreteHandler2.核准");
            }
            else
            {
                base.HandleRequest(Cost);
            }
        }
    }

    // 处理所负责的信息3
    public class ConcreteHandler3 : Handler
    {
        public ConcreteHandler3(Handler theNextHandler) : base(theNextHandler)
        { }
        public override void HandleRequest(int Cost)
        {
            Debug.Log("ConcreteHandler3.核准");
        }
    }
}
