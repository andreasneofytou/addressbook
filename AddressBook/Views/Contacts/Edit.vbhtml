@ModelType AddressBook.ContactModel

@Code
    ViewData("Title") = "Edit"
End Code

<h2>Edit</h2>

@Using Html.BeginForm()
    @Html.AntiForgeryToken()
    @Html.ValidationSummary(True)

    @<fieldset>
        <legend>ContactModel</legend>

        @Html.HiddenFor(Function(model) model.Id)

        <div class="editor-label">
            @Html.LabelFor(Function(model) model.Name)
        </div>
        <div class="editor-field">
            @Html.EditorFor(Function(model) model.Name)
            @Html.ValidationMessageFor(Function(model) model.Name)
        </div>

        <div class="editor-label">
            @Html.LabelFor(Function(model) model.Surname)
        </div>
        <div class="editor-field">
            @Html.EditorFor(Function(model) model.Surname)
            @Html.ValidationMessageFor(Function(model) model.Surname)
        </div>

        <div class="editor-label">
            @Html.LabelFor(Function(model) model.Birthday)
        </div>
        <div class="editor-field">
            @Html.EditorFor(Function(model) model.Birthday)
            @Html.ValidationMessageFor(Function(model) model.Birthday)
        </div>

        <p>
            <input type="submit" value="Save" />
        </p>
    </fieldset>
End Using

<div>
    @Html.ActionLink("Back to List", "Index")
</div>

@Section Scripts
    @Scripts.Render("~/bundles/jqueryval")
End Section
