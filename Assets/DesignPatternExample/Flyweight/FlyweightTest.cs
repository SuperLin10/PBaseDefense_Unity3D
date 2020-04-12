using DesignPattern_Flyweight;
using UnityEngine;

public class FlyweightTest : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        UnitTest();
    }

    void UnitTest()
    {

        // 元件工厂
        FlyweightFactor theFactory = new FlyweightFactor();

        // 产生共用元件
        theFactory.GetFlyweight("1", "共用元件1");
        theFactory.GetFlyweight("2", "共用元件1");
        theFactory.GetFlyweight("3", "共用元件1");

        // 取得一个共用元件
        Flyweight theFlyweight = theFactory.GetFlyweight("1", "");
        theFlyweight.Operator();

        // 产生不共用的元件
        UnsharedCoincreteFlyweight theUnshared1 = theFactory.GetUnsharedFlyweight("不共用的信息1");
        theUnshared1.Operator();

        // 设定共用元件
        theUnshared1.SetFlyweight(theFlyweight);

        // 产生不共用的元件2,并指定使用共用元件１
        UnsharedCoincreteFlyweight theUnshared2 = theFactory.GetUnsharedFlyweight("1", "", "不共用的信息2");

        // 同时显示
        theUnshared1.Operator();
        theUnshared2.Operator();
    }
}
