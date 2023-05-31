
using Google_ToDo.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace apliakcjaZadania.Controllers
{
    [Authorize]
    public class HistoryController : Controller
    {
        private readonly Taskcontext _context;

        public HistoryController(Taskcontext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {

            var deletedRecords = _context.zadanie.Where(x => x.IsActive == false).ToList();
            return View(deletedRecords);


        }

        public async Task<IActionResult> Recover(int? id)
        {
            var deletedRecord = _context.zadanie.FirstOrDefault(x => x.Id == id);

            deletedRecord.IsActive = true;
            _context.zadanie.Update(deletedRecord);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));


        }
    }
}
