@ModelType IEnumerable(Of AddressBook.ContactModel)

@Code
    ViewData("Title") = "Index"
End Code

<h2>Index</h2>

<p>
    @Html.ActionLink("Create New", "Create")
</p>
<table>
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.Name)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Surname)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Birthday)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.FullName)
        </th>
        <th></th>
    </tr>

@For Each item In Model
    Dim currentItem = item
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) currentItem.Name)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) currentItem.Surname)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) currentItem.Birthday)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) currentItem.FullName)
        </td>
        <td>
            @Html.ActionLink("Edit", "Edit", New With {.id = currentItem.Id}) |
            @Html.ActionLink("Details", "Details", New With {.id = currentItem.Id}) |
            @Html.ActionLink("Delete", "Delete", New With {.id = currentItem.Id})
        </td>
    </tr>
Next

</table>
