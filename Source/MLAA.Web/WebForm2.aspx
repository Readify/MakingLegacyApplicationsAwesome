<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="MLAA.Web.WebForm2" %>
<%@ Import Namespace="MLAA.Web" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1>Class lists are now online!</h1>
                <h2>Want to know who's in your classes?</h2>
            </hgroup>
            <p>
                Please try to turn up on time. It doesn't matter to us but if you're late you'll have to sit
                at the front like a square or something.
            </p>
        </div>
    </section>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <table>
    <%
        foreach (var s in EnrolmentManager.SearchStudents(""))
        {
    %>
        <tr>
            <td>
                <%= s.FirstName %> <%= s.LastName %>
                    <%
                        foreach (var e in EnrolmentManager.GetSTUdentEnrolments(s.Id))
                        {
                            %>
                    <tr>
                        <td></td>
                        <td><%=((System.Data.Common.DbDataRecord)e) ["Code"] %></td>
                        <td><%=((System.Data.Common.DbDataRecord)e) ["Name"] %></td>
                    </tr>
                    <%
                        }
                    %>
            </td>
        </tr>
        <%
        } %>
        </table>
</asp:Content>