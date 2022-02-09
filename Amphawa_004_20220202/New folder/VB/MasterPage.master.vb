Imports System.Globalization

Partial Class MasterPage
    Inherits System.Web.UI.MasterPage
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            If ddlLanguages.Items.FindByValue(CultureInfo.CurrentCulture.Name) IsNot Nothing Then
                ddlLanguages.Items.FindByValue(CultureInfo.CurrentCulture.Name).Selected = True
            End If
        End If
    End Sub
End Class

