namespace CharacterAndPrefixBaseAttr
{

    // 角色数值界面
    public abstract class ICharacterAttr
    {
        protected BaseAttr m_BaseAttr = null;   // 基本角色数值
        protected BaseAttr m_PrefixAttr = null; // 字首
        protected BaseAttr m_SuffixAttr = null; // 字尾

        // 设定字首
        public void SetPrefixAttr(BaseAttr PrefixAttr)
        {
            m_PrefixAttr = PrefixAttr;
        }

        // 设定字尾
        public void SetSuffixAttr(BaseAttr SuffixAttr)
        {
            m_SuffixAttr = SuffixAttr;
        }

        // 最大HP
        public int GetMaxHP()
        {
            // 字首
            int MaxHP = 0;
            if (m_PrefixAttr != null)
                MaxHP += m_PrefixAttr.GetMaxHP();

            MaxHP += m_BaseAttr.GetMaxHP();

            // 字尾
            if (m_SuffixAttr != null)
                MaxHP += m_SuffixAttr.GetMaxHP();

            return MaxHP;
        }

        // 移动速度
        public float GetMoveSpeed()
        {
            // 字首
            float MoveSpeed = 0;
            if (m_PrefixAttr != null)
                MoveSpeed += m_PrefixAttr.GetMoveSpeed();

            MoveSpeed += m_BaseAttr.GetMoveSpeed();

            // 字尾
            if (m_SuffixAttr != null)
                MoveSpeed += m_SuffixAttr.GetMoveSpeed();

            return MoveSpeed;
        }

        // 取得数值名称
        public string GetAttrName()
        {
            // 字首
            string AttrName = "";
            if (m_PrefixAttr != null)
                AttrName += m_PrefixAttr.GetAttrName();

            AttrName += m_BaseAttr.GetAttrName();

            // 字尾
            if (m_SuffixAttr != null)
                AttrName += m_SuffixAttr.GetAttrName();

            return AttrName;
        }
    }
}
