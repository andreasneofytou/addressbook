@ModelType AddressBook.ContactModel

@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

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
<p>

    @Html.ActionLink("Edit", "Edit", New With {.id = Model.Id}) |
    @Html.ActionLink("Back to List", "Index")
</p>
