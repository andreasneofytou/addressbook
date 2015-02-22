<!DOCTYPE html>
<html lang="en">
<head>
    <title>@ViewData("Title") - My ASP.NET MVC Application</title>
    <meta name="viewport" content="width=device-width">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.2/css/bootstrap.min.css">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.2/css/bootstrap-theme.min.css">
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.2/js/bootstrap.min.js"></script>   
</head>
<body>
    <div class="navbar navbar-fixed-top navbar-default">
        <div class="container">
            <div class="navbar-header">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                @Html.ActionLink("Contacts", "Index", "Home", Nothing, New With {.class = "navbar-brand"})
            </div>
            <div class="navbar-collapse collapse">
                <ul class="nav navbar-nav">
                    <li><a style="cursor:pointer;" data-toggle="modal" data-target="#createContactModel">New</a></li>
                    <li><a href="#">Edit</a></li>
                    <li><a href="#">Delete</a></li>
                    <li></li>
                </ul>
                <ul class="nav navbar-nav navbar-right">
                    <li><a href="#">About</a></li>
                </ul>
            </div>
        </div>
    </div>

    <div class="modal fade" id="createContactModel" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <style type="text/css">
            body.modal-open,
            .modal-open .navbar-fixed-top,
            .modal-open .navbar-fixed-bottom {
                margin-right: 0px;
            }
        </style>
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <h4 class="modal-title">Modal title</h4>
                </div>
                <div class="modal-body">
                    <p>One fine body&hellip;</p>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                    <button type="button" class="btn btn-primary">Save changes</button>
                </div>
            </div><!-- /.modal-content -->
        </div><!-- /.modal-dialog -->
    </div><!-- /.modal -->

    <div id="body">
                    @RenderSection("featured", required:=False)
        <section class="content-wrapper main-content clear-fix">
                    @RenderBody()
        </section>
    </div>
    <div class="navbar navbar-default navbar-fixed-bottom">
        <div class="container">
            <p class="navbar-text">Andreas Neofytou &copy; @DateTime.Now.Year </p>
        </div>
    </div>

    

    @Scripts.Render("~/bundles/jquery")
    @Scripts.Render("~/bundles/bootstrap")
    @RenderSection("scripts", required:=False)
</body>
</html>
