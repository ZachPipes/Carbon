using System;
using System.IO;

namespace Carbon.Services;

public class AppSetup {
    public void SetupAppDirectory() {
        Directory.CreateDirectory(AppState.Instance.FilePath);

        string[] files =
            ["inventory.csv", "listings.csv", "orders.csv", "settings.json", "ProgramCredentials.json", "Token.json"];
        foreach (string file in files) {
            string fullFilePath = Path.Combine(AppState.Instance.FilePath, file);
            if (File.Exists(fullFilePath)) continue;
            File.Create(fullFilePath).Close();
        }
    }

    public async void TokenUpdate() {
        try {
            await AppState.Instance.CheckForTokenUpdate();
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }
}