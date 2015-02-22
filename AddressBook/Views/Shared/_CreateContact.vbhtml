<div class="modal fade" id="createContactModel" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
    <style type="text/css">
        body.modal-open,
        .modal-open .navbar-fixed-top,
        .modal-open .navbar-fixed-bottom {
            margin-right: 0px;
        }
    </style>
    @Using Html.BeginForm()
    @Html.AntiForgeryToken()
    @Html.ValidationSummary(True)

    @<fieldset>
        <legend>ContactModel</legend>

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
            <input type="submit" value="Create" />
        </p>
    </fieldset>
    End Using
        
</div>
