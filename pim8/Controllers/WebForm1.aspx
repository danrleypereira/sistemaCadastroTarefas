<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="pim8.Controllers.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <script type="text/javascript" src="../Scripts/jquery-3.3.1.min.js"></script>
    <script type="text/javascript" src="../Scripts/jquery-ui-1.12.1.min.js"></script>
    <link rel="stylesheet" href="../Content/themes/base/datepicker.css"/>
    <link rel="stylesheet" href="../Content/themes/base/jquery-ui.min.css"/>
    <link rel="stylesheet" href="../Content/themes/base/button.css"/>
    <link rel="text/javascript" href="../Scripts/jquery-3.3.1.js"/>

    <script type="text/javascript">
        $(function () {
            $("#DateTimeStart").datepicker();
            $("#DateTimeEnd").datepicker();
        });
</script>
</head>
<body>
        <div class="ui-menu navbar navbar-inverse navbar-fixed-top">
        <div class="container">
            <div class="navbar-header">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                <a href="~/Views/Home/Index.cshtml"></a>
            </div>
            <div class="navbar-collapse collapse">
                <ul class="nav navbar-nav">
                    <li class="ui-menu-item "><a href="../">Inicio</a></li>
                    <li class="ui-menu-item " ><a class="ui-tabs-anchor" href="../Content/PIM-VIII.pdf" target="_blank">
                        Sobre PIM8</a></li>
                    <li class="ui-menu-item "> <a href="">Tarefas</a></li>
                </ul>
            </div>
        </div>
    </div>
    <form id="form1" runat="server">
            <div>  
                <asp:DataGrid ID="datagrid" runat="server" PageSize="10" AllowPaging="True" DataKeyField="ID" 
                    AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" 
                    OnPageIndexChanged="Grid_PageIndexChanged" OnCancelCommand="Grid_CancelCommand" 
                    OnDeleteCommand="Grid_DeleteCommand" OnEditCommand="Grid_EditCommand" OnUpdateCommand="Grid_UpdateCommand" Height="244px" Width="932px">  
                    <Columns>  

                        <asp:BoundColumn HeaderText="Nome da Tarefa" DataField="TaskName"> </asp:BoundColumn>  
                        <asp:BoundColumn HeaderText="Data Limite" DataField="DateTimeEnd"> </asp:BoundColumn>  
                        <asp:BoundColumn DataField="DateTimeStart" HeaderText="Data Inicio"> </asp:BoundColumn>  
                        <asp:BoundColumn DataField="Noticy" HeaderText="Descrição"> </asp:BoundColumn>  
                        <asp:EditCommandColumn EditText="Editar" CancelText="Cancelar" UpdateText="Atualizar" HeaderText="Editar" > </asp:EditCommandColumn>  
                        <asp:ButtonColumn CommandName="Delete" HeaderText="Deletar" Text="Deletar"> </asp:ButtonColumn>  
                    </Columns>  
                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />  
                    <SelectedItemStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />  
                    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" Mode="NumericPages" />  
                    <AlternatingItemStyle BackColor="White" />  
                    <ItemStyle BackColor="#FFFBD6" ForeColor="#333333" />  
                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" /> </asp:DataGrid> <br /> 

                <asp:Button class="ui-button btn-primary" ID="btnAddTask" runat="server" Text="Nova Tarefa" OnClick="btnAddTask_Click" />
                <asp:Button class="ui-button" ID="btnPdf" runat="server" Text="PIM8 pdf" OnClick="Btnpdf_Click" />

            </div>
    </form>
    
</body>
</html>
