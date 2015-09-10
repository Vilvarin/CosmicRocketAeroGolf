using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace CRAG
{
    /// <summary>
    /// Обёртка для удобного проигрывания одиночных звуков
    /// </summary>
    public class ClipPlayer : MonoBehaviour
    {
        /// <summary>Проигрыватель</summary>
        public AudioSource source;

        /// <summary>
        /// Проиграть одиночный звук
        /// </summary>
        /// <param name="clip">Проигрываемый клип</param>
        public void Play(AudioClip clip)
        {
            source.clip = clip;
            source.Play();
        }

        /// <summary>
        /// Проиграть случайный звук из массива
        /// </summary>
        /// <param name="clips">Массив со звуками</param>
        public void Play(AudioClip[] clips)
        {
            source.clip = clips[Random.Range(0, clips.Length-1)];
            source.Play();
        }
    }
}

