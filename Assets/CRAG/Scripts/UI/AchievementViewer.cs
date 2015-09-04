using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using CRAG.AchievementSystem;

namespace CRAG
{
    public class AchievementViewer : MonoBehaviour
    {
        public float timer = 10f;

        private Text _text;
        private Color _startColor;
        private Color _endColor;

        void Start()
        {
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
            while(t < 0)
            {
                _text.color = Color.Lerp(_startColor, _endColor, t/timer);
                t -= Time.deltaTime;
                yield return null;
            }
        }

        void OnDestroy()
        {
            AchievementManager.instance.achievementUnlockedAction -= ViewAchievement;
        }
    }
}

