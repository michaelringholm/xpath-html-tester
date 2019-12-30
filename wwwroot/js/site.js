$(function () {
    console.log("JQuery initialized!");
    var xpathParser = new XPathParser();
    $("#xpathExpr").keypress(function (event) {
        if (event.which == 13) {
            xpathParser.Parse();
        }
    });

});

function XPathParser() {
    var _this = this;
    this.Parse = function () {
        console.log("Parsing...");
        var data = { 
            html : $("#html").text(), 
            xpathExpr: $("#xpathExpr").val() 
        };
        
        $.ajax({
            type: "POST",
            url: "/api/xpath/parse",
            data: JSON.stringify(data),
            success: function(result) {
                console.log("success");
                $("#matchingNodes").text("");
                result.nodes.forEach(function(item, index) {
                   $("#matchingNodes").append(item.innerHtml + "\n"); //.replace(/[\\r\\n]/g, "<br>"));
                });
            },
            contentType: "application/json"
        });
    };
}