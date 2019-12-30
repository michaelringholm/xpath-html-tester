using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IO;

namespace opusmagus.web.xpath.Pages
{
    public class IndexModel : PageModel
    {
        public string SampleHtml { get; set; }

        public void OnGet()
        {
            SampleHtml = System.IO.File.ReadAllText(Path.GetFullPath("./data/html/sample.html"));
        }
    }
}
