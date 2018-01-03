<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="NBDProject.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" DataSourceID="ObjectDataSource1" DataTextField="cliName" DataValueField="ID">
            </asp:DropDownList>
            <asp:FormView ID="FormView1" runat="server" DataKeyNames="ID,Expr1" DataSourceID="ObjectDataSource2">
                <EditItemTemplate>
                    ID:
                    <asp:Label ID="IDLabel1" runat="server" Text='<%# Eval("ID") %>' />
                    <br />
                    cliName:
                    <asp:TextBox ID="cliNameTextBox" runat="server" Text='<%# Bind("cliName") %>' />
                    <br />
                    cliAddress:
                    <asp:TextBox ID="cliAddressTextBox" runat="server" Text='<%# Bind("cliAddress") %>' />
                    <br />
                    cliProvince:
                    <asp:TextBox ID="cliProvinceTextBox" runat="server" Text='<%# Bind("cliProvince") %>' />
                    <br />
                    cliCode:
                    <asp:TextBox ID="cliCodeTextBox" runat="server" Text='<%# Bind("cliCode") %>' />
                    <br />
                    cliPhone:
                    <asp:TextBox ID="cliPhoneTextBox" runat="server" Text='<%# Bind("cliPhone") %>' />
                    <br />
                    cliConFname:
                    <asp:TextBox ID="cliConFnameTextBox" runat="server" Text='<%# Bind("cliConFname") %>' />
                    <br />
                    cliConLName:
                    <asp:TextBox ID="cliConLNameTextBox" runat="server" Text='<%# Bind("cliConLName") %>' />
                    <br />
                    cliConPostion:
                    <asp:TextBox ID="cliConPostionTextBox" runat="server" Text='<%# Bind("cliConPostion") %>' />
                    <br />
                    cityID:
                    <asp:TextBox ID="cityIDTextBox" runat="server" Text='<%# Bind("cityID") %>' />
                    <br />
                    Expr1:
                    <asp:Label ID="Expr1Label1" runat="server" Text='<%# Eval("Expr1") %>' />
                    <br />
                    <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
                    &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
                </EditItemTemplate>
                <InsertItemTemplate>
                    cliName:
                    <asp:TextBox ID="cliNameTextBox" runat="server" Text='<%# Bind("cliName") %>' />
                    <br />
                    cliAddress:
                    <asp:TextBox ID="cliAddressTextBox" runat="server" Text='<%# Bind("cliAddress") %>' />
                    <br />
                    cliProvince:
                    <asp:TextBox ID="cliProvinceTextBox" runat="server" Text='<%# Bind("cliProvince") %>' />
                    <br />
                    cliCode:
                    <asp:TextBox ID="cliCodeTextBox" runat="server" Text='<%# Bind("cliCode") %>' />
                    <br />
                    cliPhone:
                    <asp:TextBox ID="cliPhoneTextBox" runat="server" Text='<%# Bind("cliPhone") %>' />
                    <br />
                    cliConFname:
                    <asp:TextBox ID="cliConFnameTextBox" runat="server" Text='<%# Bind("cliConFname") %>' />
                    <br />
                    cliConLName:
                    <asp:TextBox ID="cliConLNameTextBox" runat="server" Text='<%# Bind("cliConLName") %>' />
                    <br />
                    cliConPostion:
                    <asp:TextBox ID="cliConPostionTextBox" runat="server" Text='<%# Bind("cliConPostion") %>' />
                    <br />
                    cityID:
                    <asp:TextBox ID="cityIDTextBox" runat="server" Text='<%# Bind("cityID") %>' />
                    <br />

                    <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
                    &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
                </InsertItemTemplate>
                <ItemTemplate>
                    ID:
                    <asp:Label ID="IDLabel" runat="server" Text='<%# Eval("ID") %>' />
                    <br />
                    cliName:
                    <asp:Label ID="cliNameLabel" runat="server" Text='<%# Bind("cliName") %>' />
                    <br />
                    cliAddress:
                    <asp:Label ID="cliAddressLabel" runat="server" Text='<%# Bind("cliAddress") %>' />
                    <br />
                    cliProvince:
                    <asp:Label ID="cliProvinceLabel" runat="server" Text='<%# Bind("cliProvince") %>' />
                    <br />
                    cliCode:
                    <asp:Label ID="cliCodeLabel" runat="server" Text='<%# Bind("cliCode") %>' />
                    <br />
                    cliPhone:
                    <asp:Label ID="cliPhoneLabel" runat="server" Text='<%# Bind("cliPhone") %>' />
                    <br />
                    cliConFname:
                    <asp:Label ID="cliConFnameLabel" runat="server" Text='<%# Bind("cliConFname") %>' />
                    <br />
                    cliConLName:
                    <asp:Label ID="cliConLNameLabel" runat="server" Text='<%# Bind("cliConLName") %>' />
                    <br />
                    cliConPostion:
                    <asp:Label ID="cliConPostionLabel" runat="server" Text='<%# Bind("cliConPostion") %>' />
                    <br />
                    cityID:
                    <asp:Label ID="cityIDLabel" runat="server" Text='<%# Bind("cityID") %>' />
                    <br />
                    Expr1:
                    <asp:Label ID="Expr1Label" runat="server" Text='<%# Eval("Expr1") %>' />
                    <br />

                </ItemTemplate>
            </asp:FormView>
            <asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="ObjectDataSource3" DataTextField="cityName" DataValueField="ID">
            </asp:DropDownList>
            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="NBDSummaryLibrary.NBDProjectDataSetTableAdapters.SearchClientTableAdapter"></asp:ObjectDataSource>
            <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="NBDSummaryLibrary.NBDProjectDataSetTableAdapters.ClientTableAdapter">
                <SelectParameters>
                    <asp:ControlParameter ControlID="DropDownList1" Name="Param1" PropertyName="SelectedValue" Type="Int32" />
                </SelectParameters>
            </asp:ObjectDataSource>
            <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" DeleteMethod="Delete" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="NBDSummaryLibrary.NBDProjectDataSetTableAdapters.CityTableAdapter" UpdateMethod="Update">
                <DeleteParameters>
                    <asp:Parameter Name="Original_ID" Type="Int32" />
                    <asp:Parameter Name="Original_cityName" Type="String" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="cityName" Type="String" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="cityName" Type="String" />
                    <asp:Parameter Name="Original_ID" Type="Int32" />
                    <asp:Parameter Name="Original_cityName" Type="String" />
                </UpdateParameters>
            </asp:ObjectDataSource>
        </div>
    </form>
</body>
</html>
