using UnityEngine;

namespace NewRoleWithoutFactory
{
    // 角色界面
    public abstract class ICharacter
    {
        public string GetAssetName()
        {
            return "";
        }
        public void SetGameObject(GameObject obj)
        { }
        public void SetWeapon(IWeapon Weapon) { }
        public void SetCharacterAttr(SoldierAttr Attr) { }
        public void SetCharacterAttr(EnemyAttr Attr) { }
        public void SetAI(SoldierAI theAI) { }
        public void SetAI(EnemyAI theAI) { }

    }

    // Enemy角色界面
    public abstract class IEnemy : ICharacter
    {
    }
    public class EnemyElf : IEnemy
    {
    }
    public class EnemyOgre : IEnemy
    {
    }
    public class EnemyTroll : IEnemy
    {
    }

    // Soldier角色界面
    public abstract class ISoldier : ICharacter
    {
    }
    public class SoldierCaptain : ISoldier
    {
    }
    public class SoldierRookie : ISoldier
    {
    }
    public class SoldierSergeant : ISoldier
    {
    }

    // Soldier兵营
    public class SoldierCamp
    {
        public GameObject CreateGameObject(string Name) { return null; }
        public IWeapon CreateWeapon(ENUM_Weapon emType) { return null; }
        public SoldierAttr CreateSoliderAttr(int AttrID) { return null; }
        public SoldierAI CreateSoldierAI() { return null; }

        // 训练Rookie单位
        public ISoldier TrainRookie(ENUM_Weapon emWeapon, int Lv)
        {
            // 产生物件
            SoldierRookie theSoldier = new SoldierRookie();

            // 设定模型
            GameObject tmpGameObject = CreateGameObject("RookieGameObjectName");
            tmpGameObject.gameObject.name = "SoldierRookie";
            theSoldier.SetGameObject(tmpGameObject);

            // 加入武器
            IWeapon Weapon = CreateWeapon(emWeapon);
            theSoldier.SetWeapon(Weapon);

            // 取得Soldier的数值,设定给角色
            SoldierAttr theSoldierAttr = CreateSoliderAttr(1);
            theSoldierAttr.SetSoldierLv(Lv);
            theSoldier.SetCharacterAttr(theSoldierAttr);

            // 加入AI
            SoldierAI theAI = CreateSoldierAI();
            theSoldier.SetAI(theAI);

            // 加入管理器
            //PBaseDefenseGame.Instance.AddSoldier( theSoldier as ISoldier );

            return theSoldier as ISoldier;
        }

        // 训练Sergeant单位
        public ISoldier TrainSergeant(ENUM_Weapon emWeapon, int Lv)
        {
            // 产生物件
            SoldierSergeant theSoldier = new SoldierSergeant();

            // 设定模型
            GameObject tmpGameObject = CreateGameObject("SergeantGameObjectName");
            tmpGameObject.gameObject.name = "SoldierSergeant";
            theSoldier.SetGameObject(tmpGameObject);

            // 加入武器
            IWeapon Weapon = CreateWeapon(emWeapon);
            theSoldier.SetWeapon(Weapon);

            // 取得Soldier的数值,设定给角色
            SoldierAttr theSoldierAttr = CreateSoliderAttr(2);
            theSoldierAttr.SetSoldierLv(Lv);
            theSoldier.SetCharacterAttr(theSoldierAttr);

            // 加入AI
            SoldierAI theAI = CreateSoldierAI();
            theSoldier.SetAI(theAI);

            // 加入管理器
            //PBaseDefenseGame.Instance.AddSoldier( theSoldier as ISoldier );

            return theSoldier as ISoldier;
        }

        // 训练Caption单位
        public ISoldier TrainCaption(ENUM_Weapon emWeapon, int Lv)
        {
            // 产生物件
            SoldierCaptain theSoldier = new SoldierCaptain();

            // 设定模型
            GameObject tmpGameObject = CreateGameObject("CaptainGameObjectName");
            tmpGameObject.gameObject.name = "SoldierCaptain";
            theSoldier.SetGameObject(tmpGameObject);

            // 加入武器
            IWeapon Weapon = CreateWeapon(emWeapon);
            theSoldier.SetWeapon(Weapon);

            // 取得Soldier的数值,设定给角色
            SoldierAttr theSoldierAttr = CreateSoliderAttr(3);
            theSoldierAttr.SetSoldierLv(Lv);
            theSoldier.SetCharacterAttr(theSoldierAttr);

            // 加入AI
            SoldierAI theAI = CreateSoldierAI();
            theSoldier.SetAI(theAI);

            // 加入管理器
            //PBaseDefenseGame.Instance.AddSoldier( theSoldier as ISoldier );

            return theSoldier as ISoldier;
        }
    }



    // 关卡控制系统
    public class StageSystem
    {
        public GameObject CreateGameObject(string Name) { return null; }
        public IWeapon CreateWeapon(ENUM_Weapon emType) { return null; }
        public EnemyAttr CreateEnemyAttr(int AttrID) { return null; }
        public EnemyAI CreateEnemyAI() { return null; }


        // 加入Elf单位
        public IEnemy AddElf(ENUM_Weapon emWeapon)
        {
            // 产生物件
            EnemyElf theEnmey = new EnemyElf();

            // 设定模型
            GameObject tmpGameObject = CreateGameObject("ElfGameObjectName");
            tmpGameObject.gameObject.name = "EnemyElf";
            theEnmey.SetGameObject(tmpGameObject);

            // 加入武器
            IWeapon Weapon = CreateWeapon(emWeapon);
            theEnmey.SetWeapon(Weapon);

            // 取得Soldier的数值,设定给角色
            EnemyAttr theEnemyAttr = CreateEnemyAttr(1);
            theEnmey.SetCharacterAttr(theEnemyAttr);

            // 加入AI
            EnemyAI theAI = CreateEnemyAI();
            theEnmey.SetAI(theAI);

            // 加入管理器
            //PBaseDefenseGame.Instance.AddEnemy( theEnmey as IEnemy );

            return theEnmey as IEnemy;
        }

        // 加入Ogre单位
        public IEnemy AddOgre(ENUM_Weapon emWeapon)
        {
            // 产生物件
            EnemyOgre theEnmey = new EnemyOgre();

            // 设定模型
            GameObject tmpGameObject = CreateGameObject("OgreGameObjectName");
            tmpGameObject.gameObject.name = "EnemyOgre";
            theEnmey.SetGameObject(tmpGameObject);

            // 加入武器
            IWeapon Weapon = CreateWeapon(emWeapon);
            theEnmey.SetWeapon(Weapon);

            // 取得Soldier的数值,设定给角色
            EnemyAttr theEnemyAttr = CreateEnemyAttr(2);
            theEnmey.SetCharacterAttr(theEnemyAttr);

            // 加入AI
            EnemyAI theAI = CreateEnemyAI();
            theEnmey.SetAI(theAI);

            // 加入管理器
            //PBaseDefenseGame.Instance.AddEnemy( theEnmey as IEnemy );

            return theEnmey as IEnemy;
        }

        // 加入Troll单位
        public IEnemy AddTroll(ENUM_Weapon emWeapon)
        {
            // 产生物件
            EnemyTroll theEnmey = new EnemyTroll();

            // 设定模型
            GameObject tmpGameObject = CreateGameObject("TrollGameObjectName");
            tmpGameObject.gameObject.name = "EnemyTroll";
            theEnmey.SetGameObject(tmpGameObject);

            // 加入武器
            IWeapon Weapon = CreateWeapon(emWeapon);
            theEnmey.SetWeapon(Weapon);

            // 取得Soldier的数值,设定给角色
            EnemyAttr theEnemyAttr = CreateEnemyAttr(3);
            theEnmey.SetCharacterAttr(theEnemyAttr);

            // 加入AI
            EnemyAI theAI = CreateEnemyAI();
            theEnmey.SetAI(theAI);

            // 加入管理器
            //PBaseDefenseGame.Instance.AddEnemy( theEnmey as IEnemy );

            return theEnmey as IEnemy;
        }
    }
}
