using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace CRAG
{
    /// <summary>
    /// Одиночка. управляет модальными окнами интерфейса.
    /// </summary>
    public class UIManager : MonoBehaviour
    {
        public static UIManager instance;

        /// <summary>Модальное окно с сообщением</summary>
        public GameObject panel;
        /// <summary>Текстовы элемент с сообщением</summary>
        public Text panelText;

        /// <summary>Состояние при котором можно закрыть окно</summary>
        private bool _canClosePanel = true;

        void Awake()
        {
            if(instance == null)
                instance = this;
            else if(instance != this)
                Destroy(gameObject);
        }

        /// <summary>
        /// Отобразить стартовое окно
        /// </summary>
        public void ShowStartPanel()
        {
            _canClosePanel = true;
            panel.SetActive(true);
            panelText.text = "<i>r</i> - рестарт \n" +
                             "<i>esc</i> - выход \n" +
                             "<i>Щелчок левой кнопки мыши</i> - импульс \n" +
                             "<i>Зажать правую кнопку мыши</i> - выйти на орбиту планеты \n" +
                             "<i>Пробел</i> - скрыть этот текст \n\n" +
                             "<b>Попробуй добраться до чёрной дыры, опасайся астероидов и солнца, собирай монетки и попробуй добыть ачивки.</b>";
        }

        /// <summary>
        /// Отобразить окно с количеством очков. Не закрывается.
        /// </summary>
        public void ShowWinPanel()
        {
            _canClosePanel = false;
            panel.SetActive(true);
            panelText.text = "You win with " + GameManager.instance.points + " points!";
        }

        /// <summary>
        /// Отобразить окно при поражении. Не закрывается.
        /// </summary>
        public void ShowGameOverPanel()
        {
            _canClosePanel = false;
            panel.SetActive(true);
            panelText.text = "Game Over";
        }

        /// <summary>
        /// Закрыть текущую панель
        /// </summary>
        public void ClosePanel()
        {
            if(_canClosePanel)
                panel.SetActive(false);
        }
    }
}

