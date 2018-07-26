<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FuelRegister.aspx.cs" Inherits="Fuel_Management.FuelRegisterPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.6/jquery.min.js" type="text/javascript"></script>
    <script src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/jquery-ui.min.js" type="text/javascript"></script>
    <link href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/themes/base/jquery-ui.css" rel="Stylesheet" type="text/css" />
   
     <script type="text/javascript">
        $(function () {
            $("[id$=ADrefueled]").datepicker({
                showOn: 'button',
                buttonImageOnly: true,
                buttonImage: '/Images/calender.png',
                dateFormat: "dd/mm/yy"
            });
        });
        </script>
    <div class="row">
                <div class="col-lg-12">
                    <h1 class="page-header">Fuel Register</h1>
                </div>
                <!-- /.col-lg-12 -->
           
            
               

                   <div class="container">
                                      <div class="row">
                                        <div class="modal-dialog">
                                              <div class="modal-content">

                                                  <div class="modal-header">
                                                      <label>New Fuel Registration</label>
                                                  </div>
                                                  <div class="modal-body">
                                                      <div>
                                                      <asp:Label ID="ResultInfo" runat="server"></asp:Label>
                                                      </div>

                                                          <div class="input_container">

                                                              <asp:Label id="SiteD" runat="server">Site ID: <span class="required">*</span></asp:Label>
                                                              <div class="field_container">
                                                              <asp:DropDownList ID="IdSite" runat="server" AutoPostBack="false" Width="170px"/>
                                                                  </div>
                                                                
                                                              
                                                          </div>
                                                          <div class="input_container">
                                                              <asp:Label id="clusterID" runat="server">Cluster: <span class="required">*</span></asp:Label>
                                                              <div class="field_container">
                                                                  <asp:TextBox id="cluster" runat="server"/>
                                                              </div>
                                                          </div>
                                                      <div class="input_container">
                                                              <asp:Label ID="ADrefueledID" runat="server">Actual Date Refueled: <span class="required">*</span></asp:Label>
                                                              <div class="field_container">
                                                                  <asp:TextBox id="ADrefueled" runat="server"/>
                                                                  <asp:ImageButton ID="imageButton" runat="server" Height="17px" ImageUrl="/Images/calender.png" OnClick="imageButton_click" Width="21px" />
                                                                  <asp:Calendar ID="calendar" runat="server"
                                                                      onselectionchanged="calendar_selectionchanged" Visible="false"></asp:Calendar>
                                                              </div>
                                                          </div>
                                                      <div class="input_container">
                                                              <asp:Label ID="LevelbeforeID" runat="server">Level before: <span class="required">*</span></asp:Label>
                                                              <div class="field_container">
                                                                  <asp:TextBox  id="Levelbefore" runat="server"/>
                                                              </div>
                                                          <div class="input_container">
                                                              <asp:Label ID="LevelafterID" runat="server">Level After: <span class="required">*</span></asp:Label>
                                                              <div class="field_container">
                                                                  <asp:TextBox  id="Levelafter" runat="server"/>
                                                              </div>
                                                          <div class="input_container">
                                                              <asp:Label ID="QtyID" runat="server">Quantity to be Delivered: <span class="required">*</span></asp:label>
                                                              <div class="field_container">
                                                                  <asp:TextBox id="Qty" runat="server"/>
                                                              </div>
                                                          </div>
                                                              <div class="input_container">
                                                              <asp:Label ID="usernameID" runat="server">Username: <span class="required">*</span></asp:label>
                                                              <div class="field_container">
                                                                  <asp:TextBox id="username" runat="server"/>
                                                              </div>
                                                          </div>
                                                          
                                                          <div class="input_container">
                                                              <asp:Label ID="FinRWeek_ID" runat="server">Final Ref Week: <span class="required">*</span></asp:Label>
                                                              <div class="field_container">
                                                                  <asp:TextBox id="FinRWeek" runat="server"/>
                                                              </div>
                                                          </div>
                                                          <div class="input_container">
                                                              <asp:Label ID="receiptNumber_ID" runat="server">Receipt Number: <span class="required">*</span></asp:Label>
                                                              <div class="field_container">
                                                                  <asp:TextBox id="receiptNumber" runat="server"/>
                                                              </div>
                                                          </div>

                                                          <div class="modal-footer">
                                                      <asp:Button id="Save" Text="Save" runat="server" OnClick="Save_btnClick"></asp:Button>
                                                      
                                                  </div>
                                                     
                                                      </div>
                                                  
                                                  
                                              </div>
                                          </div>
                                        </div>
                                            </div>
                                          </div>
                                    </div>
               
                
            </div>
            <!-- /.row -->
</asp:Content>
