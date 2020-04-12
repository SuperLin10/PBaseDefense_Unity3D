using UnityEngine;
using System.Collections;
using ShapeVisitor;

public class ShapeVisitorTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		UnitTest();	
	}
	
	// 
	void UnitTest () 
	{
		DirectX theDirectX = new DirectX();
		
		// 加入形状
		ShapeContainer theShapeContainer = new ShapeContainer();
		theShapeContainer.AddShape( new Cube(theDirectX) );
		theShapeContainer.AddShape( new Cylinder(theDirectX) );
		theShapeContainer.AddShape( new Sphere(theDirectX) );
		
		// 绘圆
		theShapeContainer.RunVisitor(new DrawVisitor());
		
		// 顶点数
		VectorCountVisitor theVectorCount = new VectorCountVisitor();
		theShapeContainer.RunVisitor( theVectorCount );
		Debug.Log("顶点数:"+ theVectorCount.Count );
		
		// 圆体积
		SphereVolumeVisitor theSphereVolume = new SphereVolumeVisitor();
		theShapeContainer.RunVisitor( theSphereVolume );
		Debug.Log("圆体积:"+ theSphereVolume.Volume );
	}
}
