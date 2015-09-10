using UnityEngine;
using System.Collections;
using CRAG.InputSystem;

namespace CRAG
{
    /// <summary>
    /// Одиночка. Отвечает за начало и конец игры. И случайно за звуки.
    /// </summary>
    public class GameManager : MonoBehaviour {
        public static GameManager instance;

        /// <summary>Префаб персонажа</summary>
        public GameActor player;

        /// <summary>Бонусные очки, заработанный игроком</summary>
        [HideInInspector] public int points = 0;

        private ClipPlayer _audio;

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
            _audio = GetComponent<ClipPlayer>();
            AchievementSystem.AchievementManager.instance.achievementUnlockedAction += PlayAchievementClip;
        }

        private void PlayAchievementClip(object sender, AchievementSystem.AchievementEventArgs e)
        {
            _audio.Play(AudioStorage.instance.achievement);
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
            _audio.Play(AudioStorage.instance.fanfare);
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
            _audio.Play(AudioStorage.instance.destroyPlayer);
        }

        /// <summary>
        /// Вызвать при сборе бонуса.
        /// Проигрывает звук.
        /// </summary>
        /// <param name="name">Имя собранного бонуса</param>
        public void CollectBonus(string name)
        {
            switch (name)
            {
                case "Monet(Clone)":
                    _audio.Play(AudioStorage.instance.coins);
                    break;
                case "UFO":
                    _audio.Play(AudioStorage.instance.ufo);
                    break;
            }
        }

        void OnDestroy()
        {
            AchievementSystem.AchievementManager.instance.achievementUnlockedAction -= PlayAchievementClip;
        }
    }
}

