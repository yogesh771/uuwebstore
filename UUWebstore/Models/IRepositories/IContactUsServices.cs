﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UUWebstore.Models.IRepositories
{
   public interface IContactUsServices
    {
        int SaveContactUs(ContactU oContact);
        List<ContactU> GetAllContacts();
    }
}