using System;
using Microsoft.Extensions.Configuration;

namespace Shared.Helpers.Constants.AppSettings;

public class KlsAppContext : IKlsAppContext
{
    public string Salt { get; set; }
    public string Name { get; set; }
    public KlsAppContext(IConfiguration configuration)
    {
        var appSection = configuration.GetSection("App");
        Salt = appSection["Salt"] ?? "";
        Name = appSection["Name"] ?? "";
    }
}
