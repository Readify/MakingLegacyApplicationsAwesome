<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MLAA.Web._Default" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
       <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1><%: Title %>.</h1>
                <h2>Welcome to Derp University!</h2>
            </hgroup>
            <p>
                Please give us all your future earnings in exchange for a mediocre qualification that won't
                help you much at all in your career. We hope you have a great time!
            </p>
        </div>
    </section>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h3>Your semester plan:</h3>
    <ol class="round">
        <li class="one">
            <h5>Log in to manage your profile</h5>
            Sign up for an account to receive our newsletters, see the subjects we offer and the sporting and other extra-curricular
            activities on offer at Derp University.
        </li>
        <li class="two">
            <h5>Select your subjects for this semester</h5>
            It's easy to do your enrolment online. You can see all the subjects you're eligibile to do, plus the ones you've
            already completed, and you can enrol in new ones and manage your existing enrolments all from our easy-to-use
            web site.
        </li>
        <li class="three">
            <h5>View your subject timetable</h5>

        </li>
    </ol>
</asp:Content>
