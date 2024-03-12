<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ApplicantGeneralData.aspx.vb" Inherits="WebPage.ApplicantGeneralData" EnableViewState="true" EnableSessionState="true" %>

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
                            <div class="status-literal">
                                <label for="LiteralVerificationStatus">Data Status:</label>
                                <asp:Literal ID="LiteraldFinalData" runat="server" Text="Data is not finalized yet"></asp:Literal>
                            </div>
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
                            <asp:Button ID="btnLogout" runat="server" Text="Logout" CssClass="btn btn-danger btn-sm" OnClick="btnLogout_Click" />
                        </div>

                    </div>
                </div>
                <!-- Main Content -->
                <div class="col-md-8">
                    <div class="card">
                        <div class="card-body">
                            <h5 class="card-title">General Data</h5>
                            <p class="card-text" id="GeneralDataText" runat="server"></p>
                            <asp:Panel ID="pnlGeneralDataForm" runat="server" Visible="true">
                                <div class="form-group">
                                    <asp:Literal ID="ltMessage" runat="server" /><br />
                                </div>
                                <div class="form-group">
                                    <label for="txtNIS">NIS</label>
                                    <asp:TextBox runat="server" CssClass="form-control" ID="txtNIS" placeholder="Enter your NIS ID" ReadOnly="true" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorNIS" runat="server" ControlToValidate="txtNIS" ErrorMessage="NIS is required." CssClass="validation-error" ValidationGroup="GeneralDataValidation" />
                                </div>
                                <div class="form-group">
                                    <label for="txtDateBirth">DateBirth</label>
                                    <asp:TextBox runat="server" CssClass="form-control" ID="txtDateBirth" placeholder="Enter birthdate" ReadOnly="true" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorDateBirth" runat="server" ControlToValidate="txtDateBirth" ErrorMessage="Birthdate is required." CssClass="validation-error" ValidationGroup="GeneralDataValidation" />
                                </div>
                                <div class="form-group">
                                    <label for="ddlIsScholarship">Applying Scholarship?</label>
                                    <asp:DropDownList runat="server" CssClass="form-control" ID="ddlIsScholarship" AppendDataBoundItems="true" ReadOnly="true" Enabled="false">
                                        <asp:ListItem Text="--" Value=""></asp:ListItem>
                                        <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="No" Value="0"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorIsScholarship" runat="server" ControlToValidate="ddlIsScholarship" ErrorMessage="Data is required." CssClass="validation-error" InitialValue="Select" ValidationGroup="GeneralDataValidation"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group" id="scholarshipContainer" runat="server">
                                    <label for="ddlScholarship">Scholarship Name</label>
                                    <asp:DropDownList runat="server" CssClass="form-control" ID="ddlScholarship" AppendDataBoundItems="true" ReadOnly="true" EnableViewState="true" Enabled="false">
                                        <asp:ListItem Text="No Scholarship" Value="0"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlScholarship" ErrorMessage="Data is required." CssClass="validation-error" InitialValue="Select" ValidationGroup="GeneralDataValidation"></asp:RequiredFieldValidator>
                                </div>
                            </asp:Panel>

                            <asp:Button ID="btnEditGeneralData" runat="server" CssClass="btn btn-secondary mt-2" Text="Edit" OnClick="btnEditGeneralData_Click" />
                            <asp:Button ID="btnSaveGeneralData" runat="server" CssClass="btn btn-primary mt-2" Text="Save" OnClick="btnSaveGeneralData_Click" Visible="false" ValidationGroup="GeneralDataValidation" CausesValidation="True" />
                        </div>
                    </div>
                </div>
                <!-- End of main content -->
            </div>
        </div>
    </form>
    

    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.5.4/dist/umd/popper.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>

</body>

</html>

