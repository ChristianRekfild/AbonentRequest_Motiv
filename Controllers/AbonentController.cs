using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using motiv.Models;
using System.ComponentModel.DataAnnotations;

namespace motiv.Controllers
{
    [Route("Abonent")]
    public class AbonentController : Controller
    {
        private Context _context;

        public AbonentController(Context context)
        {
            _context = context;
        }

        [Route("")]
        public async Task<ViewResult> Index()
        {
            var modelData = _context.AbonentRequests.ToList();
            
            return View(modelData);
        }

        [Route("New")]
        public ActionResult AddNew()
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("Detail/{id}")]
        public async Task<ActionResult> Edit(int id)
        {
            var request = _context.AbonentRequests.Find(id);

            // TODO причесать на тему NotFound
            if (request is null) return NotFound();

            return View(request);
        }

        [HttpPost]
        [Route("Detail/{id}")]
        public async Task<ActionResult> Edit(AbonentRequest request)
        {
            var existRequest = _context.AbonentRequests.Find(request.Id);

            // TODO причесать на тему NotFound
            if (request is null) return NotFound();

            // можно попробовать зафигачить через рефлексию, если будет время

            // Id и CreateDate не трогаем, ибо это идентификаторы. Пользователям нельзя давать такое в руки)
            if (existRequest.Country != request.Country)
                existRequest.Country = request.Country;
            if (existRequest.Region != request.Region)
                existRequest.Region = request.Region;
            if (existRequest.City != request.City)
                existRequest.City = request.City;
            if (existRequest.Number != request.Number)
                existRequest.Number = request.Number;
            if (existRequest.Reason != request.Reason)
                existRequest.Reason = request.Reason;
            if (existRequest.Direction != request.Direction)
                existRequest.Direction = request.Direction;

            // сохранение изменений
            await _context.SaveChangesAsync();

            return View(request);
        }

        [HttpGet]
        [Route("New")]
        public async Task<ActionResult> New()
        {
            AbonentRequest request = new AbonentRequest()
            {
                Id = 0,
                Country = "",
                Region = "",
                City = "",
                Number = "",
                Reason = "",
                Direction = 0,
                CreateDate = DateTime.Now
            };

            return View(request);
        }

        [HttpPost]
        [Route("New")]
        public async Task<ActionResult> New_Post(AbonentRequest request)
        {
            try
            {
                _context.AbonentRequests.Add(request);
                _context.SaveChanges();
            } catch (Exception ex)
            {
                return View(request);
            }


            return RedirectToAction("Edit", "Abonent", new { @id = request.Id });
        }

        [HttpGet]
        [Route("Delete/{Id}")]
        public async Task<IActionResult> Delete(AbonentRequest request)
        {
            // Да, по идее нужно было реализовать данный метод через POST
            var abonentRequestToDelete = await _context.AbonentRequests.FindAsync(request.Id);
            if (abonentRequestToDelete != null)
            {
                _context.AbonentRequests.Remove(abonentRequestToDelete);
                await _context.SaveChangesAsync();
            }
            else
            {
                // Если указан неверный id
                return RedirectToAction("ShowError", "Abonent");
            }

            return View();
        }

        [HttpGet]
        [Route("Error")]
        public async Task<IActionResult> ShowError()
        {
            return View();
        }
    }
}
