using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rimango.Groups.ViewModels
{
    public class PersonViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Function { get; set; }
        public bool DisplayNameOnly { get; set; }
        public int OrderNumber { get; set; }
    }
}