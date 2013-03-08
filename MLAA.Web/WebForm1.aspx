<%@ Page Title="Subject Enrolments" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="MLAA.Web.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    You are enrolled in <asp:Label runat="server" ID="label1"></asp:Label> subjects this semester.
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DerpUniversityConnectionString %>" SelectCommand="SELECT * FROM [Subject] ORDER BY [Code]"></asp:SqlDataSource>

    <table>
        <asp:Repeater ID="Repeater1" runat="server" DataSourceID="SqlDataSource1" OnItemCommand="Repeater1_ItemCommand">
            <ItemTemplate>
                <asp:HiddenField ID="hiddenId" runat="server" Value='<%#Eval("Id") %>'/>
                <tr>
                    <td>
                        <asp:Label runat="server" ID="Label2"
                            Text='<%# Eval("Id") %>' />
                    </td>
                    <td>
                        <asp:Label runat="server" ID="Label1"
                            Text='<%# Eval("Code") %>' />

                    </td>
                    <td>
                        <asp:Label runat="server" ID="Label3"
                            Text='<%# Eval("Name") %>' />

                    </td>
                    <td>
                        <asp:Label runat="server" ID="Label4"
                            Text='<%# Eval("MaxStudents") %>' />

                    </td>
                    
                    <td>
                        <asp:Button ID="Button1" runat="server" Text="Enrol" />
                    </td>

                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
</asp:Content>
