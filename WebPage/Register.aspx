<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Register.aspx.vb" Inherits="WebPage.Register" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Registration Form</title>
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet">
    <style>
        body {
            background-image: url('Bootstrap/assets/img/bg.jpg'); /* Specify the path to your background image */
            background-repeat: no-repeat; /* Prevent the background image from repeating */
            background-size: cover; /* Cover the entire background with the image */
            background-position: center; /* Center the background image */
            background-attachment: fixed; 
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
    </style>
</head>
<body>
    <div class="container mt-5 mb-5">
        <div class="row justify-content-center">
            <div class="col-md-6">
                <div class="card">
                    <div class="card-body">
                        <h3 class="card-title text-center">Register</h3>
                        <img src="Bootstrap/assets/img/logo.png" alt="Logo" class="logo-image" />
                        <form id="form1" runat="server">
                            <div class="form-group">
                                <asp:Literal ID="ltMessage" runat="server" /><br />
                            </div>
                            <div class="form-group">
                                <label for="txtfirstName">First Name</label>
                                <asp:TextBox runat="server" CssClass="form-control" ID="txtfirstName" placeholder="Enter your first name" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorFirstName" runat="server" ControlToValidate="txtfirstName" ErrorMessage="First name is required." CssClass="validation-error" />
                            </div>
                            <div class="form-group">
                                <label for="txtmiddleName">Middle Name</label>
                                <asp:TextBox runat="server" CssClass="form-control" ID="txtmiddleName" placeholder="Enter your middle name" />
                            </div>
                            <div class="form-group">
                                <label for="txtlastName">Last Name</label>
                                <asp:TextBox runat="server" CssClass="form-control" ID="txtlastName" placeholder="Enter your last name" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorLastName" runat="server" ControlToValidate="txtlastName" ErrorMessage="Last name is required." CssClass="validation-error" />
                            </div>
                            <div class="form-group">
                                <label for="txtemail">Email Address</label>
                                <asp:TextBox runat="server" CssClass="form-control" ID="txtemail" TextMode="Email" placeholder="Enter your email address" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorEmail" runat="server" ControlToValidate="txtemail" ErrorMessage="Email address is required." CssClass="validation-error" />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidatorEmail" runat="server" ControlToValidate="txtemail" ErrorMessage="Invalid email address format." ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" CssClass="validation-error" />
                            </div>
                            <div class="form-group">
                                <label for="txtpassword">Password</label>
                                <asp:TextBox runat="server" CssClass="form-control" ID="txtpassword" TextMode="Password" placeholder="Enter your password" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorPassword" runat="server" ControlToValidate="txtpassword" ErrorMessage="Password is required." CssClass="validation-error" />
                            </div>
                            <div class="form-group">
                                <label for="txtconfirmPassword">Confirm Password</label>
                                <asp:TextBox runat="server" CssClass="form-control" ID="txtconfirmPassword" TextMode="Password" placeholder="Confirm your password" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorConfirmPassword" runat="server" ControlToValidate="txtconfirmPassword" ErrorMessage="Please confirm your password." CssClass="validation-error" />
                                <asp:CompareValidator ID="CompareValidatorConfirmPassword" runat="server" ControlToValidate="txtconfirmPassword" ControlToCompare="txtpassword" Operator="Equal" ErrorMessage="Passwords do not match." CssClass="validation-error" />
                            </div>
                            <asp:Button runat="server" type="submit" class="btn btn-primary btn-block" Text="Register" ID="Register" OnClick="Register_Click" />
                        </form>
                        <p class="text-center mt-3">Already have an account? <a href="Login.aspx" style="color: #ff5722;">Login here</a></p>
                        <br />
                    </div>
                </div>
            </div>
        </div>
    </div>

    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.5.4/dist/umd/popper.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</body>
</html>
