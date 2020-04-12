using UnityEngine;

namespace AttrFactoryWithoutPattern
{
    public class SoldierAttr
    {
        public SoldierAttr()
        { }
        public SoldierAttr(int MaxHP, float MoveSpeed, string AttrName)
        { }
    }

    // Enemy数值
    public class EnemyAttr
    {
        public EnemyAttr()
        { }
        public EnemyAttr(int MaxHP, float MoveSpeed, int CritRate, string AttrName)
        { }
    }


    // 产生游戏用数值界面
    public abstract class IAttrFactory
    {
        // 取得Soldier的数值
        public abstract SoldierAttr GetSoldierAttr(int AttrID);
        //public abstract PrefixSoldierAttr GetPrefixSoldierAttr(int AttrID, SoldierAttr theSoldierAttr);
        //public abstract SuffixSoldierAttr GetSuffixSoldierAttr(int AttrID, SoldierAttr theSoldierAttr);

        // 取得Enemy的数值
        public abstract EnemyAttr GetEnemyAttr(int AttrID);

        // 取得武器的数值
        public abstract WeaponAttr GetWeaponAttr(int AttrID);

    }

    // 实作产生游戏用数值
    public class AttrFactory : IAttrFactory
    {
        public AttrFactory()
        { }

        // 取得Soldier的数值
        public override SoldierAttr GetSoldierAttr(int AttrID)
        {
            switch (AttrID)
            {
                case 1:
                    return new SoldierAttr(10, 3.0f, "新兵"); // 生命力,移动速度,数值名称
                case 2:
                    return new SoldierAttr(20, 3.2f, "中士");
                case 3:
                    return new SoldierAttr(30, 3.4f, "上尉");
                default:
                    Debug.LogWarning("沒有针对角色数值[" + AttrID + "]产生新的数值");
                    break;
            }
            return null;
        }

        // 取得Enemy的数值
        public override EnemyAttr GetEnemyAttr(int AttrID)
        {
            switch (AttrID)
            {
                case 1:
                    return new EnemyAttr(5, 3.0f, 5, "精灵"); // 生命力,移动速度,爆击率,数值名称
                case 2:
                    return new EnemyAttr(15, 3.1f, 10, "山妖");
                case 3:
                    return new EnemyAttr(20, 3.3f, 15, "怪物");
                default:
                    Debug.LogWarning("沒有针对角色数值[" + AttrID + "]产生新的数值");
                    break;
            }
            return null;
        }

        // 取得武器的数值
        public override WeaponAttr GetWeaponAttr(int AttrID)
        {
            switch (AttrID)
            {
                case 1:
                    return new WeaponAttr(2, 4, "短槍"); // 攻击力,攻击距離,数值名称
                case 2:
                    return new WeaponAttr(4, 7, "長槍");
                case 3:
                    return new WeaponAttr(8, 10, "火箭筒");
                default:
                    Debug.LogWarning("沒有针对角色数值[" + AttrID + "]产生新的数值");
                    break;
            }
            return null;
        }

    }


}
