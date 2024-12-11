using Microsoft.AspNetCore.Mvc.RazorPages;

namespace sakin_csharp.Pages
{
    public class ErrorModel : PageModel
    {
        public string RequestId { get; set; } // Hata ID'si

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId); // Hata ID'sini gösterme durumu

        public void OnGet()
        {
            RequestId = HttpContext.TraceIdentifier; // Hata ID'sini al
        }
    }
}