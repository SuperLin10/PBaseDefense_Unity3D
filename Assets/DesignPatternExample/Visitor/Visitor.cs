using UnityEngine;
using System.Collections.Generic;

namespace DesignPattern_Visitor
{	
	// 固定的元素, 定义给Visitor存取的界面
	public abstract class Visitor
	{	
		// 可以写一个通用的函式名称但以用不同的参数来产生多样化方法
		public abstract void VisitConcreteElement( ConcreteElementA theElement);
		public abstract void VisitConcreteElement( ConcreteElementB theElement);


		// 或可以针对Element的子元件做不同的执行动作
		public abstract void VisitConcreteElementA( ConcreteElementA theElement);
		public abstract void VisitConcreteElementB( ConcreteElementB theElement);


	}

	// 制订以Visitor物件当参数的Accept()界面
	public abstract class Element
	{	
		public abstract void Accept( Visitor theVisitor);		
	}

	// 元素A 
	public class ConcreteElementA : Element
	{
		public override void Accept( Visitor theVisitor)
		{
			theVisitor.VisitConcreteElement( this );
			theVisitor.VisitConcreteElementA( this );
		}

		public void OperationA()
		{
			Debug.Log("ConcreteElementA.OperationA");
		}
	}
	
	// 元素B
	public class ConcreteElementB : Element
	{
		public override void Accept( Visitor theVisitor)
		{
			theVisitor.VisitConcreteElement( this );
			theVisitor.VisitConcreteElementB( this );
		}

		public void OperationB()
		{
			Debug.Log("ConcreteElementB.OperationB");
		}
	}
	
	// 实作功能操作Visitor1
	public class ConcreteVicitor1 : Visitor
	{
		// 可以写一个通用的函式名称但以用不同的参数来产生多样化方法
		public override void VisitConcreteElement( ConcreteElementA theElement)
		{
			Debug.Log ("ConcreteVicitor1:VisitConcreteElement(A)");
		}
		public override void VisitConcreteElement( ConcreteElementB theElement)
		{
			Debug.Log ("ConcreteVicitor1:VisitConcreteElement(B)");
		}

		public override void VisitConcreteElementA( ConcreteElementA theElement)
		{
			Debug.Log ("ConcreteVicitor1.VisitConcreteElementA()");
			theElement.OperationA();
		}

		public override void VisitConcreteElementB( ConcreteElementB theElement)
		{
			Debug.Log ("ConcreteVicitor1.VisitConcreteElementB()");
			theElement.OperationB();
		}
	}

	// 实作功能操作Visitor2
	public class ConcreteVicitor2 : Visitor
	{
		// 可以写一个通用的函式名称但以用不同的参数来产生多样化方法
		public override void VisitConcreteElement( ConcreteElementA theElement)
		{
			Debug.Log ("ConcreteVicitor2:VisitConcreteElement(A)");
		}
		public override void VisitConcreteElement( ConcreteElementB theElement)
		{
			Debug.Log ("ConcreteVicitor2.VisitConcreteElement(B)");
		}

		public override void VisitConcreteElementA( ConcreteElementA theElement)
		{
			Debug.Log ("ConcreteVicitor2.VisitConcreteElementA()");
			theElement.OperationA();
		}
		
		public override void VisitConcreteElementB( ConcreteElementB theElement)
		{
			Debug.Log ("ConcreteVicitor2.VisitConcreteElementB()");
			theElement.OperationB();
		}	
	}
		
	// 用来存储所有的Element	
	public class ObjectStructure
	{
		List<Element> m_Context = new List<Element>();
	
		public  ObjectStructure()
		{
			m_Context.Add( new ConcreteElementA());
			m_Context.Add( new ConcreteElementB());
		}
		
		// 载入不同的Action(Visitor)来判断
		public void RunVisitor(Visitor theVisitor)
		{
			foreach(Element theElement in m_Context )
				theElement.Accept( theVisitor);
		}
	}
	
}
