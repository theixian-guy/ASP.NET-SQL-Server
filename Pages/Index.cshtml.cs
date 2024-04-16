using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace WebApplication1.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly MyDbContext _context;

        public IndexModel(ILogger<IndexModel> logger, MyDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public List<Employee> Employees { get; set; }

        public async Task OnGetAsync()
        {
            Employees = await _context.GetAllEmployeesAsync();
        }
    }
}
