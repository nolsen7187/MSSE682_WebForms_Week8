﻿<%@ Page Title="Logged In" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Secure.aspx.cs" Inherits="Secure" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="MainContent">
<hgroup class="title">
    <h1><%: Title %></h1>
</hgroup>
<body>
    <form id="form1">
    <div>
    
        <asp:Label ID="CustomerLabel" runat="server" Text="Signed in as Customer: "></asp:Label>
        <asp:Label ID="SalesRepLabel" runat="server" Text="Signed in as SalesRep: "></asp:Label>
    </div>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Log Out" />
    </form>
</body>
</asp:Content>
