using System;
using System.IO;

namespace Carbon.Services;

public static class AppSetup {
    public static void SetupAppDirectory() {
        Directory.CreateDirectory(AppState.Instance.FilePath);

        string[] files =
            ["inventory.csv", "listings.csv", "orders.csv", "settings.json", "ProgramCredentials.json", "Token.json"];
        foreach (string file in files) {
            string fullFilePath = Path.Combine(AppState.Instance.FilePath, file);
            if (File.Exists(fullFilePath)) continue;
            File.Create(fullFilePath).Close();
        }
    }

    public static async void TokenUpdate() {
        try {
            await AppState.Instance.CheckForTokenUpdate();
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }
}