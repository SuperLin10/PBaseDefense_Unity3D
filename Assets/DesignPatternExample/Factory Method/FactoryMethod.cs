using UnityEngine;

namespace DesignPattern_FactoryMethod
{
    // 成品物件类型
    public abstract class Product
    {
    }

    // 成品物件类型A
    public class ConcreteProductA : Product
    {
        public ConcreteProductA()
        {
            Debug.Log("生成物件类型A");
        }
    }

    // 成品物件类型B
    public class ConcreteProductB : Product
    {
        public ConcreteProductB()
        {
            Debug.Log("生成物件类型B");
        }
    }

    // 宣告factory , 子类別会回传对应的Product型別之物件
    public abstract class Creator
    {
        public abstract Product FactoryMethod();
    }

    // 产生ProductA的工厂
    public class ConcreteCreatorProductA : Creator
    {
        public ConcreteCreatorProductA()
        {
            Debug.Log("产生工厂:ConcreteCreatorProductA");
        }

        public override Product FactoryMethod()
        {
            return new ConcreteProductA();
        }
    }

    // 产生ProductB的工厂
    public class ConcreteCreatorProductB : Creator
    {
        public ConcreteCreatorProductB()
        {
            Debug.Log("产生工厂:ConcreteCreatorProductB");
        }
        public override Product FactoryMethod()
        {
            return new ConcreteProductB();
        }
    }

    // 宣告factory method，它会依参数Type的提示回传对应Product类别物件
    public abstract class Creator_MethodType
    {
        public abstract Product FactoryMethod(int Type);
    }

    // 覆写factory method，以回传Product型別之物件
    public class ConcreteCreator_MethodType : Creator_MethodType
    {
        public ConcreteCreator_MethodType()
        {
            Debug.Log("产生工厂:ConcreteCreator_MethodType");
        }

        public override Product FactoryMethod(int Type)
        {
            switch (Type)
            {
                case 1:
                    return new ConcreteProductA();
                case 2:
                    return new ConcreteProductB();
            }
            Debug.Log("Type[" + Type + "]无法产生物件");
            return null;
        }
    }

    // 宣告factory method界箅,并使用Generic定义方法
    interface Creator_GenericMethod
    {
        Product FactoryMethod<T>() where T : Product, new();
    }

    // 覆写factory method，以回传Product型別之物件
    public class ConcreteCreator_GenericMethod : Creator_GenericMethod
    {
        public ConcreteCreator_GenericMethod()
        {
            Debug.Log("产生工厂:ConcreteCreator_GenericMethod");
        }

        public Product FactoryMethod<T>() where T : Product, new()
        {
            return new T();
        }
    }

    // 宣告Generic factory类别
    public class Creator_GenericClass<T> where T : Product, new()
    {
        public Creator_GenericClass()
        {
            Debug.Log("产生工厂:Creator_GenericClass<" + typeof(T).ToString() + ">");
        }

        public Product FactoryMethod()
        {
            return new T();
        }
    }
}