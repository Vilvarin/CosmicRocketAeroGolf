using System.Collections.Generic;
using UnityEngine;

namespace CRAG
{
    /// <summary>
    /// Скрипт поискового коллайдера
    /// </summary>
    /// <remarks>При входе объекта в триггер, ссылка на объект созраняется в списке.
    /// При выходе из триггера объект удаляется из списка.</remarks>
    public class SearchCollider : MonoBehaviour
    {
        /// <summary>Отметка для объектов, которые будут активировать триггер</summary>
        public string detectedTag = "detected";

        //Список для объектов, внутри триггера
        private List<Collider> _detected = new List<Collider>();

        void OnTriggerEnter(Collider other)
        {
            if (other.tag.Contains(detectedTag))
                _detected.Add(other);
        }

        void OnTriggerExit(Collider other)
        {
            if (other.tag.Contains(detectedTag))
                _detected.Remove(other);
        }

        /// <summary>
        /// Получить первый попавший в триггер объект
        /// </summary>
        /// <returns>Ссылку на коллайдер объекта</returns>
        public Collider GetDetectedCollider()
        {
            if (_detected.Count != 0)
                return _detected[0];
            else
                return null;
        }
    }
}
