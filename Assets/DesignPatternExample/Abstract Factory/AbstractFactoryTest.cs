using DesignPattern_AbstractFactory;
using UnityEngine;

public class AbstractFactoryTest : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        UnitTest();
    }

    // 测试抽象工厂
    void UnitTest()
    {
        AbstractFactory Factory = null;

        // 工厂1
        Factory = new ConcreateFactory1();
        // 产生两个产品
        Factory.CreateProductA();
        Factory.CreateProductB();

        // 工厂2
        Factory = new ConcreateFactory2();
        // 产生两个产品
        Factory.CreateProductA();
        Factory.CreateProductB();
    }

}
