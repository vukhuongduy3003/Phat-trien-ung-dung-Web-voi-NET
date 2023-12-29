<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QLSinhvien.aspx.cs" Inherits="QLSinhVien.QLSinhvien" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Quản lý sinh viên</h1>
            <table>
                <tr>
                    <td><strong>Mã sinh viên</strong></td>
                    <td><asp:TextBox ID="txt_maSV" runat="server"></asp:TextBox> </td>
                </tr>
                <tr>
                    <td><strong>Tên sinh viên</strong></td>
                    <td><asp:TextBox ID="txt_tenSV" runat="server"></asp:TextBox> </td>
                </tr>
                <tr>
                    <td><strong>Ngày sinh</strong></td>
                    <td><asp:TextBox ID="txt_ngaysinh" type ="Date" runat="server"></asp:TextBox> </td>
                </tr> 
                <tr>
                    <td><strong>Giới tính</strong></td>
                    <td>
                        <asp:RadioButton ID="rdo_Nam" Text="Nam" runat="server" GroupName="GioiTinh" /> 
                        <asp:RadioButton ID="rdo_Nu" Text="Nữ" runat="server" GroupName="GioiTinh" />
                    </td>
                </tr> 
                <tr>
                    <td><strong>Quê quán</strong></td>
                    <td><asp:TextBox ID="txt_quequan" runat="server"></asp:TextBox> </td>
                </tr>
                <tr>
                    <td><strong>Hình ảnh</strong></td>
                    <td> <asp:FileUpload ID="FileUpload1" runat="server" /></td>
                </tr>
                </table>
            <asp:Button ID="btn_them" runat="server" Text="Thêm" OnClick="btn_them_Click" />
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="btn_xoa" runat="server" Text="Xóa" OnClick="btn_xoa_Click" />
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btn_nhaplai" runat="server" Text="Nhập lại" />
            <br />
            <asp:GridView ID="gvSinhVien" runat="server" AutoGenerateColumns="False" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" DataKeyNames="MaSV" OnRowCancelingEdit="gvSinhVien_RowCancelingEdit" OnRowEditing="gvSinhVien_RowEditing" OnRowUpdating="gvSinhVien_RowUpdating">
                <Columns>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:CheckBox ID="check_all" runat="server" AutoPostBack="True" OnCheckedChanged="check_all_CheckedChanged" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:CheckBox ID="check" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="MaSV" HeaderText="Mã sinh viên" ReadOnly="True" />
                    <asp:BoundField DataField="TenSV" HeaderText="Tên sinh viên" />
                    <asp:BoundField DataField="NgaySinh" HeaderText="Ngày Sinh" />
                    <asp:BoundField DataField="GioiTinh" HeaderText="Giới tính" />
                    <asp:BoundField DataField="QueQuan" HeaderText="Quê quán" />
                    <asp:TemplateField HeaderText="Hình ảnh">
                        <EditItemTemplate>
                            <asp:FileUpload ID="FileUpload2" runat="server" />
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Image ID="Image1" runat="server" ImageUrl='<%# "~/Images/" + Eval("HinhAnh") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ButtonType="Button" CancelText="Hủy" DeleteText="Xóa" EditText="Sửa" HeaderText="Thao tác" ShowEditButton="True" UpdateText="Cập nhật" />
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
