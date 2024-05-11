using Esri.ArcGISRuntime;
using Esri.ArcGISRuntime.Mapping;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace GeoJason.Web.Pages
{
    public class MapModel : PageModel
    {
        public Map? Map { get; private set; }

        private readonly IConfiguration _configuration;

        public MapModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void OnGet()
        {
            if (OperatingSystem.IsWindows() && Environment.OSVersion.Version >= new Version(10, 0, 19041))
            {
                ArcGISRuntimeEnvironment.ApiKey = "YOUR_API_KEY";
                Map = new Map(BasemapStyle.ArcGISImagery);
            }
            else
            {
                // Handle unsupported platforms
                Map = new Map(BasemapStyle.OSMStandard); // Example fallback
            }
        }

    }
}
