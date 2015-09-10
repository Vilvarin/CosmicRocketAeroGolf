using UnityEngine;
using System.Collections;
using CRAG.AchievementSystem;

namespace CRAG
{
    /// <summary>
    /// Скрипт для монеток, добываемых игроком.
    /// </summary>
    public class Bonus : MonoBehaviour
    {
        /// <summary>Сколько очков даст этот бонус</summary>
        public int points = 1;

        /// <summary>Общее количество монеток</summary>
        public static int countBonuses;

        void Start()
        {
            countBonuses++;
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.transform.name == "Player")
            {
                GameManager.instance.CollectBonus(gameObject.name);
                GameManager.instance.points += points;
                
                countBonuses--;

                if (countBonuses <= 0)
                    AchievementManager.instance.UnlockAchievement(Achievements.CollectAllCoins);
                Destroy(gameObject);
            }
        }
    }
}

