using System;
using System.Collections.Generic;
using System.Linq;

namespace Rubix_Cube_Algorithm_Trainer
{
    // Struct grouping data and methods to represent a menu on console
    public struct Menu
    {
        private string title; // Title of menu
        private Dictionary<string, Action> items; // Menu items
        private int currIndex; // Current selected option index

        public Menu(string title = "") {
            this.title = title;
            items = new Dictionary<string, Action>();
            currIndex = 0;
        }

        // Select next item in menu
        public void MoveDown() {
            currIndex = currIndex + 1 > NumItems - 1 ? 0 : currIndex + 1;
        }

        // Select previous item in menu
        public void MoveUp() {
            currIndex = currIndex - 1 < 0 ? NumItems - 1 : currIndex - 1;
        }

        // Get name of current selected item
        public string GetSelected() {
            return items.ElementAt(currIndex).Key;
        }

        // Get string names of all items
        public string[] GetItemNames() {
            return items.Keys.ToArray();
        }

        // Invoke function of the currently selected menu item
        public void InvokeItem() {
            items.ElementAt(currIndex).Value();
        }

        // Add an item to the menu
        public void Add(string name, Action func) {
            items.Add(name, func);
        }

        // Add multiple items to the menu
        public void AddRange(params (string name, Action func)[] menuItems) {
            foreach ((string n, Action f) in menuItems) items.Add(n, f);
        }

        // Remove an item from the menu
        public void Remove(string itemName) {
            items.Remove(itemName);
        }

        public override string ToString() {
            string result = "";
            string[] itemNames = GetItemNames();

            foreach (string s in itemNames) result += s + "\n";
            return result;
        }

        public string Title { get { return title; } }
        public Dictionary<string, Action> Items { get { return items; } }
        public int NumItems { get { return items.Count; } }
    }

}
