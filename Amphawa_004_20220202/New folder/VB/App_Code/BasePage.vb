Imports System.Threading
Imports System.Globalization

Public Class BasePage
    Inherits System.Web.UI.Page
    Protected Overrides Sub InitializeCulture()
        Dim language As String = "en-us"

        'Detect User's Language.
        If Request.UserLanguages IsNot Nothing Then
            'Set the Language.
            language = Request.UserLanguages(0)
        End If

        'Check if PostBack is caused by Language DropDownList.
        If Request.Form("__EVENTTARGET") IsNot Nothing AndAlso Request.Form("__EVENTTARGET").Contains("ddlLanguages") Then
            'Set the Language.
            language = Request.Form(Request.Form("__EVENTTARGET"))
        End If

        'Set the Culture.
        Thread.CurrentThread.CurrentCulture = New CultureInfo(language)
        Thread.CurrentThread.CurrentUICulture = New CultureInfo(language)
    End Sub
End Class
