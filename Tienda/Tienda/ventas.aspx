<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ventas.aspx.cs" Inherits="Tienda.ventas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Ventas</title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">
</head>
<body>
    <form id="form1" runat="server">
       
        <div class="container" style="width:780px;margin-top:50px;">
            <a href="carrito.aspx">ir a carrito</a>
            <asp:GridView ID="viewProducts" CssClass="table table-hover shopping-cart-wrap" gridlines="None" runat="server" OnRowUpdating="Guardar" Height="241px" Width="841px" AutoGenerateColumns="false" OnRowEditing="viewProducts_RowEditing" >
                    <Columns>
                        <asp:TemplateField HeaderText="Producto">
                            <ItemTemplate >
                                <asp:Label ID="idProduct" runat="server" Visible="False" Text='<%# Eval("id") %>'></asp:Label>
                                <asp:Label Text='<%# Eval("nombre") %>' runat="server">
                                </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Categoria">
                            <ItemTemplate>
                                <asp:Label Text='<%# Eval("categoria") %>' runat="server">
                                </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="precio COP">
                            <ItemTemplate>
                                <asp:Label Text='<%# Eval("precioActual") %>' runat="server">
                                </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Descuento %">
                            <ItemTemplate>
                                <asp:Label Text='<%# Eval("descuento") %>' runat="server">
                                </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="U.disponibles">
                            <ItemTemplate>
                                <asp:Label ID="stock" Text='<%# Eval("stock") %>' runat="server">
                                </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="commentario">
                            <ItemTemplate>
                                <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                                <asp:Button ID="Button2" runat="server" Text="agregar" CommandName="Edit" ToolTip="Edit"/>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="cantidad" ItemStyle-Width="250px">
                            <ItemTemplate>
                                <asp:TextBox ID="TextBox2" value="1"  runat="server"></asp:TextBox>

                                <asp:ImageButton ID="ButtonGuardar" runat="server" CommandName="Update" ToolTip="Update" ImageUrl="img/icons8-comprar-26.png"/>
                                <%--<asp:LinkButton ID="ButtonEditar" runat="server" Text="Edit" CssClass="btn btn-success" CommandName="Edit" ToolTip="Edit" />--%>
                            </ItemTemplate>
                </asp:TemplateField>
                    </Columns>
                </asp:GridView>
        </div>
    </form>

    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
<script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>
    
</body>
</html>
