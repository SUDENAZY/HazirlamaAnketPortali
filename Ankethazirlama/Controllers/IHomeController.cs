using Microsoft.AspNetCore.Mvc;

namespace Ankethazirlama.Controllers
{
    public interface IHomeController
    {
        IActionResult Error();
        IActionResult GirişYap();
        IActionResult Index();
        IActionResult Privacy();
    }
}