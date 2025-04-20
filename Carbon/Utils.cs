using System.IO;
using System.Windows;

namespace Carbon;

public static class Utils {
    public static void ShowError(string errorMessage) {
        MessageBox.Show(errorMessage, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
    }
    
    public static void LoadFile(string fileName) {
        // TODO: MAKE THIS COMPATIBLE WITH ANY DIRECTORY NAME
        var filePath = $@"C:\Users\{Environment.UserName}\Documents\Carbon";

        if(!Directory.Exists(filePath)) {
            Directory.CreateDirectory(filePath);
        }

        filePath += $@"\{fileName}.csv";

        if(!File.Exists(filePath)) {
            File.Create(filePath).Close();
        }
        
        var lines = File.ReadAllLines(filePath);
    }
}