<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConnectedObjects.aspx.cs" Inherits="WebDataAccessComtrols.ConnectedObjects" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <%--<form id="form1" runat="server">
        <div>
        </div>
    </form>--%>
        <asp:GridView ID="GridView1" runat="server" Height="220px" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Width="320px">
        </asp:GridView>
        <asp:DropDownList ID="DropDownList1" runat="server">
        </asp:DropDownList>
        <br />
        <br />
        EmpId:
        <asp:TextBox ID="TxtEId" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label1" runat="server"></asp:Label>
        <br />
        <br />
        EmpName: <asp:TextBox ID="TxtEName" runat="server"></asp:TextBox>
        <br />
        <br />
        EmpSalary:
        <asp:TextBox ID="TxtESal" runat="server"></asp:TextBox>
        <br />
        <br />
        <br />
        <asp:Button ID="btnInEmp" runat="server" OnClick="btnInEmp_Click" Text="Insert Emp" />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="BtnUpdataPara" runat="server" OnClick="BtnUpdataPara_Click" Text="UpdateWithpara" />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="BtnDelete" runat="server" OnClick="BtnDelete_Click" Text="Delete" />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="Search" />
        <br />
        <br />
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Insert With Sp" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnInPara" runat="server" OnClick="btnInPara_Click" Text="Insert With Para" />
        <br />
        <br />
        <asp:Button ID="btnUpdateQtn" runat="server" OnClick="btnUpdateQtn_Click" Text="UPDATE" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Update with SP" />
        <br />
        <br />
        <br />
        <asp:Button ID="btnDeleteQtn" runat="server" OnClick="btnDeleteQtn_Click" Text="DELETE with QTN" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnDeletePara" runat="server" OnClick="btnDeletePara_Click" Text="DELETE with Para" />
        <br />
        <br />
        <p>
            <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
        </p>
    </form>
</body>
</html>
