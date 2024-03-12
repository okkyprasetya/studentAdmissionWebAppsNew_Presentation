Imports studentAdmissionBLL
Imports studentAdmissionDTO

Public Class Register
    Inherits System.Web.UI.Page

    Dim _applicantBLL As New studentAdmissionBLL.ApplicantBLL
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Register_Click(sender As Object, e As EventArgs)
        Dim _newApplicantBLL As New studentAdmissionBLL.ApplicantBLL
        Dim _newApplicant As New UserCreateDTO
        _newApplicant.email = txtemail.Text
        _newApplicant.password = txtpassword.Text
        _newApplicant.fname = txtfirstName.Text
        _newApplicant.midname = txtmiddleName.Text
        _newApplicant.lname = txtlastName.Text

        Try
            _newApplicantBLL.register(_newApplicant)
            ' If no exception is thrown, registration is successful
            ltMessage.Text = "<span class='alert alert-success'>User added successfully, we will direct you to login page in 3 seconds</span><br/><br/>"
            Response.AddHeader("REFRESH", "3;URL=Login.aspx")
        Catch ex As Exception
            ' If an exception occurs during registration, it failed
            ltMessage.Text = "<span class='alert alert-danger'>Registration failed. Please try again.</span><br/><br/>"
        End Try

    End Sub
End Class