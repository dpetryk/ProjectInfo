using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjectInfo.Models
{
    public class Attachment
    {
        public HttpPostedFileBase File { get; set; }
    }
}