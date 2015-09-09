using System;
using UnityEngine;
using CRAG.InputSystem;
using CRAG.AchievementSystem;

namespace CRAG
{
    /// <summary>
    /// Исполнитель команд
    /// </summary>
    public class GameActor : MonoBehaviour
    {
        /// <summary>Камера, привязанная к персонажу</summary>
        public Camera cam;
        /// <summary>Префаб инстанцируемый при щелчке мышью</summary>
        public GameObject click;
        /// <summary>Коллайдер для поиска объектов для выхода на орбиту</summary>
        public SearchCollider searchSphere;
        /// <summary>Сила с которой толкается персонаж импульсом</summary>
        public float forceMagnitude;

        private Transform _transform;
        private Rigidbody _rigidbody;
        private RandomText _randomText;
        private bool _onOrbitState = false;

        void Start()
        {
            _transform = GetComponent<Transform>();
            _rigidbody = GetComponent<Rigidbody>();
        }

        /// <summary>
        /// Применяет к персонажу импульс, увеличивая его скорость
        /// </summary>
        public void Impulse()
        {
            RaycastHit hit;
            Vector3 forceDirection = CalculateForceDirection(out hit);
            Instantiate(click, hit.point, Quaternion.identity);
            _rigidbody.AddForce(forceDirection * forceMagnitude, ForceMode.Impulse);
        }

        /// <summary>
        /// Выход на орбиту планеты.
        /// </summary>
        public void EnterOrbit()
        {
            Collider detected = searchSphere.GetDetectedCollider();
            if (detected != null)
            {
                if (detected.name == "Comet")
                    AchievementManager.instance.UnlockAchievement(Achievements.RideTheComet);

                if (detected.name == "Pluton")
                    AchievementManager.instance.UnlockAchievement(Achievements.TakeInPluton);

                _randomText = detected.GetComponent<RandomText>();
                if (_randomText != null)
                    _randomText.OnDisplayText();

                _onOrbitState = true;

                _transform.parent = detected.transform;
            }
        }

        /// <summary>
        /// Сойти с текущей орбиты
        /// </summary>
        public void DescendFromOrbit()
        {
            _transform.parent = null;
            if (_randomText != null)
                _randomText.OffDisplayText();
            _randomText = null;
            _onOrbitState = false;
        }
        
        /// <summary>
        /// Рассчитывает напрвление силы импульса, исходя из положения курсора относительно персонажа
        /// </summary>
        /// <param name="hit">Возвращает информацию о рэйкасте</param>
        /// <returns>Нормализованный вектор от курсора к персонажу</returns>
        private Vector3 CalculateForceDirection(out RaycastHit hit)
        {
            Vector3 forceDirection = Vector3.zero;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, LayerMask.GetMask("Raycasting")))
            {
                forceDirection = _transform.position - hit.point;
                forceDirection.Normalize();
            }

            return forceDirection;
        }

        //Расчёт вектора скорости при движении по орбите
        void Update()
        {
            if (_onOrbitState)
            {
                Vector3 radius = _transform.parent.position - _transform.position;
                Vector3 tangent = new Vector3(-radius.z, 0, radius.x);
                _rigidbody.velocity = Vector3.Project(_rigidbody.velocity, tangent);
            }
        }
    }
}
