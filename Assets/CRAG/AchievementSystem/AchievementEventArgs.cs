using System;

namespace CRAG.AchievementSystem
{
    /// <summary>
    /// Аргументы событий для системы ачивок
    /// </summary>
    public class AchievementEventArgs : EventArgs
    {
        public string message; ///<value>Сообщение выводимое при получении ачивки</value>
        public bool register; ///<value>Была ли разблокирована данная ачивка</value>

        public AchievementEventArgs(bool register, string message)
        {
            this.message  = message;
            this.register = register;
        }

        public AchievementEventArgs(string message)
        {
            this.register = false;
            this.message  = message;
        }
    }
}

