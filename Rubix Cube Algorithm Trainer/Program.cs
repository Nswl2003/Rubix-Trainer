using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;

namespace Rubix_Cube_Algorithm_Trainer
{

    public static class Trainer
    {

        public static void Main(string[] args) {
            Console.Title = "Rubix Cube Algorithm Trainer";
            Console.CursorVisible = false;

            Menu mainMenu = new Menu("Rubix Cube Algorithm Trainer");
            Menu trainMenu = new Menu("Pick a Group");
            Menu reviseMenu = new Menu("Pick a Group");
            Menu settingsMenu = new Menu("Settings");

            reviseMenu.AddRange(
                ("All", () => Revise("All")),
                ("OLL", () => Revise("OLL")),
                ("PLL", () => Revise("PLL"))
                );
            trainMenu.AddRange(
                ("All", () => Train("All")),
                ("OLL", () => Train("OLL")),
                ("PLL", () => Train("PLL"))
                );
            mainMenu.AddRange(
                ("Train Algorithms", () => MenuHandler.StartHandling(trainMenu)),
                ("Revise Algorithms",  () => MenuHandler.StartHandling(reviseMenu)),
                ("Settings", () => MenuHandler.StartHandling(settingsMenu)),
                ("Quit", () => { Environment.Exit(0); } )
                );

            MenuHandler.StartHandling(mainMenu);
        }

        private static void Train(string group) {
            Dictionary<string, string> algsToTrain = Algorithms.GetAlgsFromGroup(group);
            StringBuilder input = new StringBuilder();
            Console.Clear();

            KeyValuePair<string, string> rndAlg = Algorithms.GetRandomAlg(algsToTrain);

            while (true) {
                Menu currAlgMenu = new Menu("Type the Algorithm");
                currAlgMenu.Add(rndAlg.Key, () => { });
                MenuHandler.DisplayMenu(currAlgMenu);
                Console.SetCursorPosition(MenuHandler.GetCentredCursorX(input.ToString()), MenuHandler.GetCentredCursorY(1, 2));
                Console.WriteLine(input.ToString());

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                switch (keyInfo.Key) {
                    case ConsoleKey.Escape:
                        return;

                    case ConsoleKey.Enter:
                        if (input.Replace(" ", string.Empty).ToString() == rndAlg.Value) Console.ForegroundColor = ConsoleColor.Green;
                        else Console.ForegroundColor = ConsoleColor.Red;

                        Console.SetCursorPosition(MenuHandler.GetCentredCursorX(rndAlg.Value), MenuHandler.GetCentredCursorY(1, 3));
                        Console.WriteLine(rndAlg.Value);

                        rndAlg = Algorithms.GetRandomAlg(algsToTrain);
                        input.Clear();
                        Console.ReadKey(true);
                        break;

                    case ConsoleKey.Backspace:
                        if (input.Length > 0) input.Remove(input.Length - 1, 1);
                        break;

                    default:
                        input.Append(keyInfo.KeyChar);
                        break;
                }
            }
        }

        private static void Revise(string group) {
            Dictionary<string, string> algsToRevise = Algorithms.GetAlgsFromGroup(group);
            Console.Clear();

            for (int i = 0; i < algsToRevise.Count; i++) {
                string name = algsToRevise.ElementAt(i).Key;
                string alg = algsToRevise.ElementAt(i).Value;
                int XOffset = i < Algorithms.TwoLookOLL.Count ? 0 : 60;

                Console.ForegroundColor = i % 2 == 0 ? ConsoleColor.Yellow : ConsoleColor.Cyan; // Alternate text colour for readability
                if (XOffset != 0) Console.SetCursorPosition(XOffset, i - Algorithms.TwoLookOLL.Count);
                Console.Write(name + ":");
                Console.CursorLeft = XOffset + 15; // Offset X to have consistent start point for algorithms
                Console.Write(alg + "\n");
            }

            Console.ReadKey(true);
        }

        private static void SettingsMenu() { }

    }
}
