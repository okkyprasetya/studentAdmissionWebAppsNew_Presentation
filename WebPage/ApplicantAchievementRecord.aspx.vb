Imports Dapper.SqlMapper
Imports Microsoft.Ajax.Utilities
Imports studentAdmissionBLL
Imports studentAdmissionDTO.ApplicantDTO

Public Class ApplicantAchievementRecord
    Inherits System.Web.UI.Page
    Private _applicantBLL As New ApplicantBLL()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ' Call the method to get achievement records for the logged-in user
            Dim userEmail As String = CType(Session("LoggedUserData"), String) ' Set the logged-in user's email here
            If userEmail IsNot Nothing Then
                Dim applicantGenData = _applicantBLL.getApplicantData(userEmail)
                If applicantGenData.isFinal = True Then
                    myAlert.Attributes("class") = "alert alert-success"
                    btnUnfinalize.Visible = True
                    btnFinalize.Visible = False
                    LiteralFinalData.Text = "Data has been finalized"
                End If

                Dim achievementRecords As List(Of AchievementRecordDTO) = _applicantBLL.getAchievementRecord(userEmail)
                'getAchievementRecord(userEmail)

                ' Bind the achievement records to the repeater
                'rptAchievementRecords.DataSource = achievementRecords
                'rptAchievementRecords.DataBind()

                If achievementRecords.Count > 0 Then
                    ' Bind the achievement records to the repeater
                    rptAchievementRecords.DataSource = achievementRecords
                    rptAchievementRecords.DataBind()
                Else
                    ' If no achievement records found, hide the repeater or display a message
                    rptAchievementRecords.Visible = False
                    ' You can also display a message here if needed
                End If
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

    End Sub

    Protected Sub btnSaveAboutMe_Click(sender As Object, e As EventArgs)

    End Sub

    Protected Sub Unnamed_Click(sender As Object, e As EventArgs)

    End Sub

    Protected Sub btnSaveAchievement_Click(sender As Object, e As EventArgs)

    End Sub


    Public Function getAchievementRecord(ByVal email As String) As List(Of AchievementRecordDTO)
        Dim records = _applicantBLL.getAchievementRecord(email)

        If IsDBNull(records) Then
            Return Nothing
        Else
            Dim achievementRecords As New List(Of AchievementRecordDTO)()
            For Each record As AchievementRecordDTO In records
                Dim achievementRecord As New AchievementRecordDTO() With {
                .AchievementID = record.AchievementID,
                .Title = record.Title,
                .Description = record.Description,
                .Level = record.Level,
                .AchievementDocument = record.AchievementDocument,
                .isVerified = record.isVerified
            }
                achievementRecords.Add(achievementRecord)
            Next

            Return achievementRecords
        End If
    End Function

    Protected Sub rptAchievementRecords_ItemCommand(source As Object, e As RepeaterCommandEventArgs) Handles rptAchievementRecords.ItemCommand
        If e.CommandName = "DeleteRecord" Then
            ' Retrieve the AchievementID from the CommandArgument
            Dim achievementID As Integer = CInt(e.CommandArgument)

            Try
                ' Call the DAL method to delete the achievement record
                _applicantBLL.deleteAchievementRecord(achievementID)

                ' Rebind the repeater to reflect the changes
                rptAchievementRecords.DataBind()

                ' Display success message using Bootstrap alert
                alertPlaceholder.InnerHtml = "<div class='alert alert-success alert-dismissible fade show' role='alert'>" &
                                          "Achievement record deleted successfully." &
                                          "<button type='button' class='close' data-dismiss='alert' aria-label='Close'>" &
                                          "<span aria-hidden='true'>&times;</span>" &
                                          "</button></div>"
                Response.Redirect("/ApplicantAchievementRecord")
            Catch ex As Exception
                ' Display error message using Bootstrap alert
                alertPlaceholder.InnerHtml = "<div class='alert alert-danger alert-dismissible fade show' role='alert'>" &
                                          "Failed to delete achievement record." &
                                          "<button type='button' class='close' data-dismiss='alert' aria-label='Close'>" &
                                          "<span aria-hidden='true'>&times;</span>" &
                                          "</button></div>"
                ' Log the exception
                ' LogException(ex)
            End Try
        End If
    End Sub

    Protected Sub btnDelete_Click(sender As Object, e As EventArgs)

    End Sub

    Protected Sub addNewAchievement_Click(sender As Object, e As EventArgs)
        Dim email As String = CType(Session("LoggedUserData"), String)
        Dim applicantGenData = _applicantBLL.getApplicantData(email)
        Try

            Dim achievementRecord As New CreateAchievementRecordDTO
            achievementRecord.UGDataID = applicantGenData.UGDataID
            achievementRecord.Title = txtTitleAdd.Text
            achievementRecord.Level = ddlLevel.SelectedValue
            achievementRecord.Description = txtDescription.Text

            ' Call the BLL method to add the achievement record
            _applicantBLL.addAchievementRecord(achievementRecord)

            Response.Redirect("ApplicantAchievementRecord")

        Catch ex As Exception

            Throw New ArgumentException(ex.Message)
        End Try
    End Sub

    Protected Sub btnFinalize_Click(sender As Object, e As EventArgs)
        Dim email As String = CType(Session("LoggedUserData"), String)
        Dim applicantGenData = _applicantBLL.getApplicantData(email)
        Dim uid = applicantGenData.UserID
        Try
            ' Call the BLL method to add the achievement record
            _applicantBLL.finalizeData(uid)
            myAlert.Attributes("class") = "alert alert-success"
            btnUnfinalize.Visible = True
            btnFinalize.Visible = False
            LiteralFinalData.Text = "Data has been finalized"
            ' Optionally, you can reload the achievement records after adding the new record
        Catch ex As Exception
            ' Handle any exceptions that occur during the process
            ' You can display an error message or log the exception
            Throw New ArgumentException(ex.Message)
        End Try
    End Sub

    Protected Sub btnUnfinalize_Click(sender As Object, e As EventArgs)
        btnUnfinalize.Visible = False
        btnFinalize.Visible = True
        myAlert.Attributes("class") = "alert alert-danger"
        LiteralFinalData.Text = "Data is not finalized yet"
    End Sub
End Class