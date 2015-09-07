using UnityEngine;
using System.Collections;

namespace CRAG
{
    /// <summary>
    /// Фабрика монеток. Создаёт монетки из префаба вокруг создателя.
    /// </summary>
    public class BonusCreator : MonoBehaviour
    {
        ///<summary>Префаб монетки</summary>
        public GameObject coin; 
        ///<summary>Расстояние от создателя</summary>
        public float radius = 1; 
        ///<summary>Количество монеток</summary>
        public int count = 5; 

        private Transform _transform;

        void Start()
        {
            _transform = GetComponent<Transform>();

            for (int i = 0; i < count; i++)
            {
                Transform instance = Instantiate(coin).GetComponent<Transform>();
                instance.parent = _transform;

                instance.localPosition = new Vector3(radius, 0, 0);
                float angle = 360f / count;
                Quaternion q = Quaternion.Euler(0, (float)i * angle, 0);
                instance.localPosition = q * instance.localPosition;
            }
        }
    }
}

