using Microsoft.Extensions.Logging;
using LinkUp.Okta;
using OktaClientConfiguration = LinkUp.Okta.OktaClientConfiguration;

namespace LinkUp;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        string root = new Globals().ROOT_DIRECTORY;
        Directory.CreateDirectory(root + Globals.USER_DIRECTORY);
        Directory.CreateDirectory(root + Globals.GROUP_DIRECTORY);


            // Singleton global creates one copy
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<MainViewModel>();

            
#if DEBUG
        builder.Logging.AddDebug();
#endif

        builder.Services.AddSingleton<MainPage>();

        var oktaClientConfiguration = new Okta.OktaClientConfiguration()
        {
            // Use "https://{yourOktaDomain}/oauth2/default" for the "default" authorization server, or
            // "https://{yourOktaDomain}/oauth2/<MyCustomAuthorizationServerId>"

            OktaDomain = "https://dev-72105010.okta.com/oauth2/default",
            ClientId = "foo",
            RedirectUri = "myapp://callback",
            Browser = new WebBrowserAuthenticator()
        };

        builder.Services.AddSingleton(new OktaClient(oktaClientConfiguration));

        return builder.Build();
    }
}