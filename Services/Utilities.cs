using System;

namespace Carbon.Services;

public static class Utilities {
    public static int GetCurrentTimeInSeconds() {
        DateTime currentTime = DateTime.UtcNow;
        DateTime epoch = new(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        return (int)(currentTime - epoch).TotalSeconds;
    }
}