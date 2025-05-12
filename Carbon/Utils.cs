using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace Carbon;

public static class Utils {
    // Displays an error with the 'errorMessage' in a pop-up window
    public static void ShowError(string errorMessage) {
        MessageBox.Show(errorMessage, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
    }

    // Loads a csv file from 'fileName' into the 'grid'
    // Will create a directory if one DNE
    public static ObservableCollection<InventoryItem> LoadFile(string fileName, DataGrid grid) {
        // TODO: MAKE THIS COMPATIBLE WITH ANY DIRECTORY NAME
        var filePath = $@"C:\Users\{Environment.UserName}\Documents\Carbon";

        // If directory DNE -> creates directory and returns 
        if (!Directory.Exists(filePath)) {
            Directory.CreateDirectory(filePath);
            return new ObservableCollection<InventoryItem>();
        }

        filePath += $@"\{fileName}.csv";

        if (File.Exists(filePath)) {
            var lines = File.ReadAllLines(filePath);
            var items = new ObservableCollection<InventoryItem>();
            for (int i = 1; i < lines.Length; i++) {
                var line = lines[i];
                var columns = line.Split(',');

                if (columns.Length != 5) ShowError($"Invalid number of columns for {filePath} at row {i}");

                var item = new InventoryItem() {
                    Name = columns[0],
                    Category = columns[1],
                    Paid = double.TryParse(columns[2], out var paid) ? paid : 0,
                    Location = columns[3],
                    Bin = columns[4]
                };
                items.Add(item);
            }

            grid.ItemsSource = items;
            return items;
        }

        File.Create(filePath).Close();
        return new ObservableCollection<InventoryItem>();
    }
}