using System;
using UnityEngine;

namespace DefaultNamespace
{
    [Serializable]
    public class PlayerData
    {
        public delegate void ExperienceEvent(int currentXp);

        public event ExperienceEvent OnGainedXp;
        
        public delegate void LevelEvent(int newLevel);

        public event LevelEvent OnLevelUp;
        
        [SerializeField] private int currentHealth, maxHealth, currentExperience, maxExperience, currentLevel;

        public void AddXp(int delta)
        {
            currentExperience += delta;
            
            if (currentExperience >= maxExperience)
            {
                LevelUp();
            }
            
            OnGainedXp?.Invoke(currentExperience);
        }

        private void LevelUp()
        {
            maxHealth += 10;
            currentHealth = maxHealth;

            currentLevel++;

            currentExperience = 0;
            maxExperience += 100;
            
            OnLevelUp?.Invoke(currentLevel);
        }
    }
}