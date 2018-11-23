﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using UUWebstore.Models.IRepositories;

namespace UUWebstore.Models.Repositories
{
    public class themeServices : BaseClass.BaseClass, IthemeServices
    {
        private readonly UnitOfWork uow;

        public themeServices()
        {
            uow = new UnitOfWork();
        }
        public List<theme> getallTheme()
        {
            return uow.theme_.GetAll().Where(e => e.isDelete == false).ToList();
        }
        public int ApplyTheme(int themeId)
        {
            var themeid = new SqlParameter("@themeId", themeId);
            var modifyBy = new SqlParameter("@modifyBy", BaseUtil.GetSessionValue(AdminInfo.LoginID.ToString()).ToString());
            var result = uow.sp_LoginUser_Result_.SQLQuery<int>("applyTheme_sp @themeId, @modifyBy", themeid, modifyBy).FirstOrDefault();
            return result;
        }

        public int uploadLogo(string logoUrl)
        {
            var logoUrl_ = new SqlParameter("@logoUrl", logoUrl);
            var modifyBy = new SqlParameter("@modifyBy", BaseUtil.GetSessionValue(AdminInfo.LoginID.ToString()).ToString());
            var result = uow.sp_LoginUser_Result_.SQLQuery<int>("applyTheme_sp @logoUrl, @modifyBy", logoUrl_, modifyBy).FirstOrDefault();
            return result;
        }

        public string SelectLogo()
        {
            Int64 id = Convert.ToInt64(BaseUtil.GetSessionValue(AdminInfo.LoginID.ToString()));
            var re = uow.clientWebInformation_.Find(e => e.userId == id).Select(e => new { e.logoWebAddress }).FirstOrDefault();
            return re.logoWebAddress;
        }
    }
}