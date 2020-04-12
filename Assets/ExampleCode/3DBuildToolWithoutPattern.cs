using UnityEngine;

// 302
namespace BuildToolWithoutPattern
{
    // DirectX引擎 
    public class DirectX
    {
        public void DXRender(string ObjName)
        {
            Debug.Log("DXRender:" + ObjName);
        }
    }

    // OpenGL引擎 
    public class OpenGL
    {
        public void GLRender(string ObjName)
        {
            Debug.Log("OpenGL:" + ObjName);
        }
    }


    // 圆球
    public abstract class ISphere
    {
        public abstract void Draw();
    }

    // 圆球使用Direct绘出
    public class SphereDX : ISphere
    {
        DirectX m_DirectX;

        public override void Draw()
        {
            m_DirectX.DXRender("Sphere");
        }
    }

    // 圆球使用Direct绘出
    public class SphereGL : ISphere
    {
        OpenGL m_OpenGL;

        public override void Draw()
        {
            m_OpenGL.GLRender("Sphere");
        }
    }

}
