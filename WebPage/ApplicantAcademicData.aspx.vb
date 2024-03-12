Imports studentAdmissionBLL
Imports studentAdmissionDTO
Imports studentAdmissionDTO.ApplicantDTO

Public Class ApplicantAcademicData
    Inherits System.Web.UI.Page
    Private _applicantBLL As New ApplicantBLL()
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Dim email As String = CType(Session("LoggedUserData"), String)
        Dim email As String = CType(Session("LoggedUserData"), String)
        If Not IsPostBack Then
            If email IsNot Nothing Then
                Dim applicantData As UsersDTO = _applicantBLL.getUserByEmail(email)
                Dim applicantAcData As AcademicDataDTO = _applicantBLL.getAcademicData(email)
                lblName.InnerText = applicantData.FirstName & " " & applicantData.MiddleName & " " & applicantData.LastName
                txtRaportSum.Text = applicantAcData.RaportSUmmaries
                If applicantAcData.RaportSummaries = 0 Then
                    txtRaportSum.Text = "Input your raport summaries value"
                Else
                    txtRaportSum.Text = applicantAcData.RaportSUmmaries
                End If
                txtRaportDocument.Text = applicantAcData.RaportDocument
                If applicantAcData.isVerified = True Then
                    litStatus.Text = "Verified"
                Else
                    litStatus.Text = "Not Verified"
                End If
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

    Protected Sub btnSaveAboutMe_Click(sender As Object, e As EventArgs)
        txtRaportSum.ReadOnly = True
        txtRaportDocument.ReadOnly = True
        btnSaveAboutMe.Visible = False
        btnEditAboutMe.Visible = True

        Dim email As String = CType(Session("LoggedUserData"), String)
        Dim applicantData As ApplicantsDTO = _applicantBLL.getApplicantData(email)
        Dim applicantAcData As AcademicDataDTO = _applicantBLL.getAcademicData(email)
        Dim updatedData As UpdateAcademicDataDTO = New UpdateAcademicDataDTO
        updatedData.UADataID = applicantAcData.UADataID
        updatedData.UGDataID = applicantData.UGDataID
        updatedData.RaportSummaries = txtRaportSum.Text
        updatedData.RaportDocument = txtRaportDocument.Text
        If applicantAcData.UADataID <> 0 Then
            Try
                _applicantBLL.updateApplicantAcademicData(updatedData)

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
                _applicantBLL.completeApplicantAcademicData(updatedData)

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

    End Sub

    Protected Sub btnEditAboutMe_Click(sender As Object, e As EventArgs)
        txtRaportSum.ReadOnly = False
        txtRaportDocument.ReadOnly = False
        statusFormGroup.Visible = False
        btnSaveAboutMe.Visible = True
        btnEditAboutMe.Visible = False
    End Sub

    Protected Sub btnLogout_Click(sender As Object, e As EventArgs)
        FormsAuthentication.SignOut()
        Session.Clear()
        Session.Abandon()

        ' Redirect to login page
        Response.Redirect("~/Login.aspx")
    End Sub
End Class