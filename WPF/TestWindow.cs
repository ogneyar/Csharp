using System;
using System.Windows;
using System.Windows.Controls;

namespace HelloWpf
{
    public class TestWindow : Window
    {
        public TestWindow()
        {
            Content = new TextBlock()
            {
                Text = "Hello, WPF!",
                FontSize = 32,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };
        }
    }
}