﻿//-----------------------------------------------------------------------
// <copyright file= "HomeController.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018-02-08 19:35:43
// Modified by:
// Description: Administrator-Home-控制器
//-----------------------------------------------------------------------
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PSU.EFCore;
using PSU.IService.Areas.Administrator;
using PSU.Model.Areas.Administrator.Home;
using PSU.Utility.Web;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Controllers.PSU.Areas.Administrator
{
    [Area("Administrator")]
    //[Authorize(Roles = "Administrator")]
    public class HomeController : Controller
    {
        #region Initialize

        private readonly IHomeService _service;

        private readonly ILogger _logger;

        private readonly ApplicationDbContext _context;

        public HomeController(IHomeService service, ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _service = service;
            _logger = logger;
            _context = context;
        }

        #endregion

        #region View

        /// <summary>
        /// 首页
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var webModel = await _service.InitIndexPageAsync();
            return View();
        }

        /// <summary>
        /// 公告编辑页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Bulletin()
        {
            return View();
        }

        /// <summary>
        /// 公告详情页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Detail()
        {
            return View();
        }

        /// <summary>
        /// 公告编辑页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Edit(string id)
        {
            BulletinEditViewModel webModel = new BulletinEditViewModel
            {
                Title = "",
                Content = "",
                Target = 0,
                Type = 0
            };
            if (!string.IsNullOrEmpty(id))
            {
                //Todo:编辑页面，加载公告相关信息
            }
            return View(webModel);
        }

        #endregion

        #region Service

        /// <summary>
        /// 公告页面搜索
        /// </summary>
        /// <param name="webModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Search(string search)
        {
            BulletinViewModel webModel = JsonUtility.ToObject<BulletinViewModel>(search);

            webModel = await _service.SearchBulletinAsync(webModel, _context);

            var returnData = new
            {
                data = webModel.BulletinList,
                limit = webModel.Limit,
                page = webModel.Page,
                total = webModel.BulletinList.Count
            };

            return Json(returnData);
        }

        /// <summary>
        /// 公告编辑页面
        /// </summary>
        /// <param name="webModel"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(BulletinEditViewModel webModel)
        {
            if (string.IsNullOrEmpty(webModel.Id))
            {
                //Todo:新增公告
            }
            else
            {
                //Todo:更新公告信息
            }

            return View();
        }

        #endregion
    }
}
