using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using Avalonia.Controls;
using Carbon.Models;
using Carbon.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;

namespace Carbon.ViewModels.InventoryViewModels;

public partial class AddInventoryItemViewModel : ObservableObject {
    public ObservableCollection<AddInventoryItemModel> Items { get; set; }
    public ObservableCollection<string> Categories { get; set; }
    public ObservableCollection<string> Locations { get; set; }
    public ObservableCollection<string> Bins { get; set; }
    
    [ObservableProperty]
    private bool _isSKUReadOnly = true;
    
    public AddInventoryItemViewModel() {
        Items = new ObservableCollection<AddInventoryItemModel>();
        Categories = new ObservableCollection<string>();
        Locations = new ObservableCollection<string>();
        Bins = new ObservableCollection<string>();

        AddItem();
    }

    [RelayCommand]
    private void AddItem() {
        AddInventoryItemModel newItem = new();

        if(IsSKUReadOnly) {
            newItem.Sku = $"UNQ-{DateTime.UtcNow:yyyyMMdd}--{Guid.NewGuid().ToString()[..8]}";
        }
        
        Items.Add(newItem);
    }

    [RelayCommand]
    private void DeleteItem(object? parameter) {
        if(parameter is AddInventoryItemModel item) {
            if(Items.Contains(item)) {
                Items.Remove(item);
            }
        }
    }

    public void OnItemEdited() {
        AddInventoryItemModel last = Items.LastOrDefault();
        if(last != null && !last.IsBlank) {
            Items.Add(new AddInventoryItemModel());
        }
    }

    [RelayCommand]
    private void SaveButton(Window window) {
        WeakReferenceMessenger.Default.Send(new ItemMessenger<AddInventoryItemModel>(new List<AddInventoryItemModel>(Items)));
        window.Close();
    }
    
    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged(string propertyName) {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}