using DesignPattern_Bridge;
using UnityEngine;

public class BridgeTest : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        UnitTest();
        UnitTest_Window();
    }

    // 
    void UnitTest()
    {

        // 产生
        Abstraction theAbstraction = new RefinedAbstraction1();

        // 设定
        theAbstraction.SetImplementor(new ConcreteImplementor1());
        theAbstraction.Operation();

        // 设定
        theAbstraction.SetImplementor(new ConcreteImplementor2());
        theAbstraction.Operation();

        // 产生
        theAbstraction = new RefinedAbstraction2();

        // 设定
        theAbstraction.SetImplementor(new ConcreteImplementor1());
        theAbstraction.Operation();

        // 设定
        theAbstraction.SetImplementor(new ConcreteImplementor2());
        theAbstraction.Operation();
    }

    void UnitTest_Window()
    {
        Window pWindow = null;

        // 产生在XWindow环境下的IconWindow
        pWindow = new IconWindow();
        pWindow.SetImplementor(new XWindowImp());
        pWindow.Show();

        // 产生在PMWindow环境下的IconWindow
        pWindow = new IconWindow();
        pWindow.SetImplementor(new PMWindowImp());
        pWindow.Show();

        // 产生在XWindow环境下的TransientWindow
        pWindow = new TransientWindow();
        pWindow.SetImplementor(new XWindowImp());
        pWindow.Show();

        // 产生在PMWindow环境下的TransientWindow
        pWindow = new TransientWindow();
        pWindow.SetImplementor(new PMWindowImp());
        pWindow.Show();
    }
}
