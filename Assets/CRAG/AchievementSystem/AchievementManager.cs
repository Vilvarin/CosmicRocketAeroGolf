using UnityEngine;
using System.Collections.Generic;
using System;

namespace CRAG.AchievementSystem
{
    /// <summary>
    /// Контроллер для системы ачивок. Хранит список всех ачивок и предоставляет доступ к их разблокировке.
    /// </summary>
    public class AchievementManager : MonoBehaviour
    {
        public static AchievementManager instance;

        public event EventHandler<AchievementEventArgs> achievementUnlockedAction = delegate { };

        /// <summary>
        /// Список ачивок.
        /// </summary>
        private Dictionary<Achievements, AchievementEventArgs> registeredAchievements =
            new Dictionary<Achievements, AchievementEventArgs>(3){
                {Achievements.CollectAllCoins, new AchievementEventArgs("Золотоискатель") },
                {Achievements.RideTheComet,    new AchievementEventArgs("Оседлать комету")},
                {Achievements.TakeInPluton,    new AchievementEventArgs("Новые горизонты")},
            };

        void Awake()
        {
            if (instance == null)
                instance = this;
            else if (instance != this)
                Destroy(gameObject);
        }

        /// <summary>
        /// Разблокирует ачивку, если ещё не разблокирована и сообщит о событии.
        /// </summary>
        /// <param name="achiev">Ачивка из перечисления</param>
        public void UnlockAchievement(Achievements achiev)
        {
            try
            {
                if (!registeredAchievements[achiev].register)
                {
                    registeredAchievements[achiev].register = true;
                    achievementUnlockedAction(this, registeredAchievements[achiev]);
                }
            }
            catch(KeyNotFoundException e)
            {
                Debug.LogError(e.Message);
            }
        }
    }
}

