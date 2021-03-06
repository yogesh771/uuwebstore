﻿using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UUWebstore.Models;
using UUWebstore.Models.BaseClass;
using UUWebstore.Models.IRepositories;
using UUWebstore.Models.Repositories;

namespace UUWebstore.Controllers
{
    public class websettingController : BaseClass
    {
        private readonly IsettingServices _IsettingServices;
        public websettingController()
        {
            _IsettingServices = new settingServices();
        }
        public ActionResult availablebanners()
        {
            ViewBag.userId = new SelectList(_IsettingServices.bannersCreaTedBy().Select(e => new { e.userId, e.fullName }), "userId", "fullName");
            return View();
        }

        public ActionResult uploadbanner()
        {
            return View();
        }
        [HttpPost]
        public ActionResult uploadbanner(banner obanner, HttpPostedFileBase file)
        {                      
            if (file != null)
            {
                obanner.bannerImgURL= UploadFile(file, "/bannersImg");             
            }
            else {
                TempData["result"] = "Please upload banner image";
                return View();
            }
          
            if (_IsettingServices.uploadBanner(obanner) == 1)
            {
                TempData["result"] = "Banner uploaded. ";
                return RedirectToAction("availablebanners");
            }           
            return View();
        }
        public ActionResult Partial_SearchBannerReult(int userId)
        {            
            var result = _IsettingServices.bannersCreaTedByUserId(userId);
            return PartialView("Partial_SearchUsersReult", result);
        }
        public ActionResult Edit(int id)
        {          
            return View(_IsettingServices.getBannerById(id));
        }
        [HttpPost]
        public ActionResult Edit(banner obanner, HttpPostedFileBase file)
        {        
            if (file != null)
            {
                obanner.bannerImgURL = UploadFile(file, "/bannersImg");
            }
            else
            {
                TempData["result"] = "Please upload banner image";
                return View(obanner);
            }
            if (_IsettingServices.uploadBanner(obanner) == 1)
            {
                TempData["result"] = "Banner updated. ";               
            }          
            return View(obanner);
        }

        public ActionResult AllProductCategories()
        {
            return View();
        }
        public ActionResult Partial_SearchProductCategorieReult(int ddl_filter)
        {         
            return PartialView("Partial_SearchProductCategorieReult", _IsettingServices.GetAllProductCategories(ddl_filter));
        }
        public int makeFeaturedCategory(bool chk, int productCategoryId, Int64 proCategoryClientId)
        {
            return  chk ==true? _IsettingServices.MakeProductCategoriesAsFeatured(productCategoryId) : _IsettingServices.RemoveProductCategoriesAsFeatured(productCategoryId);
                 
        }

        [HttpGet]
        public ActionResult promotionalVideo()
        {
            ViewBag.Video = _IsettingServices.GetVideo();
            return View();
        }
        [HttpPost]       
        public ActionResult promotionalVideo(FormCollection frm)
        {
            string Video = frm["Pramotinal_Video_Url"].ToString();
            ViewBag.message= _IsettingServices.UpdateVideo(Video)==1?"Record updated.":"Record not updated.";
            ViewBag.Video = frm["Pramotinal_Video_Url"].ToString();
            return View();
        }
        [HttpGet]
        public ActionResult PromotionalBlock()
        {
            var promotionalBlockClass = new promotionalBlockClass();
            promotionalBlockClass.promotionalBlock = _IsettingServices.GetBlock();
            return View(promotionalBlockClass);
        }
        [HttpPost]
        public ActionResult PromotionalBlock(promotionalBlockClass opromotionalBlockClass)
        {
            ViewBag.message=_IsettingServices.UpdateBlock(opromotionalBlockClass.promotionalBlock) == 1 ? "Record updated." : "Record not updated.";
            return View(opromotionalBlockClass);
        }
    }
}