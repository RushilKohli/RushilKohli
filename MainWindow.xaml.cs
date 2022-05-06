using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Blackjack2022
{
    public partial class MainWindow : Window
    {
        Blackjack game = new Blackjack();
        public MainWindow()
        {
            InitializeComponent();
            game.InitShoe();
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            game.Start();
            RefreshScreen();
            StartButton.IsEnabled = false;
            HitButton.IsEnabled = true;
            StandButton.IsEnabled = true;
        }

        private void HitButton_Click(object sender, RoutedEventArgs e)
        {
            int result = game.Hit();
            RefreshScreen();
            if(result < 0)
            {
                MessageBox.Show("Player Busted, Dealer won!");
                HitButton.IsEnabled = false;
                StandButton.IsEnabled= false;
                StartButton.IsEnabled = true;
                game.Reset();
            }
        }

        private void StandButton_Click(object sender, RoutedEventArgs e)
        {
            StandButton.IsEnabled = false;
            HitButton.IsEnabled = false;
            int result = game.Stand();
            RefreshScreen();
            if (result == -2)
            {
                MessageBox.Show("Player Won!");
                RefreshScreen();

                StartButton.IsEnabled = true;
                game.Reset();
            }

            if (result == -1)
            {
                MessageBox.Show("Dealer Busted, Player won!");
                RefreshScreen();
                
                StartButton.IsEnabled = true;
                game.Reset();
            }
            
            if (result == 0)
            {
                MessageBox.Show("Player Won!");
                RefreshScreen();

                StartButton.IsEnabled = true;
                game.Reset();
            }

            if (result == 1)
            {
                MessageBox.Show("Dealer Won!");
                RefreshScreen();

                StartButton.IsEnabled = true;
                game.Reset();
            }

            if (result == 2)
            {
                MessageBox.Show("Match tied!");
                RefreshScreen();

                StartButton.IsEnabled = true;
                game.Reset();
            }
        }

        public void RefreshScreen()
        {
            PlayerPanel.Children.Clear();
            DealerPanel.Children.Clear();
            foreach (Card c in game.playerDeck)
            {
                ShowCard(c, PlayerPanel);
            }
            foreach (Card c in game.dealerDeck)
            {
                ShowCard(c, DealerPanel);
            }
        }

        public void ShowCard(Card c, Panel panel)
        {
            string path = "/png/";
            string filename = c.GetFileName();

            Uri uri = new Uri(path + filename, UriKind.Relative);
            BitmapImage bitmapImage = new BitmapImage(uri);
            Image image = new Image();
            image.Source = bitmapImage;

            panel.Children.Add(image);
        }

    }
}