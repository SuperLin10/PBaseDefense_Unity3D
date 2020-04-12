using DesignPattern_FactoryMethod;
using UnityEngine;

public class FactoryMethodTest : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        UnitTest();
    }

    void UnitTest()
    {

        // 产品
        Product theProduct = null;

        // 工厂界面
        Creator theCreator = null;

        // 设定为负责ProduceA的工厂
        theCreator = new ConcreteCreatorProductA();
        theProduct = theCreator.FactoryMethod();

        // 设定为负责ProduceB的工厂
        theCreator = new ConcreteCreatorProductB();
        theProduct = theCreator.FactoryMethod();

        // 工厂界面
        Creator_MethodType theCreatorMethodType = new ConcreteCreator_MethodType();

        // 取得两个产品
        theProduct = theCreatorMethodType.FactoryMethod(1);
        theProduct = theCreatorMethodType.FactoryMethod(2);

        // 使用Generic Method
        ConcreteCreator_GenericMethod theCreatorGM = new ConcreteCreator_GenericMethod();
        theProduct = theCreatorGM.FactoryMethod<ConcreteProductA>();
        theProduct = theCreatorGM.FactoryMethod<ConcreteProductB>();

        // 使用Generic Class
        // 负责ProduceA的工厂
        Creator_GenericClass<ConcreteProductA> Creator_ProductA = new Creator_GenericClass<ConcreteProductA>();
        theProduct = Creator_ProductA.FactoryMethod();

        // 负责ProduceA的工厂
        Creator_GenericClass<ConcreteProductB> Creator_ProductB = new Creator_GenericClass<ConcreteProductB>();
        theProduct = Creator_ProductB.FactoryMethod();
    }
}
