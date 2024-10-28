using MultiChatClient.ClientSocket.Protocol;

namespace MultiChatClient
{
    public partial class ChatView : Form
    {
        public ChatView()
        {
            InitializeComponent();

            TextBoxInputMessage.KeyPress += ChatView_KeyPress;
        }

        private void ClickBtnSendMessage(object sender, EventArgs e)
        {
            NetworkManager.Instance.SendMessage(TextBoxInputMessage.Text);
            TextBoxInputMessage.Clear();
        }

        private void ClickBtnCloseProgram(object sender, EventArgs e)
        {
            NetworkManager.Instance.Disconnect();
            Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void TextChangedTextBoxInputMessage(object sender, EventArgs e)
        {

        }

        public void ChatView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals('\r'))
            {
                ClickBtnSendMessage(sender, e);
            }
        }
    }
}
