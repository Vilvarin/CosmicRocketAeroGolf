using UnityEngine;
using System.Collections;

namespace CRAG
{
    /// <summary>
    /// Фабрика комет. Выпускает по одной комете через заданное время.
    /// Комета летит по параболе. Фабрика задаёт ей начальную скорость и отрицательное ускорение. Остальное дело физического движка.
    /// 
    /// </summary>
    public class CometCreator : MonoBehaviour
    {
        /// <summary>Префаб кометы </summary>
        public GameObject comet;
        /// <summary>Коэффициент для оси X</summary>
        public float XFactor = -12;
        /// <summary>Коэффициент для оси Z</summary>
        public float ZFactor = 4.6f;
        /// <summary>Время между запусками</summary>
        public float timer = 20;

        void Start()
        {
            StartCoroutine("Wait");
        }

        IEnumerator Wait()
        {
            while (true)
            {
                yield return new WaitForSeconds(timer);
                LaunchComet();
            }
        }

        void LaunchComet()
        {
            GameObject instance = Instantiate(comet, transform.position, Quaternion.identity) as GameObject;

            Rigidbody instComet = instance.GetComponent<Rigidbody>();
            //инстанцированной комете задаётся начальная скорость. Квадрат коэффициента Z делает параболу достаточно крутой.
            instComet.velocity = new Vector3(XFactor, 0, 2 * ZFactor * ZFactor);
            ConstantForce force = instance.GetComponent<ConstantForce>();
            force.force = new Vector3(0, 0, -ZFactor);
        }
    }
}

