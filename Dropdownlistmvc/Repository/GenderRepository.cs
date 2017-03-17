using Dropdownlistmvc.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dropdownlistmvc.Data;

namespace Dropdownlistmvc.Repository
{
    public class GenderRepository : IGender
    {
        EFDbContext context = new EFDbContext();
        public IEnumerable<Gender> GetGenders
        {
            get
            {

                return context.Genders;

            }
        }
    }
}