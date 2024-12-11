using Microsoft.AspNetCore.Mvc.RazorPages;
using sakin_csharp.EventLogCollector;

namespace sakin_csharp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly EventLogService _eventLogService; // Olay günlüğü servisi

        public IndexModel(EventLogService eventLogService)
        {
            _eventLogService = eventLogService; // Bağımlılık enjeksiyonu ile olay günlüğü servisini al
        }

        public void OnGet()
        {
            // Ana sayfa yüklendiğinde yapılacak işlemler
        }
    }
}