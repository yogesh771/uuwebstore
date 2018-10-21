using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UUWebstore.Models;

namespace UUWebstore.Models.Repositories
{
    public class UnitOfWork : IDisposable
    {
        private readonly sbv_uuwebstoreEntities db;


        public UnitOfWork()
        {
            db = new sbv_uuwebstoreEntities();
        }
        private Repositories<sp_LoginUser_Result> _sp_LoginUser_Result { get; set; }
        public Repositories<sp_LoginUser_Result> sp_LoginUser_Result_
        {
            get
            {
                if (this._sp_LoginUser_Result == null)
                    this._sp_LoginUser_Result = new Repositories<sp_LoginUser_Result>(db);
                return _sp_LoginUser_Result;
            }
        }

        public Repositories<AppErrorLog> _AppErrorLog { get; set; }
        public Repositories<AppErrorLog> AppErrorLog_
        {
            get
            {
                if (this._AppErrorLog == null)
                    this._AppErrorLog = new Repositories<AppErrorLog>(db);
                return _AppErrorLog;
            }
        }

        private Repositories<user> _user { get; set; }
        public Repositories<user> user_
        {
            get
            {
                if (this._user == null)
                    this._user = new Repositories<user>(db);
                return _user;
            }
        }

        private Repositories<roleUser> _roleUser { get; set; }
        public Repositories<roleUser> roleUser_
        {
            get
            {
                if (this._roleUser == null)
                    this._roleUser = new Repositories<roleUser>(db);
                return _roleUser;
            }
        }



        private Repositories<country> _country { get; set; }
        public Repositories<country> country_
        {
            get
            {
                if (this._country == null)
                    this._country = new Repositories<country>(db);
                return _country;
            }
        }
        private Repositories<state> _state { get; set; }
        public Repositories<state> state_
        {
            get
            {
                if (this._state == null)
                    this._state = new Repositories<state>(db);
                return _state;
            }
        }
        private Repositories<city> _city { get; set; }
        public Repositories<city> city_
        {
            get
            {
                if (this._city == null)
                    this._city = new Repositories<city>(db);
                return _city;
            }
        }
        private Repositories<theme> _theme { get; set; }
        public Repositories<theme> theme_
        {
            get
            {
                if (this._theme == null)
                    this._theme = new Repositories<theme>(db);
                return _theme;
            }
        }
        private Repositories<Models.clientWebInformation> _clientWebInformation { get; set; }
        public Repositories<Models.clientWebInformation> clientWebInformation_
        {
            get
            {
                if (this._clientWebInformation == null)
                    this._clientWebInformation = new Repositories<Models.clientWebInformation>(db);
                return _clientWebInformation;
            }
        }
        public void Dispose()
        {
           // _context.Dispose();
        }
    }
}