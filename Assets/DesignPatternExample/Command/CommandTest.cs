using DesignPattern_Command;
using UnityEngine;

public class CommandTest : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        UnitTest();
    }

    // 
    void UnitTest()
    {
        Invoker theInvoker = new Invoker();

        Command theCommand = null;
        // 将命令与执行结合
        theCommand = new ConcreteCommand1(new Receiver1(), "你好");
        theInvoker.AddCommand(theCommand);
        theCommand = new ConcreteCommand2(new Receiver2(), 999);
        theInvoker.AddCommand(theCommand);

        // 执行
        theInvoker.ExecuteCommand();
    }
}
