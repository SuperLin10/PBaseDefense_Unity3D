namespace MediatorWithoutPattern
{
    public class ISoldier
    {
    }

    // 兵营界面
    public class CampInfoUI
    {
        CampSystem m_CampSystem; // 兵营系统

        public void TrainSoldier(int SoldierID)
        {
            m_CampSystem.TrainSoldier(SoldierID);
        }
    }

    // 兵营系统
    public class CampSystem
    {
        APSystem m_ApSystem; // 行动力系统
        CharacterSystem m_CharacterSystem;// 角色管理系统

        // 训练战士
        public void TrainSoldier(int SoldierID)
        {
            //向行动力系统(APSystem)询问是否有足够的行动力可以生产，
            if (m_ApSystem.CheckTrainSoldier(SoldierID) == false)
                return;

            // 行动力系统(APSystem)回覆有足够的行动力之后，兵营系统(CampSystem)便执行产生战士功能
            ISoldier NewSoldier = CreateSoldier(SoldierID);
            if (NewSoldier == null)
                return;

            // 再通知行动力系统(APSystem)扣除行动力，
            m_ApSystem.DescAP(10);

            // 最后将产生的战士交由角色管理系统(CharacterSystem)管理：
            m_CharacterSystem.AddSoldier(NewSoldier);
        }

        // 执行
        private ISoldier CreateSoldier(int SoldierID)
        {
            return null;
        }

    }

    // 行动力系统
    public class APSystem
    {
        GameStateInfoUI m_StateInfoUI; // 游戏状态界面
        int m_AP;

        // 是否可以训练战士
        public bool CheckTrainSoldier(int SoldierID)
        {
            return true;
        }

        // 扣除AP
        public void DescAP(int Value)
        {
            m_AP -= Value;
            m_StateInfoUI.UpdateUI();
        }

        // 取得AP
        public int GetAP()
        {
            return m_AP;
        }

    }

    // 游戏状态界面
    public class GameStateInfoUI
    {
        APSystem m_ApSystem;    // 行动力系统

        // 更新界面
        public void UpdateUI()
        {
            int NowAP = m_ApSystem.GetAP();
        }
    }

    // 角色管理系统
    public class CharacterSystem
    {
        // 加入战士
        public void AddSoldier(ISoldier NewSoldier)
        {

        }
    }

    public class TestClass
    {
        /*CampInfoUI m_CampInfoUI;
        CampSystem m_CampSystem;
        APSystem m_ApSystem;
        GameStateInfoUI m_StateInfoUI;
        CharacterSystem m_CharacterSystem;

        // 设定缺
        public void SetCampInfo( CampSystem m_CampSystem ) 
        {
            m_CampSystem = pCampSystem;
        }*/

        public void CreateSoldier()
        {
            /*兵营界面(CampInfoUI)在接收到玩家指令之后，
            向兵营系统(CampSystem)通知要训练一員战士出场，
            兵营系统(CampSystem)接收到通知之后，
            向行动力系统(APSystem)询问是否有足够的行动力可以生产，行动力系统(APSystem)回覆有足够的行动力之后，兵营系统(CampSystem)便执行产生战士功能，再通知行动力系统(APSystem)扣除行动力，并通知游戏状态界面(GameStateInfoUI)显示目前的行动力，最后将产生的战士交由角色管理系统(CharacterSystem)管理：
            */

        }
    }
}

