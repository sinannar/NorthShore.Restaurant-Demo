using System.Threading.Tasks;
using NorthShore.Restaurant.Configuration.Dto;

namespace NorthShore.Restaurant.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
