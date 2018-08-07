<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="Fuel_Management.HomePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <br /><br /><br /><br />
                <div class="col-lg-12">
                    <h1 class="page-header">Overview</h1>
                </div>
             
                <div class="search_bar">
        
                  
                     &nbsp;&nbsp;&nbsp;&nbsp;Search by:
                    <asp:DropDownList ID="DropDownList1" runat="server" AppendDataBoundItems="false" AutoPostBack="true" Width="120px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" CssClass="search_categories">
                    </asp:DropDownList>
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:DropDownList ID="DropDownList2" runat="server" AppendDataBoundItems="false"  AutoPostBack="true"  Width="120px" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" CssClass="search_categories">
                    </asp:DropDownList>
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Refresh" Width="95px" Class="button" />

                    

                    <asp:Button ID="Button2" runat="server" Text="Export To Excel" onClick="Export_Click" Class="button"/>
                    
                    <asp:LinkButton ID="lnkAdd" runat="server"
                                    OnClick="Btn_Add"
                                    Text="Add New" Class="button" Style="margin-left:360px;"></asp:LinkButton>
                  
           </div>
            
                           
        <div>
            <br />
           
            <asp:Panel ID="panel" runat="server" Height="50%" Width="96%">
               

                <asp:GridView ID="gridManage" runat="server" CssClass="EU_DataTable"
                    AutoGenerateColumns="False" ShowFooter="True" AllowPaging="true" OnPageIndexChanging="OnPageIndexChanging" CellPadding="4" BackColor="White" Width="96%"
                    BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" Style="margin-bottom: 0px; margin-left:15px; overflow:visible" OnRowDataBound="gridManage_RowDataBound" OnRowEditing="gridManage_RowEditing" DataKeyNames="FuelID">

                    <Columns>

                        <asp:TemplateField ItemStyle-Width="100px" ItemStyle-Wrap="true" HeaderText="Fuel ID">
                            <HeaderStyle Width="100px" />

                            <ItemTemplate>

                                <asp:Label ID="lblFuel" runat="server" Style="width: 100px" Text='<%#

                                         Eval("FuelID")%>'></asp:Label>

                            </ItemTemplate>

                           


                            <ItemStyle Width="100px" Wrap="True" />

                           


                        </asp:TemplateField>

                        <asp:TemplateField ItemStyle-Width="100px" ItemStyle-Wrap="true" HeaderText="Site">
                            <HeaderStyle Width="100px" />

                            <ItemTemplate>

                                <asp:Label ID="lblSite" runat="server" Style="width: 100px" Text='<%#

                                         Eval("SiteID")%>'></asp:Label>

                            </ItemTemplate>

                           


                            <ItemStyle Width="100px" Wrap="True" />

                           


                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-Width="100px" ItemStyle-Wrap="true" HeaderText="Cluster">

                            <ItemTemplate>

                                <asp:Label ID="lblCluster" runat="server" Text='<%#

                                         Eval("Cluster")%>'></asp:Label>

                            </ItemTemplate>

                            
                            <ItemStyle Width="100px" Wrap="True" />

                            
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-Width="100px" ItemStyle-Wrap="true" HeaderText="Region">

                            <ItemTemplate>

                                <asp:Label ID="lblregion" runat="server" Text='<%#

                                         Eval("region")%>'></asp:Label>

                            </ItemTemplate>

                            
                            <ItemStyle Width="100px" Wrap="True" />

                            
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-Width="100px" ItemStyle-Wrap="true" HeaderText="Date Fueling">

                            <ItemTemplate>

                                <asp:Label ID="DateFueling" runat="server" Text='<%#

                                         Eval("DateFueling")%>'></asp:Label>

                            </ItemTemplate>
  
                            <ItemStyle Width="100px" Wrap="True" />
  
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-Width="100px" HeaderText="Level Before">

                            <ItemTemplate>

                                <asp:Label ID="levelBefore" runat="server" Text='<%#

                                         Eval("levelBefore")%>'></asp:Label>

                            </ItemTemplate>

                            <ItemStyle Width="100px" />

                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-Width="100px" ItemStyle-Wrap="true" HeaderText="Level After">

                            <ItemTemplate>

                                <asp:Label ID="levelAfter" runat="server" Text='<%#

                                         Eval("levelAfter")%>'></asp:Label>

                            </ItemTemplate>

                            <ItemStyle Width="100px" Wrap="True" />

                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-Width="100px" ItemStyle-Wrap="true" HeaderText="Qty to be">

                            <ItemTemplate>

                                <asp:Label ID="Qty" runat="server" Text='<%#

                                         Eval("Qty")%>'></asp:Label>

                            </ItemTemplate>

                            <ItemStyle Width="100px" Wrap="True" />

                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-Width="100px" ItemStyle-Wrap="true" HeaderText="Username">

                            <ItemTemplate>

                                <asp:Label ID="username" runat="server" Text='<%#

                                         Eval("username")%>'></asp:Label>

                            </ItemTemplate>

                            <ItemStyle Width="100px" Wrap="True" />

                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-Width="100px" ItemStyle-Wrap="true" HeaderText="Fin R Week">

                            <ItemTemplate>

                                <asp:Label ID="FinRWeek" runat="server" Text='<%#

                                         Eval("FinRWeek")%>'></asp:Label>

                            </ItemTemplate>

                            <ItemStyle Width="100px" Wrap="True" />

                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-Width="100px" ItemStyle-Wrap="true" HeaderText="Receipt Number">

                            <ItemTemplate>

                                <asp:Label ID="ReceiptNumber" runat="server" Text='<%#

                                         Eval("ReceiptNumber")%>'></asp:Label>

                            </ItemTemplate>

                            <ItemStyle Width="100px" Wrap="True" />

                        </asp:TemplateField>




                        <asp:TemplateField ItemStyle-Width="100px" ItemStyle-Wrap="true" HeaderText="Action">

                            <ItemTemplate>

                                <asp:LinkButton ID="lnkRemove" runat="server" CommandArgument='<%#

                                         Eval("SiteID")%>'
                                    OnClick="lnkRemove_Click"
                                    Text="Delete"></asp:LinkButton>

                            </ItemTemplate>

                            

                        </asp:TemplateField>

                       

                    </Columns>

                    

                    <HeaderStyle BackColor="red" Font-Bold="True" ForeColor="#FFFFCC"></HeaderStyle>

                    <PagerStyle HorizontalAlign="Center" BackColor="#FFFFCC" ForeColor="Black"></PagerStyle>

                    <RowStyle ForeColor="Black" BackColor="White" />

                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399"></SelectedRowStyle>

                    <SortedAscendingCellStyle BackColor="#FEFCEB"></SortedAscendingCellStyle>

                    <SortedAscendingHeaderStyle BackColor="#AF0101"></SortedAscendingHeaderStyle>

                    <SortedDescendingCellStyle BackColor="#F6F0C0"></SortedDescendingCellStyle>

                    <SortedDescendingHeaderStyle BackColor="#7E0000"></SortedDescendingHeaderStyle>
            </asp:GridView>
                    
                     </asp:Panel>
               
            

        </div>
                              
               
                
            </div>
            <!-- /.row -->
   
</asp:Content>
