<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="carrito.aspx.cs" Inherits="Tienda.carrito" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>carrito</title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">

</head>
<body>
    <form id="form1" runat="server">
         <div class="container" style="width:780px;margin-top:50px;">
             <a href="ventas.aspx">volver</a>
            <asp:GridView ID="viewProducts" CssClass="table table-hover shopping-cart-wrap" gridlines="None" runat="server" OnRowUpdating="sacar" Height="241px" Width="841px" AutoGenerateColumns="false">
                    <Columns>
                        <asp:TemplateField HeaderText ="Producto">
                            <ItemTemplate>
                                <asp:Label ID="idProduct" runat="server" Visible="False" Text='<%# Eval("id") %>'></asp:Label>
                                <asp:Label Text='<%# Eval("nombre") %>' runat="server">
                                </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Cantidad">
                            <ItemTemplate>
                                <asp:Label Text='<%# Eval("cantidad") %>' runat="server">
                                </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Precio Unidad">
                            <ItemTemplate>
                                <asp:Label Text='<%# Eval("precioActual") %>' runat="server">
                                </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Descuento">
                            <ItemTemplate>
                                <asp:Label Text='<%# Eval("descuento") %>' runat="server">
                                </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Total">
                            <ItemTemplate>
                                <asp:Label Text='<%# Eval("total") %>' runat="server">
                                </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-Width="250px">
                            <ItemTemplate>
                                <asp:LinkButton ID="ButtonGuardar" Text="Desacartar" runat="server" CommandName="Update" ToolTip="Update"/>
                                <%--<asp:LinkButton ID="ButtonEditar" runat="server" Text="Edit" CssClass="btn btn-success" CommandName="Edit" ToolTip="Edit" />--%>
                            </ItemTemplate>
                </asp:TemplateField>
                    </Columns>
                </asp:GridView>
             <asp:Button Text="realizar compra" OnClick="compra_Click" runat="server" />
               
        </div>
    </form>
        <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
<script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>

</body>
</html>
