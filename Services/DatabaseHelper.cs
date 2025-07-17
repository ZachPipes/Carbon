using System.IO;
using Microsoft.Data.Sqlite;

namespace Carbon.Services;

public class DatabaseHelper {
    private static readonly string ConnectionString =
        $"Data Source={Path.Combine(AppState.Instance.FilePath, "carbon.sqlite")}";

    public static void InitializeDatabase() {
        using SqliteConnection conn = new(ConnectionString);
    }
}