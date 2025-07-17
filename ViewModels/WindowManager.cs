using System;
using CommunityToolkit.Mvvm.Messaging.Messages;

namespace Carbon.ViewModels;

public class WindowManager : ValueChangedMessage<Type> {
    public WindowManager(Type windowType) : base(windowType) {}
}