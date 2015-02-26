@Code
    ViewData("Title") = "Home Page"
    Layout = ""
    Dim contacts As AddressBook.ContactModel() = ViewData("Contacts")
    Dim addresses As AddressBook.AddressModel() = ViewData("Addresses")
    Dim phones As AddressBook.PhoneModel() = ViewData("Phones")
    Dim birthdays As AddressBook.ContactModel() = ViewData("Birthdays")
    Dim emails As AddressBook.EmailModel() = ViewData("Emails")
    
End Code

<!DOCTYPE html>
<html lang="en">
<head>
    <title>@ViewData("Title")</title>
    <meta name="viewport" content="width=device-width">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.2/css/bootstrap.min.css">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.2/css/bootstrap-theme.min.css">
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.2/js/bootstrap.min.js">
        
    </script>
    <style type="text/css">
        body {
            padding-top: 60px;
        }
    </style>
</head>
<body>    
    <div class="navbar navbar-fixed-top navbar-default">
        <div class="container-fluid">
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
                    <li><a style="cursor:pointer;" data-toggle="modal" data-target="#createContactModal">Add new contact</a></li>
                    <li><a style="cursor:pointer;" data-toggle="modal" data-target="#upcomingBirthdays">Upcoming Birthdays <span class="badge">@birthdays.Length</span></a></li>
                </ul>
                @Using Html.BeginForm("Search", "Contacts", New With {.ReturnUrl = ViewBag.ReturnUrl}, FormMethod.Post, New With {.class = "form-horizontal", .role = "form"})
                    
                     @<div class="navbar-form navbar-right">
                          <input placeholder="Search" type="text" class="form-control" id="searchText" name="searchText">

                          <button type="submit" class="btn btn-default">Submit</button>
                    </div>
                End Using    
                <ul class="nav navbar-nav navbar-right">
                </ul>

            </div>
        </div>
    </div>

    <div class="container-fluid">
        <div class="row">
            <div class="col-sm-3 col-md-2 sidebar" role="tabpanel">
                <ul class="nav nav-pills nav-stacked" id="pills">
                    @If contacts.Length = 0 Then
                        @<li>No contacts found</li>
                    Else
                        @For Each contact In contacts
                            @<li role="presentation"><a href="#@contact.Id" data-toggle="tab">@contact.FullName()</a></li>
                        Next
                    End If
                </ul>
            </div>
            <div class="main">
                <div class="tab-content" id="myTab">
                    @For Each contact In contacts
                        @<div class="tab-pane" id="@contact.Id">
                            <div class="media" style="padding-right:20px">
                                <div class="media-left">
                                    <a href="#">
                                        <img class="media-object" src="~/Images/default-avatar.png" height="200" width="200" alt="defult avatar">
                                    </a>
                                </div>
                                <div class="media-body">
                                    <div class="btn-group pull-right">
                                        <button type="button" class="btn btn-default dropdown-toggle" data-toggle="dropdown" aria-expanded="false">
                                            Actions <span class="caret"></span>
                                        </button>
                                        <ul class="dropdown-menu" role="menu">
                                            <li><a style="cursor:pointer;" data-toggle="modal" data-target="#Edit-@contact.Id">Edit</a></li>
                                            <li><a style="cursor:pointer;" data-toggle="modal" data-target="#Delete-@contact.Id">Delete</a></li>
                                            <li role="presentation" class="divider"></li>
                                            <li><a style="cursor:pointer;" data-toggle="modal" data-target="#AddAddress-@contact.Id.ToString()">Add Address</a></li>
                                            <li><a style="cursor:pointer;" data-toggle="modal" data-target="#AddPhone-@contact.Id.ToString()">Add Telephone</a></li>
                                        </ul>
                                    </div>
                                    <h4 class="media-heading">@contact.FullName</h4>
                                    <h5><strong>Birthday:</strong> @contact.Birthday.ToString("dd/MM/yyyy")</h5>                            
                                    <div class="col-sm-8" style="margin-left: -20px;">
                                        <table class="table">
                                            <thead>
                                                <tr>
                                                    <th>Telephones</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                @For Each phone In phones.ToList().FindAll(Function(p1) p1.ContactId = contact.Id).ToArray()
                                                @<tr>
                                                    <td>
                                                        <label class="col-sm-2"><strong>@phone.PhoneTypeId</strong></label>
                                                        <label data-toggle="tooltip" class="col-sm-2" style="font-weight:normal;">@phone.PhoneNum</label>
                                                        <label><a style="cursor:pointer;" data-toggle="modal" data-target="#DeletePhone-@phone.Id.ToString()"><span class="glyphicon glyphicon-minus-sign" aria-hidden="true"></span></a></label>
                                                    </td>
                                                </tr>
                                                 @Using Html.BeginForm("Delete", "Phones", New With {.ReturnUrl = ViewBag.ReturnUrl}, FormMethod.Post, New With {.class = "form-horizontal", .role = "form"})
                                                    @Html.AntiForgeryToken()
                                                    @<div class="modal" id="DeletePhone-@phone.Id.ToString()">
                                                    <div class="modal-dialog">
                                                        <div class="modal-content">
                                                            <div class="modal-header">
                                                                <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                                                <h4 class="modal-title">Delete Contact</h4>
                                                            </div>

                                                            <div class="modal-body">
                                                                <input type="hidden" name="Id" value="@phone.Id">
                                                                <h3>Are you sure you want to delete this phone?</h3>
                                                            </div>
                                                            <div class="modal-footer">
                                                                <button class="btn btn-danger" type="submit">Delete</button>
                                                                <button class="btn btn-default" data-dismiss="modal">Close</button>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                End Using
                                                Next
                                            </tbody>
                                        </table>

                                        

                                        @For Each address In addresses.ToList().FindAll(Function(p1) p1.ContactId = contact.Id).ToArray()
                                        @<table class="table">
                                            <thead>
                                                <tr>
                                                    <th>Address <a style="cursor:pointer;" data-toggle="modal" data-target="#DeleteAddress-@address.Id.ToString()"><span class="glyphicon glyphicon-minus-sign" aria-hidden="true"></span></a></th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <tr >
                                                    <td>
                                                        <label class="col-sm-2"><strong>Street</strong></label>
                                                        <label data-toggle="tooltip" class="col-sm-2" style="font-weight:normal;">@address.Street</label>
                                                        <label class="col-sm-2 col-sm-offset-4"><strong>House number</strong> </label>
                                                        <label data-toggle="tooltip" class="col-sm-2" style="font-weight:normal;">@address.HouseNum</label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <label class="col-sm-2"><strong>Town</strong></label>
                                                        <label data-toggle="tooltip" class="col-sm-2" style="font-weight:normal;">@address.Town</label>
                                                        <label class="col-sm-2 col-sm-offset-4"><strong>Post Code</strong> </label>
                                                        <label data-toggle="tooltip" class="col-sm-2" style="font-weight:normal;">@address.PostCode</label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <label class="col-sm-2"><strong>Country</strong></label>
                                                        <label data-toggle="tooltip" title="" class="col-sm-2" style="font-weight:normal;">@address.Country</label>
                                                    </td>        
                                                </tr>
                                            </tbody>
                                        </table>
                                        @Using Html.BeginForm("Delete", "Addresses", New With {.ReturnUrl = ViewBag.ReturnUrl}, FormMethod.Post, New With {.class = "form-horizontal", .role = "form"})
                                            @Html.AntiForgeryToken()
                                            @<div class="modal" id="DeleteAddress-@address.Id.ToString()">
                                            <div class="modal-dialog">
                                                <div class="modal-content">
                                                    <div class="modal-header">
                                                        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                                        <h4 class="modal-title">Delete address</h4>
                                                    </div>

                                                    <div class="modal-body">
                                                        <input type="hidden" name="Id" value="@address.Id()">
                                                        <h3>Are you sure you want to delete this address?</h3>
                                                    </div>
                                                    <div class="modal-footer">
                                                        <button class="btn btn-danger" type="submit">Delete</button>
                                                        <button class="btn btn-default" data-dismiss="modal">Close</button>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        End Using
                                    Next
                                    </div>
                                </div>
                            </div>
                        </div>
                        @Using Html.BeginForm("Create", "Addresses", New With {.ReturnUrl = ViewBag.ReturnUrl}, FormMethod.Post, New With {.class = "form-horizontal", .role = "form"})
                            @<div class="modal" id="AddAddress-@contact.Id.ToString()">
                                 <div class="modal-dialog">
                                     <div class="modal-content">
                                         <div class="modal-header">
                                             <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                             <h4 class="modal-title">Create Address</h4>
                                         </div>
                                         <div class="modal-body">
                                             <div class="form-group">
                                                 <input type="hidden" name="ContactId" value="@contact.Id">
                                                 <label for="name" class="col-sm-4 control-label">Street</label>
                                                 <div class="col-sm-6">
                                                     <input type="text" class="form-control" id="Street" name="Street">
                                                 </div>
                                                 <label for="HouseNum" class="col-sm-4 control-label">House Number</label>

                                                 <div class="col-sm-6">
                                                     <input type="text" class="form-control" id="HouseNum" name="HouseNum">
                                                 </div>
                                                 <label for="PostCode" class="col-sm-4 control-label">PostCode</label>

                                                 <div class="col-sm-6">
                                                     <input type="text" class="form-control" id="PostCode" name="PostCode">
                                                 </div>
                                                 <label for="Town" class="col-sm-4 control-label">Town</label>

                                                 <div class="col-sm-6">
                                                     <input type="text" class="form-control" id="Town" name="Town">
                                                 </div>
                                                 <label for="Country" class="col-sm-4 control-label">Country</label>

                                                 <div class="col-sm-6">
                                                     <input type="text" class="form-control" id="Country" name="Country">
                                                 </div>
                                             </div>
                                         </div>
                                         <div class="modal-footer">
                                             <button type="button" class="btn btn-default" data-dismiss="modal">Cancel</button>
                                             <button type="submit" class="btn btn-primary">Create</button>
                                         </div>
                                     </div>
                                 </div>
                            </div>
                            End Using
                            
                            @Using Html.BeginForm("Edit", "Contacts", New With {.ReturnUrl = ViewBag.ReturnUrl}, FormMethod.Post, New With {.class = "form-horizontal", .role = "form"})
                                @Html.AntiForgeryToken()
                                @<div class="modal" id="Edit-@contact.Id.ToString()">
                                    <div class="modal-dialog">
                                        <div class="modal-content">
                                            <div class="modal-header">
                                                <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                                <h4 class="modal-title">Edit Contact</h4>
                                            </div>
                                            <div class="modal-body">
                                                <div class="form-group">
                                                    <input type="hidden" name="Id" value="@contact.ID">
                                                    <label for="name" class="col-sm-4 control-label">Name</label>
                                                    <div class="col-sm-6">
                                                        <input type="text" class="form-control" id="name" value="@contact.Name" name="Name">
                                                    </div>
                                                    <label for="surname" class="col-sm-4 control-label">Surname</label>

                                                    <div class="col-sm-6">
                                                        <input type="text" class="form-control" id="surname" value="@contact.Surname" name="Surname">
                                                    </div>
                                                    <label for="birthday" class="col-sm-4 control-label">Birthday</label>

                                                    <div class="col-sm-6">
                                                        <input type="date" class="form-control" id="birthday" value="@contact.Birthday.ToString("dd/MM/yyyy")" name="Birthday">
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="modal-footer">
                                                <button type="button" class="btn btn-default" data-dismiss="modal">Cancel</button>
                                                <button type="submit" class="btn btn-primary">Edit</button>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            End Using

                            @Using Html.BeginForm("Delete", "Contacts", New With {.ReturnUrl = ViewBag.ReturnUrl}, FormMethod.Post, New With {.class = "form-horizontal", .role = "form"})
                                @Html.AntiForgeryToken()
                                @<div class="modal" id="Delete-@contact.Id.ToString()">
                                    <div class="modal-dialog">
                                        <div class="modal-content">
                                            <div class="modal-header">
                                                <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                                <h4 class="modal-title">Delete Contact</h4>
                                            </div> 
                                        <div class="modal-body">
                                            <input type="hidden" name="Id" value="@contact.Id()">
                                                <h3>Are you sure you want to delete this contact?</h3>
                                        </div>
                                        <div class="modal-footer">
                                            <button class="btn btn-danger" type="submit">Delete</button>
                                            <button class="btn btn-default" data-dismiss="modal">Close</button>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            End Using
                            
                            @Using Html.BeginForm("Create", "Phones", New With {.ReturnUrl = ViewBag.ReturnUrl}, FormMethod.Post, New With {.class = "form-horizontal", .role = "form"})
                                @Html.AntiForgeryToken()
                                @<div class="modal" id="AddPhone-@contact.Id.ToString()">
                                    <div class="modal-dialog">
                                        <div class="modal-content">
                                            <div class="modal-header">
                                                <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                                <h4 class="modal-title">Add Phone</h4>
                                            </div>   
                                            <div class="modal-body">
                                                <div class="form-group">
                                                    <input type="hidden" name="ContactId" value="@contact.ID">
                                                    <label for="PhoneNum" class="col-sm-4 control-label">Number</label>
                                                    <div class="col-sm-6">
                                                        <input type="text" class="form-control" id="PhoneNum" name="PhoneNum">
                                                    </div>
                                                    <label for="PhoneTypeId" class="col-sm-4 control-label">Type</label>

                                                    <div class="col-sm-6">
                                                        <select name="PhoneTypeId" class="form-control" id="PhoneTypeId">
                                                            <!--Here should be a loop for all types-->
                                                            <option value="Mobile" data-toggle="tooltip" title="Mobile">Mobile</option>
                                                            <option value="Home" data-toggle="tooltip" title="Home">Home</option>
                                                            <option value="Fax" data-toggle="tooltip" title="Fax">Fax</option>
                                                        </select>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="modal-footer">
                                                <button class="btn btn-primary" type="submit">Add</button>
                                                <button class="btn btn-default" data-dismiss="modal">Close</button>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            End Using
                    Next
                </div>
            </div>
        </div>
    </div>

    @Using Html.BeginForm("Create", "Contacts", New With {.ReturnUrl = ViewBag.ReturnUrl}, FormMethod.Post, New With {.class = "form-horizontal", .role = "form"})
    @Html.AntiForgeryToken()
    @<div class="modal" id="createContactModal">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <h4 class="modal-title">Create Contact</h4>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <label for="name" class="col-sm-4 control-label">Name</label>
                        <div class="col-sm-6">
                            <input type="text" class="form-control" id="name" name="Name">
                        </div>
                        <label for="surname" class="col-sm-4 control-label">Surname</label>

                        <div class="col-sm-6">
                            <input type="text" class="form-control" id="surname" name="Surname">
                        </div>
                        <label for="birthday" class="col-sm-4 control-label">Birthday</label>

                        <div class="col-sm-6">
                            <input type="date" class="form-control" id="birthday" name="Birthday">
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Cancel</button>
                    <button type="submit" class="btn btn-primary">Create</button>
                </div>
            </div>
        </div>
    </div>
    End Using

    
    <div class="modal fade" id="upcomingBirthdays">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <h4 class="modal-title">Upcoming birthdays</h4>
                </div>
                
                <div class="modal-body">
                    @If contacts.Length < 1 Then
                        @<h4>No birthdays in the following 5 days</h4>
                    End If
                       
                    @For Each contact In birthdays
                        @<h3>@contact.FullName &thinsp; &thinsp; @contact.Birthday.ToString("dd/MM/yyyy")</h3>
                    Next
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                </div>
            </div><!-- /.modal-content -->
        </div><!-- /.modal-dialog -->
    </div><!-- /.modal -->

    <div class="navbar navbar-default navbar-fixed-bottom">
        <div class="container">
            <p class="navbar-text">Andreas Neofytou &copy; @DateTime.Now.Year </p>
        </div>
    </div>

    @Scripts.Render("~/bundles/jquery")
    @Scripts.Render("~/bundles/bootstrap")
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.2/jquery.min.js"></script>
    <script src="~/Scripts/bootstrap.min.js"></script>
    <script>
        $(document).ready(function () {
            var hash = window.location.hash;
            $('#pills a[href= "' + hash + '" ]').tab('show') // Select tab by name
        });
    </script>
</body>
</html>
