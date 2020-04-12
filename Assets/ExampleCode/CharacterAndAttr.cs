using UnityEngine;

// 303
namespace CharacterAndValue
{
    // 武器类别
    public enum ENUM_Weapon
    {
        Null = 0,
        Gun = 1,
        Rifle = 2,
        Rocket = 3,
        Max,
    }

    // 武器界面
    public class Weapon
    {
        // 数值
        protected ENUM_Weapon m_emWeapon = ENUM_Weapon.Null;    // 类型
        protected int m_AtkValue = 0;       // 攻击力
        protected int m_AtkRange = 0;       // 攻击距离
        protected int m_AtkPlusValue = 0;   // 额外加乘值


        public Weapon(ENUM_Weapon Type, int AtkValue, int AtkRange)
        {
            m_emWeapon = Type;
            m_AtkValue = AtkValue;
            m_AtkRange = AtkRange;
        }

        public ENUM_Weapon GetWeaponType()
        {
            return m_emWeapon;
        }

        // 攻击目标
        public void Fire(ICharacter theTarget)
        {
        }

        // 设定额外攻击力
        public void SetAtkPlusValue(int AtkPlusValue)
        {
            m_AtkPlusValue = AtkPlusValue;
        }

        // 取得攻击力
        public int GetAtkValue()
        {
            return m_AtkValue + m_AtkPlusValue;
        }
    }

    // 角色类型
    public enum ENUM_Character
    {
        Soldier = 0,
        Enemy,
    }

    // 角色界面
    public class Character
    {
        // 拥有一笔武器
        protected Weapon m_Weapon = null;

        // 角色数值
        ENUM_Character m_CharacterType; // 角色类型
        int m_MaxHP = 0;            // 最高生命力值
        int m_NowHP = 0;            // 目前生命力值
        float m_MoveSpeed = 1.0f;   // 目前移动速度
        int m_SoldierLv = 0;    // Soldier等級
        int m_CritRate = 0;         // 爆击机率

        // 初始角色
        public void InitCharacter()
        {
            // 依角色类型判断是最高生命力的计算方式
            switch (m_CharacterType)
            {
                case ENUM_Character.Soldier:
                    // 最大生命力有等級加乘
                    if (m_SoldierLv > 0)
                        m_MaxHP += (m_SoldierLv - 1) * 2;
                    break;
                case ENUM_Character.Enemy:
                    // 不需要
                    break;
            }

            // 重设目前的生命力
            m_NowHP = m_MaxHP;
        }

        // 攻击目标
        public void Attack(ICharacter theTarget)
        {
            // 设定武器额外攻击加乘
            int AtkPlusValue = 0;

            // 依角色类型判断是否加乘额外攻击力
            switch (m_CharacterType)
            {
                case ENUM_Character.Soldier:
                    // 不需要
                    break;
                case ENUM_Character.Enemy:
                    // 依爆击机率回传攻击加乘值
                    int RandValue = UnityEngine.Random.Range(0, 100);
                    if (m_CritRate >= RandValue)
                        AtkPlusValue = m_MaxHP * 5; // 血量的5倍值
                    break;
            }

            // 设定额外攻击力
            m_Weapon.SetAtkPlusValue(AtkPlusValue);

            // 使用武器攻击目标
            m_Weapon.Fire(theTarget);
        }

        // 被攻击
        public void UnderAttack(ICharacter Attacker)
        {
            // 取得攻击力(会包含加乘值)
            int AtkValue = Attacker.GetWeapon().GetAtkValue();

            // 依角色类型计算减伤害值
            switch (m_CharacterType)
            {
                case ENUM_Character.Soldier:
                    // 会依照Soldier等級减少伤害
                    AtkValue -= (m_SoldierLv - 1) * 2;
                    break;
                case ENUM_Character.Enemy:
                    // 不需要
                    break;
            }

            // 目前生命力减去攻击值
            m_NowHP -= AtkValue;

            // 是否阵亡
            if (m_NowHP <= 0)
                Debug.Log("角色阵亡");
        }

        // 取得武器
        public Weapon GetWeapon()
        {
            return m_Weapon;
        }
    }
}
