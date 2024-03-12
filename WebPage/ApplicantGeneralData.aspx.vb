Imports Microsoft.Ajax.Utilities
Imports studentAdmissionBLL
Imports studentAdmissionDTO
Imports studentAdmissionDTO.ApplicantDTO

Public Class ApplicantGeneralData
    Inherits System.Web.UI.Page
    Private _applicantBLL As New ApplicantBLL()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim email As String = CType(Session("LoggedUserData"), String)
        If Not IsPostBack Then
            If ViewState("UpdatedNIS") IsNot Nothing Then
                txtNIS.Text = ViewState("UpdatedNIS").ToString()
                txtDateBirth.Text = ViewState("UpdatedDateBirth").ToString()
                ddlIsScholarship.SelectedValue = ViewState("UpdatedIsScholarship").ToString()
                ddlScholarship.SelectedValue = ViewState("UpdatedScholarshipID").ToString()
            Else
                If email IsNot Nothing Then
                    Dim applicantData As UsersDTO = _applicantBLL.getUserByEmail(email)
                    Dim applicantGenData As ApplicantsDTO = _applicantBLL.getApplicantData(email)
                    lblName.InnerText = applicantData.FirstName & " " & applicantData.MiddleName & " " & applicantData.LastName
                    txtNIS.Text = applicantGenData.NIS
                    txtDateBirth.Text = applicantGenData.DateBirth

                    ddlScholarship.SelectedValue = applicantGenData.ScholarshipID


                    If applicantGenData.ScholarshipID = 0 Then
                        ddlScholarship.SelectedValue = ""
                    End If
                    If applicantData.RoleID = 1 Then
                        lblRole.InnerText = "Verificator"
                    ElseIf applicantData.RoleID = 2 Then
                        lblRole.InnerText = "Applicant"
                    Else
                        lblRole.InnerText = "Unknown"
                    End If
                    If applicantGenData.isScholarship = True Then
                        ddlIsScholarship.SelectedValue = "1"
                    End If

                    'Dim selectedValue As String = applicantGenData.ScholarshipID.ToString()
                    'If ddlScholarship.Items.FindByValue(selectedValue) IsNot Nothing Then
                    '    ddlScholarship.SelectedValue = selectedValue
                    'Else
                    '    ' If the selected value does not exist in the list, set a default value or handle the case as needed
                    '    ddlScholarship.SelectedIndex = 0 ' Set to the first item in the list
                    '    ' Alternatively, you can display an error message or log the issue
                    'End If

                    Dim selectedValue As String = applicantGenData.ScholarshipID.ToString()
                    If ddlScholarship.Items.FindByValue(selectedValue) IsNot Nothing Then
                        ddlScholarship.SelectedValue = selectedValue
                    Else
                        ' If the selected value does not exist in the list, handle the case as needed
                        ' For example, you can set a default value or display an error message
                        ' Here, we'll just display a message in the console
                        Console.WriteLine("Warning: Selected ScholarshipID does not exist in the list.")
                    End If
                Else
                    Response.Redirect("Login.aspx")
                End If
            End If
            PopulateScholarshipDropdown()
        End If
    End Sub

    Private Sub PopulateScholarshipDropdown()
        Dim scholarships As List(Of ScholarshipDTO) = _applicantBLL.generateScholarship()

        If scholarships IsNot Nothing AndAlso scholarships.Count > 0 Then
            ddlScholarship.DataSource = scholarships
            ddlScholarship.DataTextField = "Name" ' Assuming "Name" is the property for Scholarship name in ScholarshipDTO
            ddlScholarship.DataValueField = "ScholarshipID" ' Assuming "ScholarshipID" is the property for Scholarship ID in ScholarshipDTO
            ddlScholarship.DataBind()
        Else
            ddlScholarship.Items.Clear() ' Clear any existing items
            ddlScholarship.Enabled = False
            ddlScholarship.SelectedValue = "0"
        End If
    End Sub

    Protected Sub btnLogout_Click(sender As Object, e As EventArgs)
        FormsAuthentication.SignOut()
        Session.Clear()
        Session.Abandon()

        ' Redirect to login page
        Response.Redirect("~/Login.aspx")
    End Sub



    Protected Sub ddlIsScholarship_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlIsScholarship.SelectedIndexChanged
        If ddlIsScholarship.SelectedValue = "1" Then
            ' If Yes is selected, show the scholarship dropdown
            scholarshipContainer.Visible = True
        Else
            ' If No or -- is selected, hide the scholarship dropdown
            scholarshipContainer.Visible = False

        End If
    End Sub

    Protected Sub btnSaveGeneralData_Click(sender As Object, e As EventArgs)
        txtNIS.ReadOnly = True
        txtDateBirth.ReadOnly = True
        ddlIsScholarship.Enabled = False
        ddlScholarship.Enabled = False
        btnSaveGeneralData.Visible = False
        btnEditGeneralData.Visible = True

        Dim email As String = CType(Session("LoggedUserData"), String)

        Dim applicantGenData As ApplicantsDTO = _applicantBLL.getApplicantData(email)
        Dim updatedData As CreateApplicantDTO = New CreateApplicantDTO
        updatedData.UGDataID = applicantGenData.UGDataID
        updatedData.NIS = txtNIS.Text
        updatedData.DateBirth = txtDateBirth.Text
        updatedData.isScholarship = ddlIsScholarship.SelectedValue
        updatedData.ScholarshipID = ddlScholarship.SelectedValue

        Try
            ' Call the BLL method
            _applicantBLL.completeApplicantGeneralData(updatedData)

            ' Display success message using Bootstrap alert
            alertPlaceholder.InnerHtml = "<div class='alert alert-success alert-dismissible fade show' role='alert'>" &
                                      "Data updated successfully." &
                                      "<button type='button' class='close' data-dismiss='alert' aria-label='Close'>" &
                                      "<span aria-hidden='true'>&times;</span>" &
                                      "</button></div>"
        Catch ex As Exception
            ' Display error message using Bootstrap alert
            alertPlaceholder.InnerHtml = "<div class='alert alert-danger alert-dismissible fade show' role='alert'>" &
                                      "Failed to update data." &
                                      "<button type='button' class='close' data-dismiss='alert' aria-label='Close'>" &
                                      "<span aria-hidden='true'>&times;</span>" &
                                      "</button></div>"
        End Try

        ViewState("UpdatedNIS") = txtNIS.Text
        ViewState("UpdatedDateBirth") = txtDateBirth.Text
        ViewState("UpdatedIsScholarship") = ddlIsScholarship.SelectedValue
        ViewState("UpdatedScholarshipID") = ddlScholarship.SelectedValue

    End Sub

    Protected Sub btnEditGeneralData_Click(sender As Object, e As EventArgs)
        txtNIS.ReadOnly = False
        txtDateBirth.ReadOnly = False
        ddlScholarship.Enabled = True
        ddlIsScholarship.Enabled = True
        btnSaveGeneralData.Visible = True
        btnEditGeneralData.Visible = False
    End Sub


End Class