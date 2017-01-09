﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShadowArena.Models;
using Shadow_Arena.Enumerations;

namespace DalFun2Application
{
    //not exactly secure, normally you'd use Identity and an Authorize attribute. But this is mostly a POC and frankly, worrying about security in this is out of scope

    //alex said, right before some kid on infralab figured out the requests and deleted every player with Charles
    class PlayerController : Controller
    {
        private ShadowBeta_dbContext shadowContext = new ShadowBeta_dbContext();
        private IPlayerRepository repository;

/// <summary>
/// Instantiates the Playercontroller with a repo of choice. Use memory repository for unit testing
/// </summary>
/// <param name="repo">Repository to use</param>
/// 
/// 
/// 
        public PlayerController(IPlayerRepository repo)
        {
            repository = repo;
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.GetString(ContextData.playerId.ToString()) != null)
            {
                if (
                    shadowContext.PlayerSession.Any(
                        s =>
                            s.Playerid ==
                            Convert.ToInt32(HttpContext.Session.GetString(ContextData.playerId.ToString()))
                            && s.Sessionid == HttpContext.Session.GetString(ContextData.sessionId.ToString())))
                {
                    return View("../Game/Index");
                }
            }
            return View();
        }

        [HttpPost]
        private IActionResult DeletePlayer(int playerId)
        {
          
            Player player = new Player();
            player.Id = playerId;
            repository.delete(player);
            return View();
        }

        [HttpPost]
        private IActionResult UpdatePlayer(Player player)
        {
            if (ModelState.IsValid) { 
            repository.update(player);
               }
            return View();
        }

        [HttpPost]
        private IActionResult CreatePlayer(Player player)
        {
            if (ModelState.IsValid)
            {
                repository.add(player);
            }
            return View();
        }
    }
}