using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace App1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private static List<string> allMyTodos = new List<string>();

        public MainPage()
        {
            this.InitializeComponent();
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            // Windows apps are weird and there's no way to eliminate this
        }
        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            if (!textInput.Text.Equals(""))
            {
                todoList.Items.Add(textInput.Text);
                allMyTodos.Add(textInput.Text);
                textInput.Text = "";
            }
        }

        private void textInput_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key.ToString().Equals("Enter"))
            {
                addButton_Click(sender, e);
            }
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in todoList.SelectedItems.OfType<string>().ToList())
            {
                todoList.Items.Remove(item);
                allMyTodos.Remove(item);
            }
        }

        //helper method to handle index changes
        public void MoveItem(int direction)
        {
            // Checking selected item
            if (todoList.SelectedItem == null || todoList.SelectedIndex < 0)
                return; // No selected item - nothing to do

            // Calculate new index using move direction
            int newIndex = todoList.SelectedIndex + direction;

            // Checking bounds of the range
            if (newIndex < 0 || newIndex >= todoList.Items.Count)
                return; // Index out of range - nothing to do

            object selected = todoList.SelectedItem;

            // Removing removable element
            todoList.Items.Remove(selected);
            // Insert it in new position
            todoList.Items.Insert(newIndex, selected);
            // Restore selection
            todoList.SelectedIndex = newIndex;
            
        }

        private void moveUpButton_Click(object sender, RoutedEventArgs e)
        {
            MoveItem(-1);
        }

        private void moveDownButton_Click(object sender, RoutedEventArgs e)
        {
            MoveItem(1);
        }


    }
}
