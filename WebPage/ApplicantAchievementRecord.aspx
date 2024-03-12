<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ApplicantAchievementRecord.aspx.vb" Inherits="WebPage.ApplicantAchievementRecord" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Profile</title>
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet" />
    <style>
        body {
            background-image: url('Bootstrap/assets/img/bg.jpg'); /* Specify the path to your background image */
            background-repeat: no-repeat; /* Prevent the background image from repeating */
            background-size: cover; /* Cover the entire background with the image */
            background-position: center; /* Center the background image */
        }

        .card {
            background-color: white;
            color: black;
        }

        .form-control {
            background-color: white;
            border-color: #ff5722; /* Orange */
            color: black;
            width: 100%;
        }

            .form-control:focus {
                background-color: white;
                border-color: #ff5722; /* Orange */
                color: black;
            }

        .btn-primary {
            background-color: #ff5722; /* Orange */
            border-color: #ff5722; /* Orange */
        }

            .btn-primary:hover {
                background-color: #ff6d42; /* Lighter shade of orange */
                border-color: #ff6d42; /* Lighter shade of orange */
            }

        .logo-image {
            max-width: 60%; /* Ensure the logo fits within the container */
            height: auto; /* Maintain aspect ratio */
            display: block; /* Center the image */
            margin: 0 auto; /* Center the image horizontally */
            margin-top: 20px; /* Adjust the top margin as needed */
        }

        .validation-error {
            color: red; /* Change the color of validation error messages to red */
        }

        .nav-link {
            color: orange; /* Set the default color for all tab links */
            background-color: whitesmoke; /* Set the background color for all tabs */
            border-color: #ff5722; /* Set the border color for all tabs */
            padding: 10px 15px;
        }

            .nav-link.active {
                color: white; /* Set the color for the active (selected) tab */
                background-color: #ff5722; /* Set the background color for the active tab */
                border-color: #ff5722; /* Set the border color for the active tab */
            }

        .status-literal {
            border: 1px solid #ffc107; /* Yellow border */
            padding: 3px 8px; /* Padding */
            margin-bottom: 10px; /* Bottom margin */
            font-size: 12px; /* Font size */
        }

            .status-literal label {
                margin-bottom: 0; /* Remove margin below the label */
                font-size: 12px; /* Font size */
                font-weight: bold; /* Make the label bold */
            }

        .btn-edit,
        .btn-delete {
            width: 80px; /* Set the desired width */
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="alertPlaceholder" runat="server"></div>
        <div class="container mt-5">
            <div class="row">
                <div class="col-md-4">
                    <!-- Profile Image -->
                    <div class="card">
                        <div class="d-flex justify-content-center mt-3">
                            <label for="fileUpload" class="profile-image">
                                <input type="file" id="fileUpload" style="display: none;" />
                                <img id="imgProfileUpload" src="Bootstrap/assets/img/placeholder.jpg" alt="Profile Picture" class="rounded-circle img-thumbnail" style="cursor: pointer; width: 150px; height: 150px;" />
                            </label>
                        </div>
                        <div class="card-body">
                            <h5 class="card-title" runat="server" id="lblName"></h5>
                            <p class="card-text" runat="server" id="lblRole"></p>

                            <asp:ScriptManager runat="server"></asp:ScriptManager>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <div id="myAlert" runat="server" class="alert alert-danger" role="alert" style="font-size: smaller; padding: 5px; text-align: center;">
                                        <label for="LiteralVerificationStatus" style="margin-bottom: 0"><b>Data Status:</b></label>
                                        <asp:Literal ID="LiteralFinalData" runat="server" Text="Data is not finalized yet"></asp:Literal>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <div class="status-literal">
                                <label for="LiteralVerificationStatus">Verification Status:</label>
                                <asp:Literal ID="LiteralVerificationStatus" runat="server" Text="Verify on process"></asp:Literal>
                            </div>
                            <div class="status-literal">
                                <label for="LiteralSelectionStatus">Selection Status:</label>
                                <asp:Literal ID="LiteralSelectionStatus" runat="server" Text="Waiting for verification"></asp:Literal>
                            </div>
                        </div>

                        <!-- Staging for navigation -->
                        <div class="list-group list-group-flush">
                            <a href="ApplicantDashboard.aspx" class="list-group-item list-group-item-action">About Me</a>
                            <a href="ApplicantGeneralData.aspx" class="list-group-item list-group-item-action">General Data</a>
                            <a href="ApplicantAcademicData.aspx" class="list-group-item list-group-item-action">Academic Data</a>
                            <a href="ApplicantPersonalData.aspx" class="list-group-item list-group-item-action">Personal Data</a>
                            <a href="ApplicantAchievementRecord.aspx" class="list-group-item list-group-item-action">Achievement Record</a>
                        </div>
                        <div class="text-center mt-3 mb-3">
                            <asp:Button ID="btnFinalize" runat="server" Text="Finalize" CssClass="btn btn-primary btn-sm" OnClick="btnFinalize_Click" />
                            <asp:Button ID="btnUnfinalize" runat="server" Text="Un-finalize" CssClass="btn btn-danger btn-sm" OnClick="btnUnfinalize_Click" Visible="false" />
                            <asp:Button ID="btnLogout" runat="server" Text="Logout" CssClass="btn btn-danger btn-sm" OnClick="btnLogout_Click" />
                        </div>

                    </div>
                </div>
                <!-- Main Content -->
                <div class="col-md-8">
                    <div class="card">
                        <div class="card-header">
                            <h5 class="card-title">Achievement Records</h5>
                        </div>
                        <div id="repeater" class="card-body" runat="server">
                            <!-- Sample achievement card, you can generate these dynamically based on your data -->
                            <asp:Repeater ID="rptAchievementRecords" runat="server">
                                <ItemTemplate>
                                    <div class="card">
                                        <div class="card-body">
                                            <h5 class="card-title"><%# Eval("Title") %></h5>
                                            <p class="card-text">Level <%# Eval("Level") %></p>
                                            <div class="form-group">
                                                <label for="txtDescription"><b>Description</b></label>
                                                <textarea class="form-control" id="txtDescription" rows="3" readonly="True"> <%# Eval("Description") %></textarea>
                                            </div>
                                            <p class="card-text"><strong>Achievement Document:</strong> <a href="<%# Eval("AchievementDocument") %>">View Document</a></p>
                                            <div class="alert alert-danger" role="alert">
                                                <p class="card-text"><strong>Status:</strong> <%# If(Eval("isVerified"), "Verified", "Not Verified") %></p>
                                            </div>
                                            <asp:Button ID="btnDelete" runat="server" CssClass="btn btn-danger float-right" CommandName="DeleteRecord" CommandArgument='<%# Eval("AchievementID") %>' Text="Delete" OnClientClick="return confirm('Are you sure you want to delete this achievement record?');" />
                                        </div>
                                    </div>
                                    <br />
                                </ItemTemplate>
                            </asp:Repeater>
                            <!-- Repeat the above card structure for each achievement -->
                        </div>
                        <div class="card-footer text-right">
                            <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#exampleModal">
                                Add new
                            </button>
                        </div>
                    </div>

                </div>
                <!-- End of main content -->
            </div>
        </div>

        <!-- Modal -->
        <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="exampleModalLabel">New Achievement Records</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <div class="form-group">
                            <label for="txtTitleAdd">Title</label>
                            <asp:TextBox ID="txtTitleAdd" runat="server" CssClass="form-control" />
                        </div>
                        <div class="form-group">
                            <label for="ddlLevel">Level</label>
                            <asp:DropDownList ID="ddlLevel" runat="server" CssClass="form-control">
                                <asp:ListItem Text="Kabupaten" Value="Kabupaten"></asp:ListItem>
                                <asp:ListItem Text="Provinsi" Value="Provinsi"></asp:ListItem>
                                <asp:ListItem Text="Nasional" Value="Nasional"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <label for="txtDescription">Description</label>
                            <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3"></asp:TextBox>
                        </div>
                    </div>
                    <div class="card-footer card-footer d-flex justify-content-end">
                        <asp:Button ID="addNewAchievement" runat="server" CssClass="btn btn-primary float-right" Text="Save" OnClick="addNewAchievement_Click" />
                    </div>
                </div>
            </div>
        </div>
    </form>

    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.5.4/dist/umd/popper.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</body>
</html>

