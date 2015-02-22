@ModelType AddressBook.ContactModel

@Code
    ViewData("Title") = "Delete"
End Code

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
<fieldset>
    <legend>ContactModel</legend>

    <div class="display-label">
        @Html.DisplayNameFor(Function(model) model.Name)
    </div>
    <div class="display-field">
        @Html.DisplayFor(Function(model) model.Name)
    </div>

    <div class="display-label">
        @Html.DisplayNameFor(Function(model) model.Surname)
    </div>
    <div class="display-field">
        @Html.DisplayFor(Function(model) model.Surname)
    </div>

    <div class="display-label">
        @Html.DisplayNameFor(Function(model) model.Birthday)
    </div>
    <div class="display-field">
        @Html.DisplayFor(Function(model) model.Birthday)
    </div>

    <div class="display-label">
        @Html.DisplayNameFor(Function(model) model.FullName)
    </div>
    <div class="display-field">
        @Html.DisplayFor(Function(model) model.FullName)
    </div>
</fieldset>
@Using Html.BeginForm()
    @Html.AntiForgeryToken()
    @<p>
        <input type="submit" value="Delete" /> |
        @Html.ActionLink("Back to List", "Index")
    </p>
End Using
