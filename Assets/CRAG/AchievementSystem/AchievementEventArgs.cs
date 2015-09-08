using System;

namespace CRAG.AchievementSystem
{
    /// <summary>
    /// Аргументы событий для системы ачивок
    /// </summary>
    public class AchievementEventArgs : EventArgs
    {
        /// <summary>Сообщение выводимое при получении ачивки</summary>
        public string message;
        /// <summary>Была ли разблокирована данная ачивка</summary>
        public bool register = false;

        /// <summary>
        /// Конструктор класса.
        /// </summary>
        /// <param name="register">Была ли разблокирована данная ачивка</param>
        /// <param name="message">Сообщение выводимое при получении ачивки</param>
        public AchievementEventArgs(bool register, string message)
        {
            this.message  = message;
            this.register = register;
        }

        /// <summary>
        /// Конструктор класса. Поле register по умолчанию false.
        /// </summary>
        /// <param name="message">Сообщение выводимое при получении ачивки</param>
        public AchievementEventArgs(string message)
        {
            this.register = false;
            this.message  = message;
        }
    }
}

