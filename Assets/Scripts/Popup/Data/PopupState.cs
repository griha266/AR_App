using ARApp.Utils;

namespace ARApp.Popup
{
    public struct PopupState
    {
        public readonly Option<string> Message;

        public PopupState(Option<string> message)
        {
            Message = message;
        }
    }

}
