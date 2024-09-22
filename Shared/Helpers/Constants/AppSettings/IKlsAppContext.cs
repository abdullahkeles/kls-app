using System;

namespace Shared.Helpers.Constants.AppSettings;

public interface IKlsAppContext
{
    string Salt { get; set; }
    string Name { get; set; }
}
