using System;
using System.Collections.Generic;
using HtmlAgilityPack;

internal class HtmlXPathParser
{
    public HtmlXPathParser()
    {        
    }

    internal List<SimpleNode> Parse(ParserInputModel inputModel)
    {
        var htmlDoc = new HtmlDocument();
        htmlDoc.LoadHtml(inputModel.Html);      
        var simpleNodeList = new List<SimpleNode>();

        try {
            var nodes = htmlDoc.DocumentNode.SelectNodes(inputModel.XPathExpr);        
            foreach(var node in nodes)
                simpleNodeList.Add(new SimpleNode { InnerHtml = node.InnerHtml, Line = node.Line, LinePosition = node.LinePosition });
        }
        catch(Exception ex) {
            simpleNodeList.Add(new SimpleNode { InnerHtml = ex.Message });
        }
        return simpleNodeList;
    }
}