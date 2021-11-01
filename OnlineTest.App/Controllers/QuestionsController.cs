using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlineTest.App.Models;
using OnlineTest.Core.Models;
using OnlineTest.Infrastructure.Data;
using OnlineTest.Infrastructure.Repositories;

namespace OnlineTest.App.Controllers
{
    [Authorize(Roles ="Admin")]
    
    public class QuestionsController : Controller
    {
        private readonly QuestionRepo _repo;
        private readonly IMapper _mapper;

        public QuestionsController(QuestionRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

       
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<List<QuestionListDto>>(await _repo.GetAll()));
        }

      
        public async Task<IActionResult> Details(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }
            var question = await _repo.GetById((int)id);
            if (question == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<QuestionDto>(question));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("QuestionText,QuestionPoint,Id")] QuestionDto question)
        {
            if (ModelState.IsValid)
            {
                await _repo.Add(_mapper.Map<Question>(question));
                await _repo.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(_mapper.Map<QuestionDto>(question));
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var question = await _repo.GetById((int)id);
            if (question == null)
            {
                return NotFound();
            }
            return View(_mapper.Map<QuestionDto>(question));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("QuestionText,QuestionPoint,Id")] QuestionDto question)
        {
            if (id != question.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _repo.Update(_mapper.Map<Question>(question));
                    await _repo.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!(await QuestionExists(question.Id)))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(_mapper.Map<QuestionDto>(question));
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            var question = await _repo.GetById((int)id);
            if (question == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<QuestionDto>(question));
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var question = await _repo.GetById(id);
            _repo.Delete(_mapper.Map<Question>(question));
            await _repo.Save();
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> QuestionExists(int id)
        {
            return await _repo.GetById(id)== null ? false :true;
        }
    }
}
