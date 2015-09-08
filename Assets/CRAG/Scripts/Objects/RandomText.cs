using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

namespace CRAG
{
    /// <summary>
    /// Скрипт для вывода случайного текста из списка.
    /// </summary>
    public class RandomText : MonoBehaviour
    {
        /// <summary>Набор текстов</summary>
        [TextArea]
        public List<string> texts;
        /// <summary>Объект для вывода</summary>
        public TextMesh view;

        /// <summary>
        /// Отобразить случайный текст
        /// </summary>
        public void OnDisplayText()
        {
            string text = texts[Random.Range(0, texts.Count)];
            view.text = text;
        }

        /// <summary>
        /// Очистить текстовую строку
        /// </summary>
        public void OffDisplayText()
        {
            view.text = "";
        }
    }
}

