Public Class HomeController
    Inherits System.Web.Mvc.Controller

    Function Index() As ActionResult
        Dim contacts As ContactModel() = ContactsController.GetAllContacts()
        ViewData("Contacts") = contacts
        ViewData("Addresses") = AddressesController.GetAddresses(contacts)
        ViewData("Phones") = PhonesController.GetPhones(contacts)
        ViewData("Birthdays") = ContactsController.GetUpcomingBirthdays(contacts)
        ViewData("Emails") = EmailsController.GetEmails(contacts)
        Return View()
    End Function

    Function About() As ActionResult
        ViewData("Message") = "Your app description page."

        Return View()
    End Function

End Class
