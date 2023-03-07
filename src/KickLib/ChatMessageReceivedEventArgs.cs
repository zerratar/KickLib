using KickLib.Models;

namespace KickLib
{
    public class ChatMessageReceivedEventArgs
    {
        public readonly ChatMessage Message;

        public ChatMessageReceivedEventArgs(ChatMessage msg)
        {
            this.Message = msg;
        }
    }

    public class ChatMessageDeletedEventArgs
    {
        public readonly DeletedChatMessage Message;

        public ChatMessageDeletedEventArgs(DeletedChatMessage msg)
        {
            this.Message = msg;
        }
    }
}