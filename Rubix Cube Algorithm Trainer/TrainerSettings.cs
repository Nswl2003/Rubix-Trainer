using System;

namespace Rubix_Cube_Algorithm_Trainer
{
    // Settings to use when training/revising algorithms
    public static class TrainerSettings
    {
        private static string _level = "Beginner";

        public static void SetLevel(string level) {
            if (level != "Beginner" || level != "Advanced") throw new Exception("String 'level' should be either 'Beginner' or 'Advanced'");
            _level = level;
        }

        public static string Level { get { return _level; } }
    }
}
