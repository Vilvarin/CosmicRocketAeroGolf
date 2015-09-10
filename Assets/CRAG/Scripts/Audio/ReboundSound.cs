using UnityEngine;
using System.Collections;

namespace CRAG
{
    /// <summary>
    /// Скрипт для проигрывания звука при встрече с объектом
    /// </summary>
    public class ReboundSound : MonoBehaviour
    {
        private AudioClip _clip;
        private ClipPlayer _audio;

        void Start()
        {
            _clip = AudioStorage.instance.rebound;
            _audio = GetComponent<ClipPlayer>();
        }

        void OnCollisionEnter(Collision collision)
        {
            _audio.Play(_clip);
        }
    }
}

