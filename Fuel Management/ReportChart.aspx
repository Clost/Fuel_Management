<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReportChart.aspx.cs" Inherits="Fuel_Management.ReportChart" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

  <div class="row">
        <br />
                <div class="col-lg-12">
                    <h1 class="page-header">Overview</h1>
                </div>
      <asp:Chart ID="Chart1" runat="server" DataSourceID="SqlDataSource1" Width="938px">
          <Series>
              <asp:Series Name="Series1" XValueMember="SiteID" YValueMembers="Days"></asp:Series>
          </Series>
          <ChartAreas>
              <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
          </ChartAreas>
      </asp:Chart>

        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:FuelManagementConnectionString %>" SelectCommand="Select DATEDIFF(DAY, DateFueling, GetDate()) as Days, SiteID from Fuel_register"></asp:SqlDataSource>

      </div>
</asp:Content>