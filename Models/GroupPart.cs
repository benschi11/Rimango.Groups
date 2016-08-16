using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Records;
using Orchard.ContentManagement.Utilities;

namespace Rimango.Groups.Models
{
    public class PersonGroupRecord
    {
        public virtual ContentItemRecord Person { get; set; }
        public virtual ContentItemRecord Group { get; set; }
        public virtual string Function { get; set; }
        public virtual bool DisplayNameOnly { get; set; }
        public virtual int OrderNumber { get; set; }
    }

    public class GroupPart : ContentPart {

    }
}