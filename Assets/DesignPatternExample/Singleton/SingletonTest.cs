using DesignPattern_Singleton;
using UnityEngine;

public class SingletonTest : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        UnitTest();
        UnitTest_ClassWithCounter();
    }

    // 单例模式测试方法
    void UnitTest()
    {
        Singleton.Instance.Name = "Hello";
        Singleton.Instance.Name = "World";
        Debug.Log(Singleton.Instance.Name);

        //Singleton TempSingleton = new Singleton();
        // 错误  error CS0122: `DesignPattern_Singleton.Singleton.Singleton()' is inaccessible due to its protection level
    }

    // 有计数功能类别的测试方法
    void UnitTest_ClassWithCounter()
    {
        // 有计数功能的类别
        ClassWithCounter pObj1 = new ClassWithCounter();
        pObj1.Operator();

        ClassWithCounter pObj2 = new ClassWithCounter();
        pObj2.Operator();

        pObj1.Operator();
    }
}
