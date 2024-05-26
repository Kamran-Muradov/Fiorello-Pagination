using Fiorello_PB101.Models;
using Fiorello_PB101.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Fiorello_PB101.ViewComponents
{
    public class FooterViewComponent : ViewComponent
    {
        private readonly ISettingService _settingService;
        private readonly ISocialService _socialService;

        public FooterViewComponent(
            ISettingService settingService,
            ISocialService socialService
            )
        {
            _settingService = settingService;
            _socialService = socialService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult(View(new FooterVMVC
            {
                Socials = await _socialService.GetAllAsync(),
                Settings = await _settingService.GetAllAsync()
            }));
        }
    }

    public class FooterVMVC
    {
        public IEnumerable<Social> Socials { get; set; }
        public Dictionary<string, string> Settings { get; set; }
    }
}
