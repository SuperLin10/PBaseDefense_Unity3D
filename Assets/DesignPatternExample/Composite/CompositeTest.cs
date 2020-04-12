using UnityEngine;
using System.Collections;
using DesignPattern_Composite;

public class CompositeTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//UnitTest();	
		UnitTest2();
	}
	
	// 
	void UnitTest () {

		// 根节点
		IComponent theRoot = new Composite("Root");
		// 加入两个最终节点
		theRoot.Add ( new Leaf("Leaf1"));
		theRoot.Add ( new Leaf("Leaf2"));

		// 子节点1
		IComponent theChild1 = new Composite("Child1");
		// 加入两个最终节点
		theChild1.Add ( new Leaf("Child1.Leaf1"));
		theChild1.Add ( new Leaf("Child1.Leaf2"));
		theRoot.Add (theChild1);

		// 子节点2
		// 加入3个最终节点
		IComponent theChild2 = new Composite("Child2");
		theChild2.Add ( new Leaf("Child2.Leaf1"));
		theChild2.Add ( new Leaf("Child2.Leaf2"));
		theChild2.Add ( new Leaf("Child2.Leaf3"));
		theRoot.Add (theChild2);

		// 显示
		theRoot.Operation();	


	}

	void UnitTest2 () {
		
		// 根节点
		IComponent theRoot = new Composite("Root");

		// 产生一最终节点
		IComponent theLeaf1 = new Leaf("Leaf1");

		// 加入节点
		theLeaf1.Add ( new Leaf("Leaf2") );  // 错误

			
	}
}
