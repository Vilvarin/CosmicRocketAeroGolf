using UnityEngine;
using System.Collections;

namespace CRAG
{
    /// <summary>
    /// Скрипт для объектов, уничтожающим при встрече только игрока
    /// </summary>
    public class DestroyerPlayer : MonoBehaviour
    {
        void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.name == "Player")
                GameManager.instance.GameOver();
        }
    }
}

