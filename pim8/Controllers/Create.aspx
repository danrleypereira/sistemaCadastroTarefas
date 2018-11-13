<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="pim8.Controllers.Create" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" src="../Scripts/jquery-3.3.1.min.js"></script>
    <script type="text/javascript" src="../Scripts/jquery-ui-1.12.1.min.js"></script>
    <link rel="stylesheet" href="../Content/themes/base/datepicker.css"/>
    <link rel="stylesheet" href="../Content/themes/base/jquery-ui.min.css"/>
         <link rel="stylesheet" href="../Content/themes/base/button.css"/>
    <link rel="stylesheet" href="../Content/themes/bootstrap-theme.css"/>

    <script type="text/javascript">
        $(function () {
            $("#datepicker1").datepicker();
            $("#datepicker2").datepicker();
        });
</script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        <table>  
            <tr>  
                <td>  
                    <asp:Label ID="lblTaskName" runat="server" Text="Nome da Tarefa"></asp:Label>  
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>  
                </td>  
                <td>  
                    <asp:Label ID="lblDateEnd" runat="server" Text="Data Fim"></asp:Label>  
                    <asp:TextBox ID="datepicker1" runat="server"></asp:TextBox>
                </td>  
                <td>  
                    <asp:Label ID="lblDateStart" runat="server" Text="Data Inicio"></asp:Label>  
                    <asp:TextBox ID="datepicker2" runat="server"></asp:TextBox>
                </td>  
                <td>  
                    <asp:Label ID="lblDescription" runat="server" Text="Descricao"></asp:Label>  
                    <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                </td>    
            </tr>  
        </table>  

                <asp:Button class="ui-button btn-warning" ID="btnReset" runat="server" Text="Resetar" OnClick="btnReset_Click" />  
                <asp:Button class="ui-button btn-success" ID="btnSubmit" runat="server" Text="OK" OnClick="btnSubmit_Click" />
                <asp:Button class="ui-button" ID="btnCancel" runat="server" Text="Cancelar" OnClick="btnCancel_Click" />
        </div>




    </form>
</body>
</html>
