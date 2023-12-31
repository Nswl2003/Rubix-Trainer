using System;

namespace Rubix_Cube_Algorithm_Trainer
{
    // Static helper class to handle user input and displaying of menus
    public static class MenuHandler
    {
        // Begins user input loop, handles displaying the given menu and user input
        public static void StartHandling(Menu menu) {

            while (true) {
                DisplayMenu(menu);

                ConsoleKeyInfo key = Console.ReadKey(true); // 'true' Parameter ensures the pressed key is not displayed, which would cause overlaps onto the menus
                switch (key.Key) {
                    case ConsoleKey.Enter:
                        menu.InvokeItem();
                        break;

                    case ConsoleKey.UpArrow:    // Move to above option 
                        menu.MoveUp();
                        break;

                    case ConsoleKey.DownArrow:  // Move to below option
                        menu.MoveDown();
                        break;

                    case ConsoleKey.Escape:
                        return;
                }
            }
        }

        // Writes centred menu items and title to console
        public static void DisplayMenu(Menu menu) {
            string[] options = menu.GetItemNames();
            Console.Clear();

            // Draw Title
            if (menu.Title != "") {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                int x = GetCentredCursorX(menu.Title);
                int y = GetCentredCursorY(menu.NumItems, 0) - 3; // Offset Y to be above top menu option

                Console.SetCursorPosition(x, y);
                Console.WriteLine(menu.Title);
                Console.ResetColor();
            }

            // Draw Menu Options
            for (int i = 0; i < options.Length; i++) {
                if (options[i] == menu.GetSelected()) Console.ForegroundColor = ConsoleColor.Yellow; // If current option is same index as selected, highlight the text yellow

                string s = options[i];
                int x = GetCentredCursorX(s);
                int y = GetCentredCursorY(menu.NumItems, i);

                Console.SetCursorPosition(x, y);   // Set cursor position to centre
                Console.WriteLine(s);
                Console.ResetColor();   // Reset text colour
            }
        }

        // Calculates cursor X position for string 's' to be centred on console
        public static int GetCentredCursorX(string s) {
            return (Console.BufferWidth / 2) - (s.Length / 2);
        }

        // Calculates cursor X position for string 's' to be centred in a bounding area
        public static int GetCentredCursorX(string s, int boundX, int boundWidth) {
            return boundX + (boundWidth / 2) - (s.Length / 2);
        }

        // Calculates cursor Y position for menu option to be centred on console
        public static int GetCentredCursorY(int numMenuOptions, int currMenuOptionIndex) {
            return (Console.BufferHeight / 2) - (numMenuOptions / 2) + currMenuOptionIndex;
        }
    }
}
