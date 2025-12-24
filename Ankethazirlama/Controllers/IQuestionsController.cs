using Ankethazirlama.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ankethazirlama.Controllers
{
    public interface IQuestionsController
    {
        IActionResult Create(int surveyId);
        Task<IActionResult> Create(Question question);
        Task<IActionResult> Index(int id);
        IActionResult SubmitQuestion();
    }
}