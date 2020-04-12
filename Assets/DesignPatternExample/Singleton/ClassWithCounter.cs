using UnityEngine;

// 有计数功能的类别
public class ClassWithCounter
{
    protected static int m_ObjCounter = 0;
    protected bool m_bEnable = false;

    public ClassWithCounter()
    {
        m_ObjCounter++;
        m_bEnable = (m_ObjCounter == 1) ? true : false;

        if (m_bEnable == false)
        {
            Debug.LogError("目前物件数[" + m_ObjCounter + "]超过1个!!");
        }
    }

    public void Operator()
    {
        if (m_bEnable == false)
            return;
        Debug.Log("可以执行");
    }

}
