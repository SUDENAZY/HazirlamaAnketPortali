using Ankethazirlama.Models;
using Ankethazirlama.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Ankethazirlama.Controllers
{
    public class QuestionsController : Controller
    {
        private readonly IGenericRepository<Question> _questionRepository;
        private readonly IGenericRepository<Survey> _surveyRepository;

        public QuestionsController(
            IGenericRepository<Question> questionRepository,
            IGenericRepository<Survey> surveyRepository)
        {
            _questionRepository = questionRepository;
            _surveyRepository = surveyRepository;
        }

        // 1) BELİRLİ ANKETİN SORULARINI LİSTELE
        public async Task<IActionResult> Index(int id)
        {
            var survey = await _surveyRepository.GetByIdAsync(id);
            if (survey == null) return NotFound();

            ViewBag.SurveyTitle = survey.Title;
            ViewBag.SurveyId = id;

            var questions = await _questionRepository.GetAllAsync();
            questions = questions.Where(q => q.SurveyId == id).ToList();

            return View(questions);
        }

        // 2) SORU EKLE (GET)
        public IActionResult Create(int surveyId)
        {
            var question = new Question
            {
                SurveyId = surveyId
            };

            return View(question);
        }

        // 3) SORU EKLE (POST)
        [HttpPost]
        public async Task<IActionResult> Create(Question question)
        {
            if (!ModelState.IsValid)
            {
                return View(question);
            }

            await _questionRepository.AddAsync(question);
            await _questionRepository.SaveAsync();

            return RedirectToAction("Index", new { id = question.SurveyId });
        }
    }
        [HttpPost]
        public IActionResult SubmitQuestion()
        {
            return Ok();
        }

    }
