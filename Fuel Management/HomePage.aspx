<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="Fuel_Management.HomePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
                <div class="col-lg-12">
                    <h1 class="page-header">Fuel Management</h1>
                </div>
                <!-- /.col-lg-12 -->
           
            
                           
        <div>
            <asp:Panel ID="panel" runat="server" Height="300px" Width="100%" ScrollBars="Auto">

            <asp:GridView ID="gridManage" runat="server" CssClass="EU_DataTable"
                AutoGenerateColumns="False" ShowFooter="True" CellPadding="2" BackColor="White" 
                BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" Height="77px" style="margin-right: 0px; 
                 margin-bottom: 0px">

                <Columns>

                    <asp:TemplateField ItemStyle-Width="30px" HeaderText="ID">


                        <ItemTemplate>

                            <asp:Label ID="FuelID" runat="server"
                                Text='<%#Eval("FuelID")%>'></asp:Label>

                        </ItemTemplate>

                   

                    </asp:TemplateField>

                    <asp:TemplateField ItemStyle-Width="40px" ItemStyle-Wrap="true" HeaderText="Site">
                        <HeaderStyle Width="40px" />

                        <ItemTemplate>

                            <asp:Label ID="lblSite" runat="server" Style="width:40px" Text='<%#

                                         Eval("SiteID")%>'></asp:Label>

                        </ItemTemplate>

                        <EditItemTemplate>

                            <asp:TextBox ID="txtSite" runat="server" Style="width:40px" Text='<%#

                                         Eval("SiteID")%>'></asp:TextBox>

                        </EditItemTemplate>

                        <FooterTemplate>

                            <asp:TextBox ID="txtSite1" runat="server"></asp:TextBox>

                        </FooterTemplate>

<ItemStyle Width="40px"></ItemStyle>

                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-Width="40px" ItemStyle-Wrap="true" HeaderText="Cluster">

                        <ItemTemplate>

                            <asp:Label ID="lblCluster" runat="server" Text='<%#

                                         Eval("Cluster")%>'></asp:Label>

                        </ItemTemplate>

                        <EditItemTemplate>

                            <asp:TextBox ID="txtCluster" runat="server" Text='<%#

                                         Eval("Cluster")%>'></asp:TextBox>

                        </EditItemTemplate>

                        <FooterTemplate>

                            <asp:TextBox ID="txtCluster1" runat="server"></asp:TextBox>

                        </FooterTemplate>

<ItemStyle Width="40px"></ItemStyle>

                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-Width="40px" ItemStyle-Wrap="true" HeaderText="Date Fueling">

                        <ItemTemplate>

                            <asp:Label ID="DateFueling" runat="server" Text='<%#

                                         Eval("DateFueling")%>'></asp:Label>

                        </ItemTemplate>

                        <EditItemTemplate>

                            <asp:TextBox ID="txtDateFueling" runat="server" Text='<%#

                                         Eval("DateFueling")%>'></asp:TextBox>

                        </EditItemTemplate>

                        <FooterTemplate>

                            <asp:TextBox ID="txtDateFueling1" runat="server"></asp:TextBox>

                        </FooterTemplate>

<ItemStyle Width="40px"></ItemStyle>

                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-Width="40px" HeaderText="Level Before">

                        <ItemTemplate>

                            <asp:Label ID="levelBefore" runat="server" Text='<%#

                                         Eval("levelBefore")%>'></asp:Label>

                        </ItemTemplate>

                        <EditItemTemplate>

                            <asp:TextBox ID="txtlevelBefore" runat="server" Text='<%#

                                         Eval("levelBefore")%>'></asp:TextBox>

                        </EditItemTemplate>

                        <FooterTemplate>

                            <asp:TextBox ID="txtlevelBefore1" runat="server"></asp:TextBox>

                        </FooterTemplate>

<ItemStyle Width="40px"></ItemStyle>

                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-Width="40px" ItemStyle-Wrap="true" HeaderText="Level After">

                        <ItemTemplate>

                            <asp:Label ID="levelAfter" runat="server" Text='<%#

                                         Eval("levelAfter")%>'></asp:Label>

                        </ItemTemplate>

                        <EditItemTemplate>

                            <asp:TextBox ID="txtlevelAfter" runat="server" Text='<%#

                                         Eval("levelAfter")%>'></asp:TextBox>

                        </EditItemTemplate>

                        <FooterTemplate>

                            <asp:TextBox ID="txtlevelAfter1" runat="server"></asp:TextBox>

                        </FooterTemplate>

<ItemStyle Width="40px" Wrap="true"></ItemStyle>

                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-Width="40px" ItemStyle-Wrap="true" HeaderText="Qty to be">

                        <ItemTemplate>

                            <asp:Label ID="Qty" runat="server" Text='<%#

                                         Eval("Qty")%>'></asp:Label>

                        </ItemTemplate>

                        <EditItemTemplate>

                            <asp:TextBox ID="txtQty" runat="server" Text='<%#

                                         Eval("Qty")%>'></asp:TextBox>

                        </EditItemTemplate>

                        <FooterTemplate>

                            <asp:TextBox ID="txtQty1" runat="server"></asp:TextBox>

                        </FooterTemplate>

<ItemStyle Width="40px" Wrap="true"></ItemStyle>

                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-Width="40px" ItemStyle-Wrap="true" HeaderText="Username">

                        <ItemTemplate>

                            <asp:Label ID="username" runat="server" Text='<%#

                                         Eval("username")%>'></asp:Label>

                        </ItemTemplate>

                        <EditItemTemplate>

                            <asp:TextBox ID="txtusername" runat="server" Text='<%#

                                         Eval("username")%>'></asp:TextBox>

                        </EditItemTemplate>

                        <FooterTemplate>

                            <asp:TextBox ID="txtusername1" runat="server"></asp:TextBox>

                        </FooterTemplate>

<ItemStyle Width="40px" Wrap="true"></ItemStyle>

                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-Width="40px" ItemStyle-Wrap="true"  HeaderText="Fin R Week">

                        <ItemTemplate>

                            <asp:Label ID="FinRWeek" runat="server" Text='<%#

                                         Eval("FinRWeek")%>'></asp:Label>

                        </ItemTemplate>

                        <EditItemTemplate>

                            <asp:TextBox ID="txtFinRWeek" runat="server" Text='<%#

                                         Eval("FinRWeek")%>'></asp:TextBox>

                        </EditItemTemplate>

                        <FooterTemplate>

                            <asp:TextBox ID="txtFinRWeek1" runat="server"></asp:TextBox>

                        </FooterTemplate>

<ItemStyle Width="40px" Wrap="true"></ItemStyle>

                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-Width="40px" ItemStyle-Wrap="true" HeaderText="Receipt Number">

                        <ItemTemplate>

                            <asp:Label ID="ReceiptNumber" runat="server" Text='<%#

                                         Eval("ReceiptNumber")%>'></asp:Label>

                        </ItemTemplate>

                        <EditItemTemplate>

                            <asp:TextBox ID="txtReceiptNumber" runat="server" Text='<%#

                                         Eval("ReceiptNumber")%>'></asp:TextBox>

                        </EditItemTemplate>

                        <FooterTemplate>

                            <asp:TextBox ID="txtReceiptNumber1" runat="server"></asp:TextBox>

                        </FooterTemplate>

<ItemStyle Width="40px" Wrap="true"></ItemStyle>

                    </asp:TemplateField>




                    <asp:TemplateField>

                        <ItemTemplate>

                            <asp:LinkButton ID="lnkRemove" runat="server" CommandArgument='<%#

                                         Eval("FuelID")%>'
                                OnClientClick="return confirm('Do you want to delete?')"
                                Text="Delete"></asp:LinkButton>

                        </ItemTemplate>

                        <FooterTemplate>

                            <asp:LinkButton ID="lnkAdd" runat="server"
                                onclick="Btn_Add"
                                Text="Add"></asp:LinkButton>

                        </FooterTemplate>

                    </asp:TemplateField>

                    <asp:CommandField ShowEditButton="True" />

                </Columns>

                <FooterStyle BackColor="White" ForeColor="#000066"></FooterStyle>

                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White"></HeaderStyle>

                <PagerStyle HorizontalAlign="Left" BackColor="White" ForeColor="#000066"></PagerStyle>

                <RowStyle ForeColor="#000066" />

                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White"></SelectedRowStyle>

                <SortedAscendingCellStyle BackColor="#F1F1F1"></SortedAscendingCellStyle>

                <SortedAscendingHeaderStyle BackColor="#007DBB"></SortedAscendingHeaderStyle>

                <SortedDescendingCellStyle BackColor="#CAC9C9"></SortedDescendingCellStyle>

                <SortedDescendingHeaderStyle BackColor="#00547E"></SortedDescendingHeaderStyle>
            </asp:GridView>
                     </asp:Panel>
               
            

        </div>
                              
               
                
            </div>
            <!-- /.row -->
</asp:Content>
