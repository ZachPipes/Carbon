using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace Carbon;

public static class Utils {
    public static void SetupAppDirectory() {
        Directory.CreateDirectory(AppState.Instance.FilePath);

        string[] files = ["inventory.csv", "listings.csv", "orders.csv", "settings.json", "ProgramCredentials.json", "Token.json"];
        foreach (string file in files) {
            string fullFilePath = Path.Combine(AppState.Instance.FilePath, file);
            if (File.Exists(fullFilePath)) continue;
            File.Create(fullFilePath).Close();
        }
    }

    public static void ShowError(string errorMessage) {
        MessageBox.Show(errorMessage, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
    }

    public static int GetCurrentTimeInSeconds() {
        DateTime currentTime = DateTime.UtcNow;
        DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        return (int)(currentTime - epoch).TotalSeconds;
    }

    public static async void TokenUpdate() {
        try {
            await AppState.Instance.CheckForTokenUpdate();
        } catch (Exception ex) {
            ShowError(ex.Message);
        }
    }

    public static ObservableCollection<InventoryItem> LoadFile(string fileName, DataGrid grid) {
        string filePathTemp = AppState.Instance.FilePath;
        filePathTemp += $@"\{fileName}.csv";

        if (File.Exists(filePathTemp)) {
            string[] lines = File.ReadAllLines(filePathTemp);
            ObservableCollection<InventoryItem> items = new();
            for (int i = 1; i < lines.Length; i++) {
                string line = lines[i];
                string[] columns = line.Split(',');

                if (columns.Length != 5) ShowError($"Invalid number of columns for {filePathTemp} at row {i}");

                InventoryItem item = new() {
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

        File.Create(filePathTemp).Close();
        return new ObservableCollection<InventoryItem>();
    }
}