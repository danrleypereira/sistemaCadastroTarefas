<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="pim8.Controllers.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <script type="text/javascript" src="../Scripts/jquery-3.3.1.min.js"></script>
    <script type="text/javascript" src="../Scripts/jquery-ui-1.12.1.min.js"></script>
    <link rel="stylesheet" href="../Content/themes/base/datepicker.css">
    <link rel="stylesheet" href="../Content/themes/base/jquery-ui.min.css">

    <script type="text/javascript">
        $(function () {
            $("#DateTimeStart").datepicker();
            $("#DateTimeEnd").datepicker();
        });
</script>
</head>
<body>
    <form id="form1" runat="server">
            <div>  
                <asp:DataGrid ID="datagrid" runat="server" PageSize="5" AllowPaging="True" DataKeyField="ID" 
                    AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" 
                    OnPageIndexChanged="Grid_PageIndexChanged" OnCancelCommand="Grid_CancelCommand" 
                    OnDeleteCommand="Grid_DeleteCommand" OnEditCommand="Grid_EditCommand" OnUpdateCommand="Grid_UpdateCommand">  
                    <Columns>  

                        <asp:BoundColumn HeaderText="Nome da Tarefa" DataField="TaskName"> </asp:BoundColumn>  
                        <asp:BoundColumn HeaderText="Data Limite" DataField="DateTimeEnd"> </asp:BoundColumn>  
                        <asp:BoundColumn DataField="DateTimeStart" HeaderText="Data Inicio"> </asp:BoundColumn>  
                        <asp:BoundColumn DataField="Noticy" HeaderText="Descricao"> </asp:BoundColumn>  
                        <asp:EditCommandColumn EditText="Edit" CancelText="Cancel" UpdateText="Update" HeaderText="Editar"> </asp:EditCommandColumn>  
                        <asp:ButtonColumn CommandName="Delete" HeaderText="Deletar" Text="Delete"> </asp:ButtonColumn>  
                    </Columns>  
                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />  
                    <SelectedItemStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />  
                    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" Mode="NumericPages" />  
                    <AlternatingItemStyle BackColor="White" />  
                    <ItemStyle BackColor="#FFFBD6" ForeColor="#333333" />  
                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" /> </asp:DataGrid> <br /> 

                <asp:Button ID="btnAddTask" runat="server" Text="Nova Tarefa" OnClick="btnAddTask_Click" />

            </div>
    </form>
    
</body>
</html>
