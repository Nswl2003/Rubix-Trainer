using System;
using System.Collections.Generic;
using System.Linq;

namespace Rubix_Cube_Algorithm_Trainer
{
    // Static class storing all algorithms and helper methods for retrieving them
    public static class Algorithms
    {
        // key: NAME , value: ALGORITHM
        public static Dictionary<string, string> TwoLookOLL = new Dictionary<string, string>() {
            { "Dot", "FRUR'U'F'fRUR'U'f'" },
            { "I Shape", "FRUR'U'F'" },
            { "L Shape", "fRUR'U'f'"},
            { "Antisune", "RU2R'U'RU'R'" },
            { "H", "RUR'URU'R'URU2R'" },
            { "L", "FR'F'rURU'r'" },
            { "Pi", "RU2R2U'R2U'R2U2R" },
            { "Sune", "RUR'URU2R'"},
            { "T" , "rUR'U'r'FRF'" },
            { "U", "R2DR'U2RD'R'U2R'" }
    };
        public static Dictionary<string, string> TwoLookPLL = new Dictionary<string, string>() {
            { "Diagonal", "FRU'R'U'RUR'F'RUR'U'R'FRF'" },
            { "Headlights", "RUR'U'R'FR2U'R'U'RUR'F'" },
            { "PLL (H)", "M2UM2U2M2UM2"},
            { "PLL (Ua)", "RU'RURURU'R'U'R2" },
            { "PLL (Ub)", "R2URUR'U'R'U'R'UR'" },
            { "PLL (Z)", "M'UM2UM2UM'U2M2" },
    };
        public static Dictionary<string, string> AdvancedOLL = new Dictionary<string, string>();
        public static Dictionary<string, string> AdvancedPLL = new Dictionary<string, string>();

        // Returns all OLL & PLL algorithms at current level in 1 dictionary
        public static Dictionary<string, string> GetAllAlgorithms() {
            if (TrainerSettings.Level == "Beginner") return TwoLookOLL.Concat(TwoLookPLL).ToDictionary(kv => kv.Key, kv => kv.Value); // Beginner Algorithms
            else return AdvancedOLL.Concat(AdvancedPLL).ToDictionary(kv => kv.Key, kv => kv.Value); ;                                 // Advanced Algorithms
        }

        // Returns a random algorithm, chosen from the given set of algorithms
        public static KeyValuePair<string, string> GetRandomAlg(Dictionary<string, string> algs) {
            int randomIndex = new Random().Next(0, algs.Count);
            return algs.ElementAt(randomIndex);
        }

        // Returns the set of algorithms corresponding to the given group and level
        public static Dictionary<string, string> GetAlgsFromGroup(string group) {
            switch (group.ToUpper()) {
                case "OLL":
                    return TrainerSettings.Level == "Beginner" ? TwoLookOLL : AdvancedOLL;
                case "PLL":
                    return TrainerSettings.Level == "Beginner" ? TwoLookPLL : AdvancedPLL;
                default:
                    return GetAllAlgorithms();
            }
        }
    }
}
