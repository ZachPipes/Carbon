using System.Collections.Generic;
using Carbon.Models;
using CommunityToolkit.Mvvm.Messaging.Messages;

namespace Carbon.Services;

public class ItemMessenger<T> : ValueChangedMessage<List<T>> {
    public ItemMessenger(List<T> items) : base(items) {}
}