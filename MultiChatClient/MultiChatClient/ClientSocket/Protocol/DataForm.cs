using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace MultiChatClient.ClientSocket.Protocol
{
    internal class DataForm
    {

    }

    public class ChatClientInfo
    {
        public String Id { get; init; }
        public String NickName { get; init; }
    }

    public class MessageDataForm
    {
        public ChatClientInfo ChatClientInfo { get; init; }
        public String Message { get; init; }
        public DateTime MessageCreatedTime { get; init; }

        public String ParseForChatView()
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
