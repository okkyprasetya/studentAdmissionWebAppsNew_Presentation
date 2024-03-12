Imports Microsoft.Ajax.Utilities
Imports studentAdmissionBLL
Imports studentAdmissionDTO
Imports studentAdmissionDTO.ApplicantDTO

Public Class WebForm2
    Inherits System.Web.UI.Page

    Private _applicantBLL As New ApplicantBLL()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub loginButton_Click(sender As Object, e As EventArgs)
        Dim email As String = txtEmail.Text
        Dim password As String = txtPassword.Text
        Dim loginStatus As String = _applicantBLL.login(email, password)
        Select Case loginStatus
            Case "Login successful"
                ' Redirect user to dashboard or home page
                Dim applicant As UsersDTO = _applicantBLL.getUserByEmail(email)
                If applicant IsNot Nothing Then
                    Session("LoggedUserData") = email
                    ltMessage.Text = "<span class='alert alert-success'>Login Success. Redirecting...</span><br/><br/>"
                    Response.Redirect("ApplicantDashboard.aspx")
                End If
            Case "Incorrect password"
                ' Display error message for incorrect password
                ' You can use a label control or display a JavaScript alert
                ltMessage.Text = "<span class='alert alert-danger'>Incorrect Password. Please try again.</span><br/><br/>"
            Case "Email not found"
                ' Display error message for email not found
                ' You can use a label control or display a JavaScript alert
                ltMessage.Text = "<span class='alert alert-danger'>Email not found. Please try again.</span><br/><br/>"
            Case Else
                ' Handle unexpected status
        End Select

    End Sub
End Class