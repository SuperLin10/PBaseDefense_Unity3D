using UnityEngine;

namespace AchievementSaveWithoutPattern
{
    // 成就系统
    public class AchievementSystem
    {
        // 记录的成就项目
        private int m_EnemyKilledCount = 0;
        private int m_SoldierKilledCount = 0;
        private int m_StageLv = 0;

        // 记录的成就项目
        public int GetEnemyKilledCount()
        {
            return m_EnemyKilledCount;
        }

        public int GetSoldierKilledCount()
        {
            return m_SoldierKilledCount;
        }

        public int GetStageLv()
        {
            return m_StageLv;
        }

        public void SetEnemyKilledCount(int iValue)
        {
            m_EnemyKilledCount = iValue;
        }

        public void SetSoldierKilledCount(int iValue)
        {
            m_SoldierKilledCount = iValue;
        }

        public void SetStageLv(int iValue)
        {
            m_StageLv = iValue;
        }

        public void SaveData()
        {
            AchievementSaveData.SaveData(this);
        }

        // 取回记录
        public void LoadData()
        {
            AchievementSaveData.LoadData(this);
        }
    }


    // 成就记录存档
    public static class AchievementSaveData
    {
        // 存档
        public static void SaveData(AchievementSystem theSystem)
        {
            PlayerPrefs.SetInt("EnemyKilledCount", theSystem.GetEnemyKilledCount());
            PlayerPrefs.SetInt("SoldierKilledCount", theSystem.GetSoldierKilledCount());
            PlayerPrefs.SetInt("StageLv", theSystem.GetStageLv());
        }

        // 取回
        public static void LoadData(AchievementSystem theSystem)
        {
            int tempValue = 0;
            tempValue = PlayerPrefs.GetInt("EnemyKilledCount", 0);
            theSystem.SetEnemyKilledCount(tempValue);

            tempValue = PlayerPrefs.GetInt("SoldierKilledCount", 0);
            theSystem.SetSoldierKilledCount(tempValue);

            tempValue = PlayerPrefs.GetInt("StageLv", 0);
            theSystem.SetStageLv(tempValue);
        }
    }
}
