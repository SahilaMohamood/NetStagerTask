using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SurveyApp.Data;
using SurveyApp.Models;

namespace SurveyApp.Controllers
{
    public class SurveysController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SurveysController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Surveys
        public async Task<IActionResult> Index()
        {
            return View(await _context.Surveys.ToListAsync());
        }

        // GET: Surveys/Create
        public IActionResult Create()
        {
            var viewModel = new SurveyCreateViewModel();
            return View(viewModel);
        }

        // POST: Surveys/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SurveyCreateViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Surveys.Add(viewModel.Survey);
                await _context.SaveChangesAsync();

                foreach (var question in viewModel.Questions)
                {
                    question.SurveyId = viewModel.Survey.SurveyId;
                    _context.Questions.Add(question);
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        // GET: Surveys/Take/5
        public async Task<IActionResult> Take(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var survey = await _context.Surveys
                .Include(s => s.Questions)
                .FirstOrDefaultAsync(m => m.SurveyId == id);
            if (survey == null)
            {
                return NotFound();
            }

            var viewModel = new SurveyResponseViewModel
            {
                SurveyId = survey.SurveyId,
                SurveyTitle = survey.Title,
                Responses = survey.Questions.Select(q => new QuestionResponse
                {
                    QuestionId = q.QuestionId,
                    QuestionText = q.Text,
                    QuestionType = q.Type
                }).ToList()
            };

            return View(viewModel);
        }

        // POST: Surveys/Take
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Take(SurveyResponseViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                foreach (var response in viewModel.Responses)
                {
                    _context.Responses.Add(new Response
                    {
                        QuestionId = response.QuestionId,
                        Answer = response.Answer
                    });
                }
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }
    }
}
