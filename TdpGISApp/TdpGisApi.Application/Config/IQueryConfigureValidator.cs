using TdpGisApi.Configuration.Model;

namespace TdpGisApi.Application.Config
{
    public interface IQueryConfigureValidator
    {
        ValidatingResult ValidateAllQueryConfiguration(GisAppConfig appConfigInstance);
    }
}