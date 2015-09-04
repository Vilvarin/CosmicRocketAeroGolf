using UnityEngine;
using System.Collections;

namespace CRAG
{
    public class GameManager : MonoBehaviour {
        public static GameManager instance;

        [HideInInspector]
        public int points = 0;

        void Awake()
        {
            if (instance == null)
                instance = this;
            else if (instance != this)
                Destroy(gameObject);
        }

        void Start()
        {
            UIManager.instance.ShowStartPanel();
        }

        public void Win()
        {
            UIManager.instance.ShowWinPanel(points);
        }

        public void GameOver()
        {
            UIManager.instance.ShowGameOverPanel();
        }
    }
}

