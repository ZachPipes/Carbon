using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Carbon.Models;
using Carbon.Services;
using Carbon.Views.InventoryPages;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;

namespace Carbon.ViewModels.InventoryViewModels;

public partial class InventoryViewModel : INotifyPropertyChanged {
    public ObservableCollection<InventoryItemModel> Items { get; set; }

    public InventoryViewModel() {
        Items = new ObservableCollection<InventoryItemModel>();

        WeakReferenceMessenger.Default.Register<ItemMessenger<AddInventoryItemModel>>(this, (r, msg) => {
            Console.WriteLine(msg.Value);
            foreach(AddInventoryItemModel newItem in msg.Value) {
                InventoryItemModel item = new() {
                    SKU = newItem.Sku,
                    Title = newItem.Title,
                    Category = newItem.Category,
                    Quantity = newItem.Quantity,
                    Paid = newItem.Paid,
                    Location = string.Empty,
                    Bin = newItem.Bin,
                    Group = newItem.Group
                };
                Items.Add(item);
            }
        });
    }

    [RelayCommand]
    private void OpenAddInventoryItemWindow() {
        WeakReferenceMessenger.Default.Send(new WindowManager(typeof(AddInventoryItemWindow)));
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged(string propertyName) {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}