using System;

namespace CRAG.AchievementSystem
{
    public class AchievementEventArgs : EventArgs
    {
        public string message;
        public bool register;

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

