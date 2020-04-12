namespace AchievementWithoutPattern
{

    // 成就事件
    public enum ENUM_GameEvent
    {
        Null = 0,
        EnemyKilled = 1,// 敌方单位阵亡
        SoldierKilled = 2,// 玩家单位阵亡
        SoldierUpgate = 3,// 玩家单位升級
        NewStage = 4,// 新关卡
    }

    // 成就系统
    public class AchievementSystem
    {
        // 记录的成就项目
        private int m_EnemyKilledCount = 0;
        private int m_SoldierKilledCount = 0;
        private int m_StageLv = 0;
        private bool m_KillOgreEquipRocket = false;

        // 通知游戏事件发生
        public void NotifyGameEvent(ENUM_GameEvent emGameEvent, System.Object Param1, System.Object Param2)
        {
            // 依游戏事件
            switch (emGameEvent)
            {
                case ENUM_GameEvent.EnemyKilled:    // 敌方单位阵亡
                    Notify_EnemyKilled(Param1 as IEnemy);
                    break;
                case ENUM_GameEvent.SoldierKilled:  // 玩家单位阵亡
                    Notify_SoldierKilled(Param1 as ISoldier);
                    break;
                case ENUM_GameEvent.SoldierUpgate:  // 玩家单位升級
                    Notify_SoldierUpgate(Param1 as ISoldier);
                    break;
                case ENUM_GameEvent.NewStage:       // 新关卡
                    Notify_NewStage((int)Param1);
                    break;
            }
        }

        // 敌方单位阵亡
        private void Notify_EnemyKilled(IEnemy theEnemy)
        {
            // 阵亡数增加
            m_EnemyKilledCount++;

            // 击倒装備Rocket 的Ogre
            if (theEnemy.GetEnemyType() == ENUM_Enemy.Ogre && theEnemy.GetWeapon().GetWeaponType() == ENUM_Weapon.Rocket)
                m_KillOgreEquipRocket = true;
        }

        // 玩家单位阵亡
        private void Notify_SoldierKilled(ISoldier theSoldier)
        {

        }

        // 玩家单位升級
        private void Notify_SoldierUpgate(ISoldier theSoldier)
        {

        }

        // 新关卡
        private void Notify_NewStage(int StageLv)
        {

        }

    }



}

