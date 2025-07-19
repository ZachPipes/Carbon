using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Carbon.Views;
using Carbon.Services;

namespace Carbon;

public partial class App : Application {
    public override void Initialize() {
        AvaloniaXamlLoader.Load(this);
        
        RequestedThemeVariant = Avalonia.Styling.ThemeVariant.Light;
    }

    public override void OnFrameworkInitializationCompleted() {
        AppSetup.SetupAppDirectory();
        AppSetup.TokenUpdate();
        
        if(ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop) {
            desktop.MainWindow = new MainWindow();
        }

        base.OnFrameworkInitializationCompleted();
    }
}