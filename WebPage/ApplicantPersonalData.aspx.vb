Imports studentAdmissionBLL
Imports studentAdmissionDTO
Imports studentAdmissionDTO.ApplicantDTO

Public Class ApplicantPersonalData
    Inherits System.Web.UI.Page
    Private _applicantBLL As New ApplicantBLL()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim email As String = CType(Session("LoggedUserData"), String)
        If Not IsPostBack Then
            If email IsNot Nothing Then
                Dim applicantData As UsersDTO = _applicantBLL.getUserByEmail(email)
                Dim applicantPData As PersonalDataDTO = _applicantBLL.getPersonalData(email)
                'users name definition
                lblName.InnerText = applicantData.FirstName & " " & applicantData.MiddleName & " " & applicantData.LastName

                'role definition
                If applicantData.RoleID = 1 Then
                    lblRole.InnerText = "Verificator"
                ElseIf applicantData.RoleID = 2 Then
                    lblRole.InnerText = "Applicant"
                Else
                    lblRole.InnerText = "Unknown"
                End If

                'status definition
                If applicantPData.isVerified = True Then
                    litStatus.Text = "Verified"
                Else
                    litStatus.Text = "Not Verified"
                End If

                'filling the textbox
                txtFatherName.Text = applicantPData.FatherName
                txtFatherAddress.Text = applicantPData.FatherAddress
                txtFatherJob.Text = applicantPData.FatherJob
                txtFatherSalary.Text = applicantPData.FatherSalary

                txtMotherName.Text = applicantPData.MotherName
                txtMotherAddress.Text = applicantPData.MotherAddress
                txtMotherJob.Text = applicantPData.MotherJob
                txtMotherSalary.Text = applicantPData.MotherSalary

                txtSiblingNumber.Text = applicantPData.SiblingsNumber
                txtHobby.Text = applicantPData.Hobi
                txtKKDocument.Text = applicantPData.KKDocument
                txtBirthDocument.Text = applicantPData.BirthDocument

            Else
                Response.Redirect("Login.aspx")

            End If
        End If
    End Sub

    Protected Sub btnLogout_Click(sender As Object, e As EventArgs)
        FormsAuthentication.SignOut()
        Session.Clear()
        Session.Abandon()

        ' Redirect to login page
        Response.Redirect("~/Login.aspx")
    End Sub

    Protected Sub btnEditAboutMe_Click(sender As Object, e As EventArgs)
        txtFatherName.ReadOnly = False
        txtFatherAddress.ReadOnly = False
        txtFatherJob.ReadOnly = False
        txtFatherSalary.ReadOnly = False
        txtMotherName.ReadOnly = False
        txtMotherAddress.ReadOnly = False
        txtMotherJob.ReadOnly = False
        txtMotherSalary.ReadOnly = False
        txtSiblingNumber.ReadOnly = False
        txtHobby.ReadOnly = False
        txtKKDocument.ReadOnly = False
        txtBirthDocument.ReadOnly = False

        statusFormGroup.Visible = False
        btnSaveAboutMe.Visible = True
        btnEditAboutMe.Visible = False
    End Sub

    Protected Sub btnSaveAboutMe_Click(sender As Object, e As EventArgs)
        txtFatherName.ReadOnly = True
        txtFatherAddress.ReadOnly = True
        txtFatherJob.ReadOnly = True
        txtFatherSalary.ReadOnly = True
        txtMotherName.ReadOnly = True
        txtMotherAddress.ReadOnly = True
        txtMotherJob.ReadOnly = True
        txtMotherSalary.ReadOnly = True
        txtSiblingNumber.ReadOnly = True
        txtHobby.ReadOnly = True
        txtKKDocument.ReadOnly = True
        txtBirthDocument.ReadOnly = True

        'LOGIC UPDATE/COMPLETE
        Dim email As String = CType(Session("LoggedUserData"), String)
        Dim applicantPData As PersonalDataDTO = _applicantBLL.getPersonalData(email)
        Dim applicantData As ApplicantsDTO = _applicantBLL.getApplicantData(email)
        Dim updatedData As UpdatePersonalDataDTO = New UpdatePersonalDataDTO
        updatedData.FatherName = txtFatherName.Text
        updatedData.FatherAddress = txtFatherAddress.Text
        updatedData.FatherJob = txtFatherJob.Text
        updatedData.FatherSalary = txtFatherSalary.Text
        updatedData.MotherName = txtMotherName.Text
        updatedData.MotherAddress = txtMotherAddress.Text
        updatedData.MotherJob = txtMotherJob.Text
        updatedData.MotherSalary = txtMotherSalary.Text
        updatedData.SiblingNumber = txtSiblingNumber.Text
        updatedData.Hobi = txtHobby.Text
        updatedData.KKDocument = txtKKDocument.Text
        updatedData.BirthDocument = txtBirthDocument.Text
        updatedData.UPDataID = applicantPData.UPDataID
        updatedData.UGDataID = applicantData.UGDataID
        If applicantPData.UPDataID <> 0 Then
            Try
                _applicantBLL.updateApplicantPersonalData(updatedData)

                alertPlaceholder.InnerHtml = "<div class='alert alert-success alert-dismissible fade show' role='alert'>" &
                                          "Data updated successfully." &
                                          "<button type='button' class='close' data-dismiss='alert' aria-label='Close'>" &
                                          "<span aria-hidden='true'>&times;</span>" &
                                          "</button></div>"
            Catch ex As Exception
                Dim errorMessage As String = "Failed to update data. Error: " & ex.Message
                alertPlaceholder.InnerHtml = "<div class='alert alert-danger alert-dismissible fade show' role='alert'>" &
                                      errorMessage &
                                      "<button type='button' class='close' data-dismiss='alert' aria-label='Close'>" &
                                      "<span aria-hidden='true'>&times;</span>" &
                                      "</button></div>"
            End Try
        Else
            Try
                ' Call the BLL method
                _applicantBLL.completeApplicantPersonalData(updatedData)

                ' Display success message using Bootstrap alert
                alertPlaceholder.InnerHtml = "<div class='alert alert-success alert-dismissible fade show' role='alert'>" &
                                          "Data updated successfully." &
                                          "<button type='button' class='close' data-dismiss='alert' aria-label='Close'>" &
                                          "<span aria-hidden='true'>&times;</span>" &
                                          "</button></div>"
            Catch ex As Exception
                ' Display error message using Bootstrap alert
                Dim errorMessage As String = "Failed to update data. Error: " & ex.Message
                alertPlaceholder.InnerHtml = "<div class='alert alert-danger alert-dismissible fade show' role='alert'>" &
                                      errorMessage &
                                      "<button type='button' class='close' data-dismiss='alert' aria-label='Close'>" &
                                      "<span aria-hidden='true'>&times;</span>" &
                                      "</button></div>"
            End Try
        End If

        btnSaveAboutMe.Visible = False
        btnEditAboutMe.Visible = True
    End Sub
End Class