using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WorkTimer.Domain.Timers;
using Timer = WorkTimer.Domain.Timers.Timer;

namespace WorkTimer.Pages;

public class IndexModel : PageModel
{
    [BindProperty]
    public Timer Timer { get; set; }
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
        Timer = new Timer();
    }

    public void OnPostSubmit()
    {
        Timer.MorningStart = TimeOnly.Parse(Request.Form["morning-start"]);
        Timer.MorningEnd = TimeOnly.Parse(Request.Form["morning-end"]);
        Timer.AfternoonStart = TimeOnly.Parse(Request.Form["afternoon-start"]);

        Timer.SetAfternoonEnd();
    }

    public void OnPostResetForm()
    {
        Timer = new Timer();
    }
}
