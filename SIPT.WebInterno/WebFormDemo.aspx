<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="WebFormDemo.aspx.cs" Inherits="SIPT.WebInterno.WebFormDemo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-lg-12">
                                        <h4 class="box-title">Secondary color</h4>
                                        <p class="text-muted font-13"> You can apply <code> data-color="@color" data-secondary-color="@color"</code> to your input element to both color. </p>
                                        <div class="m-b-30">
        <asp:CheckBox ID="CheckBox1" runat="server" />
                                            <label>First name: <input type="checkbox" /></label>                                            
                                            
                                        </div>
                                    </div>
</asp:Content>
