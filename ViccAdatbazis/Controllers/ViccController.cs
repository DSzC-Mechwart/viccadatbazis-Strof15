using Microsoft.AspNetCore.Mvc;
using ViccAdatbazis.Models;
using System.Linq;
using System.Threading.Tasks;

namespace ViccAdatbazis.Controllers
{
    public class ViccController : Controller
    {
        private readonly ViccDbContext _context;

        public ViccController(ViccDbContext context)
        {
            _context = context;
        }

        // GET: Vicc
        public IActionResult Index(int page = 1, int pageSize = 10)
        {
            var viccek = _context.ViccekTarolas
                                  .Where(v => v.Aktiv)
                                  .Skip((page - 1) * pageSize)
                                  .Take(pageSize)
                                  .ToList();
            return View(viccek);
        }

    }
}
