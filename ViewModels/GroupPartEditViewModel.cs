using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rimango.Groups.ViewModels
{
    public class GroupPartEditViewModel
    {
        public IList<PersonViewModel> PersonsInGroup { get; set; }

        public IList<PersonViewModel> AllPersons { get; set; }
    }
}