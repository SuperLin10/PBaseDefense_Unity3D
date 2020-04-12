using UnityEngine;
using System.Collections;
using DesignPattern_Observer;

public class ObserverTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		UnitTest();
	}
	
	// Update is called once per frame
	void UnitTest () 
	{
		// 主题
		ConcreteSubject theSubject = new ConcreteSubject();

		// 加入观察者
		ConcreteObserver1 theObserver1 = new ConcreteObserver1(theSubject);
		theSubject.Attach( theObserver1 );
		theSubject.Attach( new ConcreteObserver2(theSubject) );

		// 设定Subject
		theSubject.SetState("Subject状态1");

		// 显示状态
		theObserver1.ShowState();	
	}
}
