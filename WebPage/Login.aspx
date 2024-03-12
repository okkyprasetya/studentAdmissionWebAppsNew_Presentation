<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Login.aspx.vb" Inherits="WebPage.WebForm2" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Login Form</title>
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet">
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
    </style>
</head>
<body>
    <div class="container mt-5">
        <div class="row justify-content-center">
            <div class="col-md-6">
                <div class="card">
                    <div class="card-body">
                        <h3 class="card-title text-center">Login</h3>
                        <img src="Bootstrap/assets/img/logo.png" alt="Logo" class="logo-image" />
                        <form id="form1" runat="server">
                            <div class="form-group" style="align-content:center">
                                <asp:Literal ID="ltMessage" runat="server" /><br />
                            </div>
                            <div class="form-group">
                                <label for="txtEmail">Email Address</label>
                                <asp:TextBox runat="server" CssClass="form-control" ID="txtEmail" placeholder="Enter your e-mail address" TextMode="Email" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="E-mail is required." CssClass="validation-error" />
                            </div>
                            <div class="form-group">
                                <label for="txtPassword">Password</label>
                                <asp:TextBox runat="server" CssClass="form-control" ID="txtPassword" placeholder="Enter your account password" TextMode="Password" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorPassword" runat="server" ControlToValidate="txtPassword" ErrorMessage="Password is required." CssClass="validation-error" />
                            </div>
                            <asp:Button ID="loginButton" runat="server" type="submit" class="btn btn-primary btn-block" Text="Login" OnClick="loginButton_Click" />
                        </form>
                        <p class="text-center mt-3">Don't have an account? <a href="Register.aspx" style="color: #ff5722;">Register here</a></p>
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
