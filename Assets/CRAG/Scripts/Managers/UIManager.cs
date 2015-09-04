using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace CRAG
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager instance;

        public GameObject panel;
        public Text panelText;

        void Awake()
        {
            if(instance == null)
                instance = this;
            else if(instance != this)
                Destroy(gameObject);
        }

        public void ShowStartPanel()
        {
            panel.SetActive(true);
            panelText.text = "<i>r</i> - рестарт /n" +
                             "<i>esc</i> - выход /n" +
                             "<i>Щелчок левой кнопки мыши</i> - импульс /n" +
                             "<i>Зажать правую кнопку мыши</i> - выйти на орбиту планеты /n" +
                             "<i>Пробел</i> - скрыть этот текст /n/n" +
                             "<b>Попробуй добраться до чёрной дыры, опасайся астероидов и солнца, собирай монетки и попробуй добыть ачивки.</b>";
        }

        public void ShowWinPanel(int points)
        {
            panel.SetActive(true);
            panelText.text = "You win with " + points + " points!";
        }

        public void ShowGameOverPanel()
        {
            panel.SetActive(true);
            panelText.text = "Game Over";
        }

        public void CloseStartPanel()
        {
            panel.SetActive(false);
        }

        public void CloseWinPanel()
        {
            panel.SetActive(false);
        }

        public void CloseGameOverPanel()
        {
            panel.SetActive(false);
        }
    }
}

