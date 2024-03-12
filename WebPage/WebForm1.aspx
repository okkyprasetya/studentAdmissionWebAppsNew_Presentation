<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WebForm1.aspx.vb" Inherits="WebPage.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <div class="col-lg-12">
    <br />
    <br />
    <!-- Basic Card Example -->
    <div class="card shadow mb-4">
        <div class="card-header py-3">
            <h6 class="m-0 font-weight-bold text-primary">Daftar Verificator</h6>
        </div>

        <div class="card-body">
            <asp:Literal ID="ltMessage" runat="server" /><br />
            <table class="table table-hover">
                <asp:ListView ID="lvUser" DataKeyNames="UserID" ItemType="studentAdmissionDTO.UsersDTO"
                    SelectMethod="lvUser_GetData" runat="server">
                    <LayoutTemplate>
                        <thead>
                            <tr>
                                <th>ID</th>
                                <th>UserEmail</th>
                                <th>Password</th>
                                <th>FirstName</th>
                                <th>MiddleName</th>
                                <th>LastName</th>
                                <th>&nbsp;</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr id="itemPlaceholder" runat="server"></tr>
                        </tbody>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <tr>
                            <td><%# Eval("UserID") %></td>
                            <td><%# Eval("UserEmail") %></td>
                            <td><%# Eval("Password") %></td>
                            <td><%# Eval("FirstName") %></td>
                            <td><%# Eval("MiddleName") %></td>
                            <td><%# Eval("LastName") %></td>
                        </tr>
                    </ItemTemplate>
                    <EmptyItemTemplate>
                        <tr>
                            <td colspan="7">No records found</td>
                        </tr>
                    </EmptyItemTemplate>
                </asp:ListView>

            </table>

        </div>
    </div>

</div>
</body>
</html>
