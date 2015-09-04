using UnityEngine;
using System.Collections;
using CRAG.AchievementSystem;

namespace CRAG
{
    public class Bonus : MonoBehaviour
    {
        public int points = 1;

        public static int countBonuses;

        void Start()
        {
            countBonuses++;
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.transform.name == "Player")
            {
                GameManager.instance.points++;
                Destroy(gameObject);
            }
        }

        void OnDestroy()
        {
            countBonuses--;
            if (countBonuses <= 0)
                AchievementManager.instance.UnlockAchievement(Achievements.CollectAllCoins);
        }
    }
}

