using MultiChatClient.ClientSocket.Protocol;
using System;
using System.Windows.Forms;

namespace MultiChatClient
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (NetworkManager.Instance.TryConnect() == false)
            {
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            NetworkManager.Instance.ChatView = new ChatView();
            NetworkManager.Instance.Start();
            Application.Run(NetworkManager.Instance.ChatView);
        }
    }
}