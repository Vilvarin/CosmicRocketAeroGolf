using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using CRAG.AchievementSystem;

namespace CRAG
{
    /// <summary>
    /// Скрипт элемента UI для отображения ачивок.
    /// </summary>
    /// <remarks>Выведенный текст будет исчезать со временем</remarks>
    public class AchievementViewer : MonoBehaviour
    {
        /// <summary>Время за которое исчезнет текст</summary>
        public float timer = 10f;

        private Text _text;
        //Стартовый цвет берётся из компонента Текст
        private Color _startColor;
        //Конечный цвет отличается только альфа-каналом
        private Color _endColor;

        void Start()
        {
            _text = GetComponent<Text>();
            _startColor = _text.color;
            _endColor = new Color(_startColor.r, _startColor.g, _startColor.b, 0);
            AchievementManager.instance.achievementUnlockedAction += ViewAchievement;
        }

        private void ViewAchievement(object sender, AchievementEventArgs e)
        {
            _text.color = _startColor;
            _text.text = e.message;
            StartCoroutine("LerpColor");
        }

        private IEnumerator LerpColor()
        {
            float t = 0;
            while(t < timer)
            {
                _text.color = Color.Lerp(_startColor, _endColor, t/timer);
                t += Time.deltaTime;
                yield return null;
            }
        }

        void OnDestroy()
        {
            AchievementManager.instance.achievementUnlockedAction -= ViewAchievement;
        }
    }
}

