using DesignPattern_Prototype;
using UnityEngine;

public class PrototypeTest : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        UnitTest();
    }

    void UnitTest()
    {

        // 原始物件
        ConcretePrototype Obj = new ConcretePrototype();
        Obj.Name = "ConcreteObj1";

        // 复制物件
        ConcretePrototype CloneObj = Obj.Clone() as ConcretePrototype;

        // 显示
        Debug.Log("原始物件:" + Obj.Name);
        Debug.Log("复制物件:" + CloneObj.Name);
    }
}
