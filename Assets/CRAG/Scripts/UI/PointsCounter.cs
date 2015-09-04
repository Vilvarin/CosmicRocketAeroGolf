using UnityEngine;
using UnityEngine.UI;

namespace CRAG
{
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

