using UnityEngine;

namespace DesignPattern_Bridge
{
    // 定义作类别之共用界面
    public abstract class WindowImp
    {
        public abstract void DevDrawText(string Text);
        public abstract void DevDrawLine(string Line);
    }

    // 实作Implementor所订之界面
    public class XWindowImp : WindowImp
    {
        public XWindowImp() { }

        public override void DevDrawText(string Text)
        {
            Debug.Log("XWindowImp.DevDrawText:" + Text);
        }

        public override void DevDrawLine(string Line)
        {
            Debug.Log("XWindowImp.DevDrawLine:" + Line);
        }
    }

    // 实作Implementor所订之界面
    public class PMWindowImp : WindowImp
    {
        public PMWindowImp() { }

        public override void DevDrawText(string Text)
        {
            Debug.Log("PMWindowImp.DevDrawText:" + Text);
        }

        public override void DevDrawLine(string Line)
        {
            Debug.Log("PMWindowImp.DevDrawLine:" + Line);
        }
    }

    // 抽象体的界面,维护指向Implementor的物件 reference
    public abstract class Window
    {
        private WindowImp m_Imp = null;

        public void SetImplementor(WindowImp Imp)
        {
            m_Imp = Imp;
        }

        // 显示
        public abstract void Show();

        // 画字 
        protected void DrawText(string Text)
        {
            if (m_Imp != null)
                m_Imp.DevDrawText(Text);
        }

        // 画方块
        protected void DrawRect(string Text)
        {
            m_Imp.DevDrawLine(Text + " Top Line");
            m_Imp.DevDrawLine(Text + " Right Line");
            m_Imp.DevDrawLine(Text + " Bottom Line");
            m_Imp.DevDrawLine(Text + " Left Line");
        }

    }

    // 扩充Abstraction所订之界面
    public class IconWindow : Window
    {
        public IconWindow() { }

        public override void Show()
        {
            DrawRect("IconWindow");
            DrawText("IconWindow");
        }
    }

    // 扩充Abstraction所订之界面
    public class TransientWindow : Window
    {
        public TransientWindow() { }

        public override void Show()
        {
            DrawRect("TransientWindow");
        }
    }
}
