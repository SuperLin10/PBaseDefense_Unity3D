using UnityEngine;

// 302
namespace CharacterAndWeapon
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

        // 显示子彈特效
        public void ShowBulletEffect(Vector3 TargetPosition, float LineWidth, float DisplayTime)
        {
        }

        // 显示槍口特效 
        public void ShowShootEffect()
        {
        }

        // 显示音效
        public void ShowSoundEffect(string ClipName)
        {
        }
    }


    // 角色界面
    public abstract class ICharacter
    {
        // 拥有一笔武器
        protected Weapon m_Weapon = null;

        // 攻击目标
        public abstract void Attack(ICharacter theTarget);

        // 被攻击
        public abstract void UnderAttack(ICharacter theTarget);

        // 取得位置
        public Vector3 GetPosition()
        {
            return Vector3.zero;
        }
    }

    // Enemy角色界面
    public class IEnemy : ICharacter
    {
        public IEnemy()
        { }

        // 攻击目标
        public override void Attack(ICharacter theTarget)
        {
            // 发射特效
            m_Weapon.ShowShootEffect();
            int AtkPlusValue = 0;

            // 依目前武器決定攻击方式
            switch (m_Weapon.GetWeaponType())
            {
                case ENUM_Weapon.Gun:

                    // 显示武器特效及音效
                    m_Weapon.ShowBulletEffect(theTarget.GetPosition(), 0.03f, 0.2f);
                    m_Weapon.ShowSoundEffect("GunShot");

                    // 有机率增加额外加乘
                    AtkPlusValue = GetAtkPlusValue(5, 20);

                    break;
                case ENUM_Weapon.Rifle:
                    // 显示武器特效及音效
                    m_Weapon.ShowBulletEffect(theTarget.GetPosition(), 0.5f, 0.2f);
                    m_Weapon.ShowSoundEffect("RifleShot");

                    // 有机率增加额外加乘
                    AtkPlusValue = GetAtkPlusValue(10, 25);

                    break;
                case ENUM_Weapon.Rocket:
                    // 显示武器特效及音效
                    m_Weapon.ShowBulletEffect(theTarget.GetPosition(), 0.8f, 0.5f);
                    m_Weapon.ShowSoundEffect("RocketShot");

                    // 有机率增加额外加乘
                    AtkPlusValue = GetAtkPlusValue(15, 30);

                    break;
            }

            // 设定额外加乘值
            m_Weapon.SetAtkPlusValue(AtkPlusValue);

            // 攻击
            m_Weapon.Fire(theTarget);
        }

        // 取得额外的加乘值
        private int GetAtkPlusValue(int Rate, int AtkValue)
        {
            int RandValue = UnityEngine.Random.Range(0, 100);
            if (Rate > RandValue)
                return AtkValue;
            return 0;
        }

        // 被攻击
        public override void UnderAttack(ICharacter Target)
        {
        }
    }


    // Soldier角色界面
    public class ISoldier : ICharacter
    {
        public ISoldier()
        { }

        // 攻击目标
        public override void Attack(ICharacter theTarget)
        {
            // 发射特效
            m_Weapon.ShowShootEffect();

            // 依目前武器決定攻击方式
            switch (m_Weapon.GetWeaponType())
            {
                case ENUM_Weapon.Gun:
                    // 显示武器特效及音效
                    m_Weapon.ShowBulletEffect(theTarget.GetPosition(), 0.03f, 0.2f);
                    m_Weapon.ShowSoundEffect("GunShot");
                    break;
                case ENUM_Weapon.Rifle:
                    // 显示武器特效及音效
                    m_Weapon.ShowBulletEffect(theTarget.GetPosition(), 0.5f, 0.2f);
                    m_Weapon.ShowSoundEffect("RifleShot");
                    break;
                case ENUM_Weapon.Rocket:
                    // 显示武器特效及音效
                    m_Weapon.ShowBulletEffect(theTarget.GetPosition(), 0.8f, 0.5f);
                    m_Weapon.ShowSoundEffect("RocketShot");
                    break;
            }

            // 攻击
            m_Weapon.Fire(theTarget);
        }

        // 被攻击
        public override void UnderAttack(ICharacter Target)
        {
        }
    }
}
