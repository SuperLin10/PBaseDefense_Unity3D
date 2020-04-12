using DesignPattern_Proxy;
using UnityEngine;

public class ProxyTest : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        UnitTest();
    }

    // 
    void UnitTest()
    {

        // 产生Proxy
        Proxy theProxy = new Proxy();

        // 透过Proxy存取
        theProxy.Request();
        theProxy.ConnectRemote = true;
        theProxy.Request();
    }
}
