using UnityEngine;
using UnityEngine.UI;

namespace CRAG
{
    /// <summary>
    /// Скрипт элемента UI для отображения очков
    /// </summary>
    public class PointsCounter : MonoBehaviour
    {
        private Text text;

        void Start()
        {
            text = GetComponent<Text>();
        }

        void OnGUI()
        {
            text.text = "Points: " + GameManager.instance.points;
        }
    }
}

