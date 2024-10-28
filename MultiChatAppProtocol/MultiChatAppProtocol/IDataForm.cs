using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MultiChatAppProtocol
{
    public enum DataType
    {
        SystemMessage,
        NoticeMessage,
        ChatMessage
    }

    public class ChatClientInfo
    {
        public required String Id { get; init; }
        public required String NickName { get; init; }
    }

    public interface IDataForm
    {
//        public DataType DataType { get; init; }
        public String Message { get; init; }
    }

    public class SystemMessageDataForm : IDataForm
    {
        public required String Message { get; init; }

        public override string ToString()
        {
            return Message;
        }
    }

    public class ChatMessageDataForm : IDataForm
    {
//        public DataType DataType { get; init; }
        public required ChatClientInfo ChatClientInfo { get; init; }
        public required String Message { get; init; }
        public DateTime MessageCreatedTime { get; init; }

        public override String ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append('[');
            stringBuilder.Append(MessageCreatedTime);
            stringBuilder.Append("] ");
            stringBuilder.Append(ChatClientInfo.NickName);
            stringBuilder.Append(": ");
            stringBuilder.AppendLine(Message);

            return stringBuilder.ToString();
        }
    }
}
