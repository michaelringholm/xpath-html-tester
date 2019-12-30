using System;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

[ApiController]
[Route("/api/xpath")]
public class XPathController {

    [HttpPost]
    [Route("parse")]
    public Object Parse(ParserInputModel inputModel) {
        var parser = new HtmlXPathParser();
        var nodes = parser.Parse(inputModel);
        return new { Status="Success", nodes=nodes };
    }
}