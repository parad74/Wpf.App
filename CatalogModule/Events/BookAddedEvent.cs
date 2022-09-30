using Prism.Events;
using Wcf.Client;

namespace Wpf.Module.Events
{
    public class BookAddedEvent : PubSubEvent<Book>
    {
    }
}
