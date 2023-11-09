using SaudiPieShop.Models;
using Microsoft.AspNetCore.Components;

namespace SaudiPieShop.Pages.App
{
    public partial class PieCard
    {
        [Parameter]
        public Pie? Pie { get; set; }
    }
}
