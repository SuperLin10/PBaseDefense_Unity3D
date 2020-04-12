using UnityEngine;
using System.Collections;

namespace DesignPattern_TemplateMethod
{
	// 定义完整演算法各步骤及执行顺序
	public abstract class AbstractClass
	{
		public void TemplateMethod()
		{
			PrimitiveOperation1();
			PrimitiveOperation2();
		}
		protected abstract void PrimitiveOperation1();
		protected abstract void PrimitiveOperation2();
	}

	// 实作演算法各步骤
	public class ConcreteClassA : AbstractClass
	{
		protected override void PrimitiveOperation1()
		{
			Debug.Log("ConcreteClassA.PrimitiveOperation1");
		}
		protected override void PrimitiveOperation2()
		{
			Debug.Log("ConcreteClassA.PrimitiveOperation2");
		}
	}
	
	// 实作演算法各步骤
	public class ConcreteClassB : AbstractClass
	{
		protected override void PrimitiveOperation1()
		{
			Debug.Log("ConcreteClassB.PrimitiveOperation1");
		}
		protected override void PrimitiveOperation2()
		{
			Debug.Log("ConcreteClassB.PrimitiveOperation2");
		}
	}
		
}
