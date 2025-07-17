using System.ComponentModel;

namespace Carbon.Models;

public class AddInventoryItemModel : INotifyPropertyChanged {
    private string _sku = string.Empty;
    private string _title = string.Empty;
    private string _category = string.Empty;
    private int _quantity;
    private decimal _paid;
    private string _bin = string.Empty;
    private string _group = string.Empty;

    public string Sku {
        get => _sku;
        set {
            _sku = value;
            OnPropertyChanged(nameof(Sku));
        }
    }

    public string Title {
        get => _title;
        set {
            _title = value;
            OnPropertyChanged(nameof(Title));
        }
    }

    public string Category {
        get => _category;
        set {
            _category = value;
            OnPropertyChanged(nameof(Category));
        }
    }

    public int Quantity {
        get => _quantity;
        set {
            _quantity = value;
            OnPropertyChanged(nameof(Quantity));
        }
    }

    public decimal Paid {
        get => _paid;
        set {
            _paid = value;
            OnPropertyChanged(nameof(Paid));
        }
    }

    public string Bin {
        get => _bin;
        set {
            _bin = value;
            OnPropertyChanged(nameof(Bin));
        }
    }

    public string Group {
        get => _group;
        set {
            _group = value;
            OnPropertyChanged(nameof(Group));
        }
    }

    public bool IsBlank =>
        string.IsNullOrWhiteSpace(Sku) &&
        string.IsNullOrWhiteSpace(Title) &&
        string.IsNullOrWhiteSpace(Category) &&
        Quantity == 0 &&
        Paid == 0 &&
        string.IsNullOrWhiteSpace(Bin) &&
        string.IsNullOrWhiteSpace(Group);
    
    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged(string name) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}