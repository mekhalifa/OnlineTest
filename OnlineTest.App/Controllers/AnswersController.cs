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
    [Route("question/{Controller}")]
    [Authorize(Roles = "Admin")]

    public class AnswersController : Controller
    {
        private readonly AnswerRepo _repo;
        private readonly IMapper _mapper;

        public AnswersController(AnswerRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

       [HttpGet("{qid}")]
        public async Task<IActionResult> Index(int? qid)
        {
            var list = await _repo.GetAllByQuestionId((int)qid);
            ViewBag.limit = list.Count() <= 4;
            ViewBag.QuestionId = qid;
            return View(_mapper.Map<List<AnswerListAdminDto>>(list ));
        }

        [HttpGet("{qid}/{id}")]
        public async Task<IActionResult> Details(int? qid,int? id)
        {
            ViewBag.QuestionId = qid;
            if (id == null)
            {
                return NotFound();
            }
            var Answer = await _repo.GetById((int)id);
            if (Answer == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<AnswerDto>(Answer));
        }

        [HttpGet("{qid}/Add")]
        public IActionResult Create(int? qid)
        {
            ViewBag.QuestionId = qid;
            return View();
        }

        [HttpPost("{qid}/Add")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int? qid, AnswerDto Answer)
        {
            ViewBag.QuestionId = qid;
            if (ModelState.IsValid)
            {
                Answer.QuestionId =(int) qid;
                if (Answer.IsCorrect) _repo.OnlyOneCurrect();
                await _repo.Add(_mapper.Map<Answer>(Answer));
                await _repo.Save();
                return RedirectToAction(nameof(Index),new { qid});
            }
            return View(_mapper.Map<AnswerDto>(Answer));
        }

        [HttpGet("{qid}/Edit/{id}")]
        public async Task<IActionResult> Edit(int? qid,int? id)
        {
            ViewBag.QuestionId = qid;
            if (id == null)
            {
                return NotFound();
            }

            var Answer = await _repo.GetById((int)id);
            if (Answer == null)
            {
                return NotFound();
            }
            Answer.QuestionId =(int) qid;
            
            return View(_mapper.Map<AnswerDto>(Answer));
        }

        [HttpPost("{qid}/Edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int qid, int id,  AnswerDto Answer)
        {
            ViewBag.QuestionId = qid;
            if (id != Answer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (Answer.IsCorrect) _repo.OnlyOneCurrect();
                    _repo.Update(_mapper.Map<Answer>(Answer));
                    await _repo.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!(await AnswerExists(Answer.Id)))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToAction(nameof(Index),new {qid});
            }
            return View(_mapper.Map<AnswerDto>(Answer));
        }

        [HttpGet("{qid}/Delete/{id}")]
        public async Task<IActionResult> Delete(int? qid , int? id)
        {
            ViewBag.QuestionId = qid;
            if (id == null)
            {
                return NotFound();
            }
            
            var Answer = await _repo.GetById((int)id);
            if (Answer == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<AnswerDto>(Answer));
        }


        [HttpPost("{qid}/Delete/{id}"), ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? qid ,int id)
        {
            ViewBag.QuestionId = qid;
            var Answer = await _repo.GetById(id);
            _repo.Delete(_mapper.Map<Answer>(Answer));
            await _repo.Save();
            return RedirectToAction(nameof(Index),new { qid});
        }

        private async Task<bool> AnswerExists(int id)
        {
            return await _repo.GetById(id)== null ? false :true;
        }
    }
}
