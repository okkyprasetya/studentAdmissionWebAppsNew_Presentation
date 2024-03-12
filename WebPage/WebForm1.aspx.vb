Imports studentAdmissionBLL

Public Class WebForm1
    Inherits System.Web.UI.Page
    Dim _applicantBLL As New studentAdmissionBLL.ApplicantBLL

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Public Function lvUser_GetData() As IQueryable(Of studentAdmissionDTO.UsersDTO)
        Dim results = _applicantBLL.getAll()
        Return results
    End Function

End Class