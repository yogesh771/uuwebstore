﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UUWebstore.Models.IRepositories
{
    public interface ICountryServices
    {
        List<country> getAllCountries();
    }
}
