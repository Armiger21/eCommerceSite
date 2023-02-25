﻿using eCommerceSite.Data;
using eCommerceSite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eCommerceSite.Controllers
{
    public class GamesController : Controller
    {
        private readonly VideoGameContext _context;
        public GamesController(VideoGameContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            // List<Game> games = _context.Games.ToList();
            List<Game> games = await (from game in _context.Games
                                      select game).ToListAsync();

            return View(games);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Game g)
        {
            if (ModelState.IsValid)
            {
                 _context.Games.Add(g);              // Prepares insert
                 await _context.SaveChangesAsync(); // pending insert

                 ViewData["Message"] = $"{g.Title} was added successfully";
                return View();
            }

            return View(g);
        }

        public async Task<IActionResult> Edit(int id)
        {
            Game? gameToEdit = await _context.Games.FindAsync(id);
            if (gameToEdit == null)
            {
                return NotFound();
            }

            return View(gameToEdit);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Game gameModel)
        {
            if (ModelState.IsValid)
            {
                _context.Games.Update(gameModel);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return View(gameModel);
        }
    }
}
