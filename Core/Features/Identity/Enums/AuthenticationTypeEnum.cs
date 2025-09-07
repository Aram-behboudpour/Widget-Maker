namespace oc.TSB.Core.Features.Identity.Enums;

public enum AuthenticationTypeEnum:int
{
    [System.ComponentModel.DataAnnotations.Display
        (ResourceType = typeof(Resources.DataDictionary),
        Name = nameof(Resources.DataDictionary.AuthenticationTypepublic))]
    Internal = 0,

    [System.ComponentModel.DataAnnotations.Display
        (ResourceType = typeof(Resources.DataDictionary),
        Name = nameof(Resources.DataDictionary.AuthenticationTypeGoogle))]
    Google = 1,
}
