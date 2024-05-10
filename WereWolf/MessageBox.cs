using System;
using System.Windows;

namespace Werewolf
{
    public static class MessageBox
    {
        public static bool IsClosing = false;

        public static void ShowException(Exception e) => ShowError(e.Message, "Error - " + e.GetType().Name);

        private static void ShowError(string message, string v)
        {
            throw new NotImplementedException();
        }

        public static void ShowError(string message, string caption, MessageBoxButton oK)
        {
            Show(message, caption, MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public static void ShowInfo(string message, string caption)
        {
            Show(message, caption, MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public static void ShowWarning(string message, string caption)
        {
            Show(message, caption, MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private static void Show(string message, string caption, MessageBoxButton button, MessageBoxImage icon)
        {
            if (IsClosing) return;
            System.Windows.MessageBox.Show(message, caption, button, icon);
        }

        internal static void ShowError(string v1, string v2, MessageBoxButton oK, MessageBoxImage error)
        {
            throw new NotImplementedException();
        }
    }
}