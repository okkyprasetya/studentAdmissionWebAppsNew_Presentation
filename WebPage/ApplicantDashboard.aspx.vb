Imports studentAdmissionBLL
Imports studentAdmissionDTO
Imports studentAdmissionDTO.ApplicantDTO
Imports WebPage.WebForm2

Public Class ApplicantDashboard
    Inherits System.Web.UI.Page
    Private _applicantBLL As New ApplicantBLL()
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim email As String = CType(Session("LoggedUserData"), String)
            If email IsNot Nothing Then
                Dim applicantData As UsersDTO = _applicantBLL.getUserByEmail(email)
                lblName.InnerText = applicantData.FirstName & " " & applicantData.MiddleName & " " & applicantData.LastName
                txtemail.Text = applicantData.UserEmail
                txtfirstName.Text = applicantData.FirstName
                txtmiddleName.Text = applicantData.MiddleName
                txtlastName.Text = applicantData.LastName
                If applicantData.RoleID = 1 Then
                    lblRole.InnerText = "Verificator"
                ElseIf applicantData.RoleID = 2 Then
                    lblRole.InnerText = "Applicant"
                Else
                    lblRole.InnerText = "Unknown"
                End If

            Else
                Response.Redirect("Login.aspx")
            End If
        End If
    End Sub

    Private Sub SetFieldsEditMode(ByVal isEditMode As Boolean)
        txtfirstName.ReadOnly = Not isEditMode
        txtmiddleName.ReadOnly = Not isEditMode
        txtlastName.ReadOnly = Not isEditMode
        txtemail.ReadOnly = Not isEditMode
        btnSaveAboutMe.Visible = isEditMode
        btnEditAboutMe.Visible = Not isEditMode
    End Sub

    Protected Sub btnEditAboutMe_Click(sender As Object, e As EventArgs)
        SetFieldsEditMode(True)
    End Sub

    Protected Sub btnSaveAboutMe_Click(sender As Object, e As EventArgs)
        SetFieldsEditMode(False)
    End Sub

    Protected Sub SaveAcademicData_Click(sender As Object, e As EventArgs)

    End Sub

    Protected Sub EditAcademicData_Click(sender As Object, e As EventArgs)

    End Sub

    Protected Sub GeneralDataEdit_Click(sender As Object, e As EventArgs)

    End Sub

    Protected Sub GeneralDataSave_Click(sender As Object, e As EventArgs)

    End Sub

    Protected Sub btnLogout_Click(sender As Object, e As EventArgs)
        FormsAuthentication.SignOut()
        Session.Clear()
        Session.Abandon()

        ' Redirect to login page
        Response.Redirect("~/Login.aspx")
    End Sub
End Class