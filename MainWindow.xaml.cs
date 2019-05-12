// Author: Matt Lester
// Assignment 5
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
namespace Assignment_5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string whoClicked = "O";
        string upNext = "X";
        public List<String> X_List = new List<string>();
        public List<String> O_List = new List<string>();

        // winning combinations
        static List<String> topRow = new List<string>() { "0,0", "0,1", "0,2" }; // top row
        static List<String> middleRow = new List<string>() { "1,0", "1,1", "1,2" }; // middle row
        static List<String> bottomRow = new List<string>() { "2,0", "2,1", "2,2" }; // bottom row
        static List<String> leftColumn = new List<string>() { "0,0", "1,0", "2,0" }; // left column
        static List<String> middleColumn = new List<string>() { "0,1", "1,1", "2,1" }; // middle column
        static List<String> rightColumn = new List<string>() { "0,2", "1,2", "2,2" }; // right column
        static List<String> diagLeftToRight = new List<string>() { "0,0", "1,1", "2,2" }; // right column
        static List<String> diagRightToLeft = new List<string>() { "0,2", "1,1", "2,0" }; // right column
        public List<List<string>> winningCombonations = new List<List<string>>()
            {
                topRow, middleRow, bottomRow, leftColumn, middleColumn, rightColumn, diagLeftToRight, diagRightToLeft
            };

        public MainWindow()
        {
            InitializeComponent();
            uxTurn.Text = "X Goes First";            
        }

        private void Button_Click(Object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button.Content == null)
            {
                if (whoClicked == "X") // X pressed button
                {
                    whoClicked = "O";
                    upNext = "X";
                    O_List.Add(button.Tag.ToString());
                }
                else // O pressed button
                {
                    whoClicked = "X";
                    upNext = "O";
                    X_List.Add(button.Tag.ToString());
                }
                button.Content = whoClicked;
                uxTurn.Text = upNext + " Is Up";
                Check_For_Winner();
            }
        }

        private void uxNewGame_Click(object sender, RoutedEventArgs e)
        {
            foreach (Button button in uxGrid.Children)
            {
                button.Content = null;
                button.IsEnabled = true;
            }
            uxTurn.Text = "X Goes First";
            whoClicked = "O";
        }

        private void Check_For_Winner()
        {
            // button.IsEnabled = false;
            foreach(List<string> item in winningCombonations)
            {
                var X_Intersect = X_List.Intersect(item);
                var O_Intersect = O_List.Intersect(item);

                if (X_Intersect.Count() == 3)
                {
                    uxTurn.Text = "X is the Winner!";
                    Disable_Buttons();
                }

                if (O_Intersect.Count() == 3)
                {
                    uxTurn.Text = "O is the Winner!";
                    Disable_Buttons();
                }
            }
        }

        private void Disable_Buttons()
        {
            foreach (Button button in uxGrid.Children)
            {
                button.IsEnabled = false;
                X_List.Clear();
                O_List.Clear();
            }
        }

        private void uxExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
