using UnityEngine;
namespace NewRoleWithFactory
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
        public int GetAttrID() { return 0; }


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


    public abstract class ICharacterFactory
    {
        // 建立Soldier
        public abstract ISoldier CreateSoldier(ENUM_Soldier emSoldier, ENUM_Weapon emWeapon, int Lv, Vector3 SpawnPosition);

        // 建立Enemy
        public abstract IEnemy CreateEnemy(ENUM_Enemy emEnemy, ENUM_Weapon emWeapon, Vector3 SpawnPosition, Vector3 AttackPosition);


        public GameObject CreateGameObject(string temp)
        {
            return null;
        }

        public IWeapon CreateWeapon(ENUM_Weapon emWeapon)
        {
            return null;
        }
        public SoldierAttr CreateSoliderAttr(int ID)
        {
            return null;
        }
        public SoldierAI CreateSoldierAI()
        {
            return null;
        }

        public EnemyAttr CreateEnemyAttr(int ID)
        {
            return null;
        }
        public EnemyAI CreateEnemyAI()
        {
            return null;
        }


    }



    // 产生游戏角色工厂
    public abstract class CharacterFactory : ICharacterFactory
    {
        // 建立Soldier
        public override ISoldier CreateSoldier(ENUM_Soldier emSoldier, ENUM_Weapon emWeapon, int Lv, Vector3 SpawnPosition)
        {
            // 产生对应的Character
            ICharacter theSoldier = null;
            switch (emSoldier)
            {
                case ENUM_Soldier.Rookie:
                    theSoldier = new SoldierRookie();
                    break;
                case ENUM_Soldier.Sergeant:
                    theSoldier = new SoldierSergeant();
                    break;
                case ENUM_Soldier.Captain:
                    theSoldier = new SoldierCaptain();
                    break;
                default:
                    Debug.LogWarning("CreateSoldier:无法建立[" + emSoldier + "]");
                    return null;
            }

            // 增加角色功能
            AddCharacterFuncs(theSoldier, emWeapon, Lv);

            // 加入管理器
            //PBaseDefenseGame.Instance.AddSoldier( theSoldier as ISoldier);				
            return theSoldier as ISoldier;
        }


        // 建立Enemy
        public override IEnemy CreateEnemy(ENUM_Enemy emEnemy, ENUM_Weapon emWeapon, Vector3 SpawnPosition, Vector3 AttackPosition)
        {

            // 产生对应的Character
            ICharacter theEnemy = null;
            switch (emEnemy)
            {
                case ENUM_Enemy.Elf:
                    theEnemy = new EnemyElf();
                    break;
                case ENUM_Enemy.Troll:
                    theEnemy = new EnemyTroll();
                    break;
                case ENUM_Enemy.Ogre:
                    theEnemy = new EnemyOgre();
                    break;
                default:
                    Debug.LogWarning("无法建立[" + emEnemy + "]");
                    return null;
            }

            // 增加角色功能
            AddCharacterFuncs(theEnemy, emWeapon, 0);

            // 加入管理器
            //PBaseDefenseGame.Instance.AddEnemy( theEnemy as IEnemy);		

            return theEnemy as IEnemy;
        }

        // 增加角色功能
        public void AddCharacterFuncs(ICharacter pRole, ENUM_Weapon emWeapon, int Lv)
        {
            // 显示的模式
            AddGameObject(pRole);
            // 设定武器
            AddWeapon(pRole, emWeapon);
            // 设定角色数值 
            AddAttr(pRole, Lv);
            // 设定角色AI
            AddAI(pRole);
        }

        // Template Method
        public abstract void AddGameObject(ICharacter pRole);
        public abstract void AddWeapon(ICharacter pRole, ENUM_Weapon emWeapon);
        public abstract void AddAttr(ICharacter pRole, int Lv);
        public abstract void AddAI(ICharacter pRole);


    }

    // 产生Soldier角色工厂
    public class SoldierFactory : CharacterFactory
    {
        public override IEnemy CreateEnemy(ENUM_Enemy emEnemy, ENUM_Weapon emWeapon, Vector3 SpawnPosition, Vector3 AttackPosition)
        {
            // 重宣告为空,防此错误呼
            Debug.LogWarning("SoldierFactory不應该产生IEnemy物件");
            return null;
        }

        // 加入3D成像
        public override void AddGameObject(ICharacter pRole)
        {
            // 设定模型
            GameObject tmpGameObject = CreateGameObject("CaptainGameObjectName");
            tmpGameObject.gameObject.name = "Soldier" + pRole.ToString();
            pRole.SetGameObject(tmpGameObject);
        }

        // 加入武器
        public override void AddWeapon(ICharacter pRole, ENUM_Weapon emWeapon)
        {
            // 加入武器
            IWeapon Weapon = CreateWeapon(emWeapon);
            pRole.SetWeapon(Weapon);
        }

        // 加入角色数值
        public override void AddAttr(ICharacter pRole, int Lv)
        {
            // 取得Soldier的数值,设定给角色
            SoldierAttr theSoldierAttr = CreateSoliderAttr(pRole.GetAttrID());
            theSoldierAttr.SetSoldierLv(Lv);
            pRole.SetCharacterAttr(theSoldierAttr);
        }

        // 加入角色AI
        public override void AddAI(ICharacter pRole)
        {
            // 加入AI
            SoldierAI theAI = CreateSoldierAI();
            pRole.SetAI(theAI);
        }
    }

    // 产生Enemy角色工厂
    public class EnemyFactory : CharacterFactory
    {
        // 建立Soldier
        public override ISoldier CreateSoldier(ENUM_Soldier emSoldier, ENUM_Weapon emWeapon, int Lv, Vector3 SpawnPosition)
        {
            // 重宣告为空,防此错误呼
            Debug.LogWarning("EnemyFactory不應该产生ISoldier物件");
            return null;
        }

        // 加入3D成像
        public override void AddGameObject(ICharacter pRole)
        {
            // 设定模型
            GameObject tmpGameObject = CreateGameObject("CaptainGameObjectName");
            tmpGameObject.gameObject.name = "Soldier" + pRole.ToString();
            pRole.SetGameObject(tmpGameObject);
        }

        // 加入武器
        public override void AddWeapon(ICharacter pRole, ENUM_Weapon emWeapon)
        {
            // 加入武器
            IWeapon Weapon = CreateWeapon(emWeapon);
            pRole.SetWeapon(Weapon);
        }

        // 加入角色数值
        public override void AddAttr(ICharacter pRole, int Lv)
        {
            // 取得Enemy的数值,设定给角色
            EnemyAttr theEnemyAttr = CreateEnemyAttr(pRole.GetAttrID());
            pRole.SetCharacterAttr(theEnemyAttr);
        }

        // 加入角色AI
        public override void AddAI(ICharacter pRole)
        {
            // 加入AI
            EnemyAI theAI = CreateEnemyAI();
            pRole.SetAI(theAI);
        }
    }
}
