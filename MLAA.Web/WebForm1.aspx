<%@ Page Title="Subject Enrolments" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="MLAA.Web.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    
     <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1>You are enrolled in <asp:Label runat="server" ID="label1"></asp:Label> subjects this semester.</h1>
            </hgroup>
            <p>
                Please give us all your future earnings in exchange for a mediocre qualification that won't
                help you much at all in your career. We hope you have a great time!
            </p>
        </div>
    </section>

    
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DerpUniversityConnectionString %>" SelectCommand="SELECT * FROM [Subject] ORDER BY [Code]"></asp:SqlDataSource>

    <table>
        <asp:Repeater ID="Repeater1" runat="server" DataSourceID="SqlDataSource1" OnItemCommand="Repeater1_ItemCommand" OnItemDataBound="Repeater1_ItemDataBound">
            <ItemTemplate>
                <asp:HiddenField ID="hiddenId" runat="server" Value='<%#Eval("Id") %>'/>
                <tr>
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
