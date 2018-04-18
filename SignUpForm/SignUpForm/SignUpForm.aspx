<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="SignUpForm.aspx.vb" Inherits="SignUpForm.SignUpForm" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">

    <title>ERPSIM Registration</title>

    <style type="text/css">
        .style1 {
            color: gold;
            width: 32%;
        }
    </style>

</head>


<body style='background: #800000'>

    <form id="form1" runat="server">
        <br />
        <h1 style="color:gold">ERPSIM Registration</h1>
        <div>

            <table class="style1">

                <tr>
                    <td>First Name:</td>
                    <td>
                        <asp:TextBox ID="FirstNameTextBox" placeholder="First Name" runat="server"></asp:TextBox><asp:Label ID="Label3" runat="server" ForeColor="gold" Text="Label">*</asp:Label>
                    </td>
                </tr>

                <tr>
                    <td>Last Name:</td>
                    <td>
                        <asp:TextBox ID="LastNameTextBox" placeholder="Last Name" runat="server"></asp:TextBox><asp:Label ID="Label4" runat="server" ForeColor="gold" Text="Label">*</asp:Label>
                    </td>
                </tr>

                <tr>
                    <td>GlobalID:</td>
                    <td>
                        <asp:TextBox ID="EmailTextBox" placeholder="GlobalID@cmich.edu" runat="server"></asp:TextBox><asp:Label ID="Label2" runat="server" ForeColor="gold" Text="Label">*</asp:Label>
                    </td>
                </tr>

                <tr>
                    <td>Class Standing:</td>
                    <td>
                        <asp:DropDownList ID="ClassStandingDropDown" runat="server">
                            <asp:ListItem>Graduate</asp:ListItem>
                            <asp:ListItem>Freshman</asp:ListItem>
                            <asp:ListItem>Sophomore</asp:ListItem>
                            <asp:ListItem>Junior</asp:ListItem>
                            <asp:ListItem>Senior</asp:ListItem>

                        </asp:DropDownList><asp:Label ID="Label5" runat="server" ForeColor="gold" Text="Label">*</asp:Label>
                    </td>
                </tr>

                <tr>
                    <td>Major/Course:</td>
                    <td>
                        <asp:TextBox ID="MajorCourseTextBox" placeholder="Eg:MSIS" runat="server"></asp:TextBox><asp:Label ID="Label1" runat="server" ForeColor="gold" Text="Label">*</asp:Label>
                    </td>
                </tr>

                <tr>
                    <td>Minor:</td>
                    <td>
                        <asp:TextBox ID="MinorTextBox" placeholder="Eg:MSA/None" runat="server"></asp:TextBox><asp:Label ID="Label9" runat="server" ForeColor="gold" Text="Label">*</asp:Label>
                    </td>
                </tr>




                <tr>
                    <td>Club/Group:</td>
                    <td>
                        <asp:TextBox ID="clubTextBox" placeholder="Eg:SAP/None" runat="server"></asp:TextBox><asp:Label ID="Label10" runat="server" ForeColor="gold" Text="Label">*</asp:Label>
                    </td>
                </tr>

                <tr>
                    <td>Graduation:</td>
                    <td>

                        <asp:DropDownList ID="GraduationMonthDropDownList" runat="server">
                            <asp:ListItem>January</asp:ListItem>
                            <asp:ListItem>Febuary</asp:ListItem>
                            <asp:ListItem>March</asp:ListItem>
                            <asp:ListItem>April</asp:ListItem>
                            <asp:ListItem>May</asp:ListItem>
                            <asp:ListItem>June</asp:ListItem>
                            <asp:ListItem>July</asp:ListItem>
                            <asp:ListItem>August</asp:ListItem>
                            <asp:ListItem>September</asp:ListItem>
                            <asp:ListItem>October</asp:ListItem>
                            <asp:ListItem>November</asp:ListItem>
                            <asp:ListItem>December</asp:ListItem>
                        </asp:DropDownList><asp:Label ID="Label8" runat="server" ForeColor="gold" Text="Label">*</asp:Label>
                        <asp:DropDownList ID="GraduationYearDropDownList" runat="server">
                        </asp:DropDownList><asp:Label ID="Label7" runat="server" ForeColor="gold" Text="Label">*</asp:Label>
                    </td>
                </tr>

                <tr>
                    <td>T-shirt size:</td>
                    <td>
                        <asp:DropDownList ID="TShirtSizeDropDownList" runat="server"
                            AppendDataBoundItems="true">
                            <asp:ListItem>XS</asp:ListItem>
                            <asp:ListItem>S</asp:ListItem>
                            <asp:ListItem>M</asp:ListItem>
                            <asp:ListItem>L</asp:ListItem>
                            <asp:ListItem>XL</asp:ListItem>
                            <asp:ListItem>XXL</asp:ListItem>
                        </asp:DropDownList><asp:Label ID="Label6" runat="server" ForeColor="Gold" Text="Label">*</asp:Label>
                    </td>
                </tr>

                <tr>
                    <td>Desired Team Mate 1:</td>
                    <td>
                        <asp:TextBox ID="desiredTeamMateOneTextBox" placeholder="GlobalID" runat="server"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td>Desired Team Mate 2:</td>
                    <td>
                        <asp:TextBox ID="desiredTeamMateTwoTextBox" placeholder="GlobalID" runat="server"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td>Desired Team Mate 3:</td>
                    <td>
                        <asp:TextBox ID="desiredTeamMateThreeTextBox" placeholder="GlobalID" runat="server"></asp:TextBox>
                    </td>
                </tr>

                

                <tr>
                    <td>
                        <asp:Button ID="SaveButton" BorderColor="Gold" Font-Bold="true"  runat="server" Text="Save" />

                    </td>
                    <td>
                        <asp:Button ID="ClearButton" BorderColor="Gold" Font-Bold="true" runat="server" Text="Clear" />
                    </td>


                </tr>

            </table>
        </div>

    </form>


</body>


</html>
