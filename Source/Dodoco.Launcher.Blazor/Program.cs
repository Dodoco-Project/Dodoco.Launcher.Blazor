namespace Dodoco.Launcher.Blazor;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Ignis.Components.Server;
using Photino.Blazor;

using System.Reflection;

class Program {

    public static string Title { get; private set; }
    public static string Version { get; private set; }
    public static string Company { get; private set; }
    public static string Description { get; private set; }

    static Program() {

        /*
         * Load assembly metadata
        */

        AssemblyProductAttribute? productAttribute         = (AssemblyProductAttribute?) Attribute.GetCustomAttribute(Assembly.GetExecutingAssembly(), typeof(AssemblyProductAttribute), false);
        AssemblyTitleAttribute? titleAttribute             = (AssemblyTitleAttribute?) Attribute.GetCustomAttribute(Assembly.GetExecutingAssembly(), typeof(AssemblyTitleAttribute), false);
        AssemblyFileVersionAttribute? fileVersionAttribute = (AssemblyFileVersionAttribute?) Attribute.GetCustomAttribute(Assembly.GetExecutingAssembly(), typeof(AssemblyFileVersionAttribute), false);
        AssemblyCompanyAttribute? companyAttribute         = (AssemblyCompanyAttribute?) Attribute.GetCustomAttribute(Assembly.GetExecutingAssembly(), typeof(AssemblyCompanyAttribute), false);
        AssemblyDescriptionAttribute? descriptionAttribute = (AssemblyDescriptionAttribute?) Attribute.GetCustomAttribute(Assembly.GetExecutingAssembly(), typeof(AssemblyDescriptionAttribute), false);
        
        Program.Title = productAttribute?.Product ?? "[Assembly product attribute not found]";
        Program.Version = fileVersionAttribute?.Version ?? "[Assembly file version attribute not found]";
        Program.Company = companyAttribute?.Company ?? "[Assembly company attribute not found]";
        Program.Description = descriptionAttribute?.Description ?? "[Assembly description attribute not found]";
        
    }

    [STAThread]
    static void Main(string[] args) {

        const string BUNDLE_FOLDER_NAME = "Bundle";

        var appBuilder = PhotinoBlazorAppBuilder.CreateDefault(args);
        appBuilder.Services.Remove(appBuilder.Services.First(descriptor => descriptor.ServiceType == typeof(IFileProvider)));
        appBuilder.Services.AddSingleton<IFileProvider>(_ =>  {
            var root = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, BUNDLE_FOLDER_NAME);
            return new PhysicalFileProvider(root);
        });
        appBuilder.Services.AddIgnisServer();

        // register root component
        appBuilder.RootComponents.Add<App>("app");

        var app = appBuilder.Build();

        // customize window
        app.MainWindow
            //.SetIconFile(Path.Join(AppContext.BaseDirectory, BUNDLE_FOLDER_NAME, "favicon.ico"))
            //.SetUseOsDefaultSize(false)
            //.Center()
            //.SetWidth(1270)
            //.SetHeight(766)
            //.SetResizable(false)
            //.SetChromeless(false)
            //.SetTitle(Program.Title);
            .SetIconFile(Path.Join(AppContext.BaseDirectory, BUNDLE_FOLDER_NAME, "favicon.ico"))
            .SetUseOsDefaultSize(false)
            .Center()
            .SetWidth(1270)
            .SetHeight(480)
            .SetResizable(true)
            .SetChromeless(false)
            .SetTitle(Program.Title);

        AppDomain.CurrentDomain.UnhandledException += (sender, error) => {

            app.MainWindow.ShowMessage("Fatal exception", error.ExceptionObject.ToString());
            
        };

        app.Run();
    }

}