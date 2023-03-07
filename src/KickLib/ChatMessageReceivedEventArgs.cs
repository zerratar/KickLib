using KickLib.Models;

namespace KickLib
{
    public class ChatMessageReceivedEventArgs
    {
        public readonly KickChatMessage Message;

        public ChatMessageReceivedEventArgs(KickChatMessage msg)
        {
            this.Message = msg;
        }
    }
}