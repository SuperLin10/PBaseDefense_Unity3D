using System.Collections.Generic;
using UnityEngine;

namespace DesignPattern_Builder
{
    // 欲产生的复杂物件 
    public class Product
    {
        private List<string> m_Part = new List<string>();
        public Product() { }
        public void AddPart(string Part)
        {
            m_Part.Add(Part);
        }
        public void ShowProduct()
        {
            Debug.Log("ShowProduct Functions:");
            foreach (string Part in m_Part)
                Debug.Log(Part);
        }
    }

    // 界面用来生成Product的各零件
    public abstract class Builder
    {
        public abstract void BuildPart1(Product theProduct);
        public abstract void BuildPart2(Product theProduct);
    }

    // Builder界面的具体实作A
    public class ConcreteBuilderA : Builder
    {
        public override void BuildPart1(Product theProduct)
        {
            theProduct.AddPart("ConcreteBuilderA_Part1");
        }
        public override void BuildPart2(Product theProduct)
        {
            theProduct.AddPart("ConcreteBuilderA_Part2");
        }
    }

    // Builder界面的具体实作B
    public class ConcreteBuilderB : Builder
    {
        public override void BuildPart1(Product theProduct)
        {
            theProduct.AddPart("ConcreteBuilderB_Part1");
        }
        public override void BuildPart2(Product theProduct)
        {
            theProduct.AddPart("ConcreteBuilderB_Part2");
        }
    }

    // 利用Builder界面来构建物件
    public class Director
    {
        private Product m_Product;

        public Director() { }

        // 建立 
        public void Construct(Builder theBuilder)
        {
            // 利用Builder产生各部份加入Product中
            m_Product = new Product();
            theBuilder.BuildPart1(m_Product);
            theBuilder.BuildPart2(m_Product);
        }

        // 取得成品
        public Product GetResult()
        {
            return m_Product;
        }
    }
}
