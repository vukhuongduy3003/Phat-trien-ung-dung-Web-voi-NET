<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QLSach.aspx.cs" Inherits="Bai1.QLSach" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 467px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Quản lý sách</h1>
            <table>
                <tr>
                    <td><strong>Mã sách:</strong></td>
                    <td class="auto-style1"> <asp:TextBox ID="txt_masach" runat="server" Width="277px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><strong>Tên sách:</strong></td>
                    <td class="auto-style1"> <asp:TextBox ID="txt_tensach" runat="server" Width="274px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><strong>Nhà xuất bản:</strong></td>
                    <td class="auto-style1"> <asp:TextBox ID="txt_nhaXB" runat="server" Width="275px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><strong>Năm xuất bản:</strong></td>
                    <td class="auto-style1"> <asp:TextBox ID="txt_namXB" runat="server" Width="275px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><strong>Tác giả: </strong></td>
                    <td class="auto-style1"> <asp:TextBox ID="txt_tacgia" runat="server" Width="272px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><strong>Đơn giá</strong></td>
                    <td class="auto-style1"> <asp:TextBox ID="txt_dongia" runat="server" Width="270px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><strong>Hình ảnh</strong></td>
                    <td class="auto-style1"><asp:FileUpload ID="FileUpload1" runat="server" /></td>
                </tr>
            </table>
            <asp:Button ID="btn_Them" runat="server" Text="Thêm" OnClick="btn_Them_Click" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btn_xoa" runat="server" Text="Xóa" OnClick="btn_xoa_Click" />

        &nbsp;&nbsp;
            <asp:Button ID="btn_nhaplai" runat="server" Text="Nhập lại" />
            <asp:GridView ID="gvSach" runat="server" AutoGenerateColumns="False" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" DataKeyNames="Masach" OnRowCancelingEdit="gvSach_RowCancelingEdit" OnRowEditing="gvSach_RowEditing" OnRowUpdating="gvSach_RowUpdating">
                <Columns>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:CheckBox ID="ck_all" runat="server" AutoPostBack="True" OnCheckedChanged="ck_all_CheckedChanged" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:CheckBox ID="ckb_ma" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Masach" HeaderText="Mã sách" ReadOnly="True" />
                    <asp:BoundField DataField="Tensach" HeaderText="Tên sách" />
                    <asp:BoundField DataField="NhaXB" HeaderText="Nhà xuất bản" />
                    <asp:BoundField DataField="NamXB" HeaderText="Năm xuất bản" />
                    <asp:BoundField DataField="Tacgia" HeaderText="Tác giả" />
                    <asp:BoundField DataField="Dongia" DataFormatString="{0:0 đồng}" HeaderText="Đơn giá" />
                    <asp:TemplateField HeaderText="Hình ảnh">
                        <EditItemTemplate>
                            <asp:FileUpload ID="FileUpload2" runat="server" />
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Image ID="Image1" runat="server" ImageUrl='<%# "~/Images/" + Eval("Hinhanh") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ButtonType="Button" CancelText="Thoát" DeleteText="Xóa" EditText="Sửa" HeaderText="Thao tác" InsertText="Thêm" ShowEditButton="True" UpdateText="Cập nhật" />
                </Columns>
                <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#FFF1D4" />
                <SortedAscendingHeaderStyle BackColor="#B95C30" />
                <SortedDescendingCellStyle BackColor="#F1E5CE" />
                <SortedDescendingHeaderStyle BackColor="#93451F" />
            </asp:GridView>
        </div>

    </form>
</body>
</html>
