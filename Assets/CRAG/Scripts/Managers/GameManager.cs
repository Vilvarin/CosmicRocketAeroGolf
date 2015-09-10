using UnityEngine;
using System.Collections;
using CRAG.InputSystem;

namespace CRAG
{
    /// <summary>
    /// Одиночка. Отвечает за начало и конец игры.
    /// </summary>
    /// <remarks>Единственная причина в том, что класс не статический,
    /// необходимость закинуть префаб с игроком, чтобы вовремя его уничтожать.</remarks>
    public class GameManager : MonoBehaviour {
        public static GameManager instance;

        /// <summary>Префаб персонажа</summary>
        public GameActor player;

        /// <summary>Бонусные очки, заработанный игроком</summary>
        [HideInInspector] public int points = 0;

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

        /// <summary>
        /// Вызвать для перезапуска уровня
        /// </summary>
        public void Restart()
        {
            Application.LoadLevel("Scene");
            UIManager.instance.ShowStartPanel();
        }

        /// <summary>
        /// Вызвать при победе
        /// </summary>
        public void Win()
        {
            InputHandler.instance.playerState = false;
            Destroy(player.gameObject);
            UIManager.instance.ShowWinPanel();
        }

        /// <summary>
        /// Вызвать при поражении
        /// </summary>
        public void GameOver()
        {
            InputHandler.instance.playerState = false;
            player.GetComponent<DestructurableObject>().Boom();
            Destroy(player.gameObject);
            UIManager.instance.ShowGameOverPanel();
        }
    }
}

