using UnityEngine;
using System.Collections;

namespace DesignPattern_State
{
	// 持有目前的状态,并将有关的信息传给状态
	public class Context
	{
		State	m_State = null;

		public void Request(int Value)
		{
			m_State.Handle(Value);
		}

		public void SetState(State theState )
		{
			Debug.Log ("Context.SetState:" + theState);
			m_State = theState;
		}
	}

	// 负责封装当Context处于特定状态时所该展現的行为
	public abstract class State
	{
		protected Context m_Context = null;

		public State(Context theContext)
		{
			m_Context = theContext;
		}			
		public abstract void Handle(int Value);
	}

	// 状态A
	public class ConcreteStateA : State
	{
		public ConcreteStateA( Context theContext):base(theContext)
		{}

		public override void Handle (int Value)
		{
			Debug.Log ("ConcreteStateA.Handle");
			if( Value > 10)
				m_Context.SetState( new ConcreteStateB(m_Context));
		}

	}

	// 状态B
	public class ConcreteStateB : State
	{
		public ConcreteStateB( Context theContext):base(theContext)
		{}
		
		public override void Handle (int Value)
		{
			Debug.Log ("ConcreteStateB.Handle");
			if( Value > 20)
				m_Context.SetState( new ConcreteStateC(m_Context));
		}
		
	}

	// 状态C
	public class ConcreteStateC : State
	{
		public ConcreteStateC( Context theContext):base(theContext)
		{}
		
		public override void Handle (int Value)
		{
			Debug.Log ("ConcreteStateC.Handle");
			if( Value > 30)
				m_Context.SetState( new ConcreteStateA(m_Context));
		}		
	}


}