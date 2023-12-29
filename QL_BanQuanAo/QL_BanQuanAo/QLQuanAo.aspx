﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QLQuanAo.aspx.cs" Inherits="QL_BanQuanAo.QLQuanAo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Quản lý quần áo</h1>
            <table>
                <tr>
                    <td><strong>Mã quần áo</strong></td>
                    <td> <asp:TextBox ID="txt_maqa" runat="server" Width="261px"></asp:TextBox> </td>
                </tr>
                <tr>
                    <td><strong>Tên quần áo</strong></td>
                    <td> <asp:TextBox ID="txt_tenqa" runat="server" Width="261px"></asp:TextBox> </td>
                </tr>
                <tr>
                    <td><strong>Thương hiệu</strong></td>
                    <td> <asp:TextBox ID="txt_thuonghieu" runat="server" Width="271px"></asp:TextBox> </td>
                </tr>
                <tr>
                    <td><strong>Kích thước</strong></td>
                    <td> <asp:ListBox ID="txt_kichthuoc" runat="server">
                        <asp:ListItem>XXXL</asp:ListItem>
                        <asp:ListItem>XXL</asp:ListItem>
                        <asp:ListItem>XL</asp:ListItem>
                        <asp:ListItem>L</asp:ListItem>
                        <asp:ListItem>M</asp:ListItem>
                        <asp:ListItem>S</asp:ListItem>
                        </asp:ListBox> </td>
                </tr>
                 <tr>
                    <td><strong>Đơn giá</strong></td>
                    <td> <asp:TextBox ID="txt_dongia" runat="server" Width="261px"></asp:TextBox> </td>
                </tr>
                <tr>
                    <td><strong>Hình ảnh</strong></td>
                    <td>
                        <asp:FileUpload ID="FileUpload1" runat="server" /> </td>
                </tr>
                 <tr>
                    <td><strong>Mô tả</strong></td>
                    <td> <asp:TextBox ID="txt_mota" runat="server" TextMode="MultiLine" Width="271px"></asp:TextBox> </td>

                </tr>
                </table>
            <asp:Button ID="btn_them" runat="server" Text="Thêm" OnClick="btn_them_Click" />
            &nbsp;&nbsp;
            <asp:Button ID="btn_xoa" runat="server" Text="Xóa" />
            &nbsp;&nbsp;
            <asp:Button ID="btn_nhaplai" runat="server" Text="Nhập lại" />
            <asp:GridView ID="gvQuanAo" runat="server" AutoGenerateColumns="False" DataKeyNames="MaQA" OnRowCancelingEdit="gvQuanAo_RowCancelingEdit" OnRowEditing="gvQuanAo_RowEditing" OnRowUpdating="gvQuanAo_RowUpdating">
                <Columns>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:CheckBox ID="ck_all" runat="server" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:CheckBox ID="checkbox" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="MaQA" HeaderText="Mã quần áo" />
                    <asp:BoundField DataField="TenQA" HeaderText="Tên quần áo" />
                    <asp:BoundField DataField="ThuongHieu" HeaderText="Thương hiệu" />
                    <asp:BoundField DataField="KichThuoc" HeaderText="Kích thước" />
                    <asp:BoundField DataField="DonGia" HeaderText="Đơn giá" />
                    <asp:TemplateField HeaderText="Hình ảnh">
                        <EditItemTemplate>
                            <asp:FileUpload ID="FileUpload2" runat="server" />
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Image ID="Image1" runat="server" ImageUrl='<%# "~/Images/" + Eval("HinhAnh") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="MoTa" HeaderText="Mô tả" />
                    <asp:CommandField ButtonType="Button" CancelText="Hủy" DeleteText="Xóa" EditText="Sửa" HeaderText="Thao tác" ShowEditButton="True" UpdateText="Cập nhật" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
