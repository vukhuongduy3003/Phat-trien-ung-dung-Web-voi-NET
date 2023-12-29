using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Protocols;
using System.Web.UI;
using System.Web.UI.WebControls;
using QLSinhVien.Models;
namespace QLSinhVien
{
    public partial class QLSinhvien : System.Web.UI.Page
    {
        DataBase db = new DataBase();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                LoadLuoi();
            }
        }
        public void LoadLuoi()
        {
            db.OpenData();
            gvSinhVien.DataSource = db.get_AllSinhVien();
            gvSinhVien.DataBind();
            db.CloseData();
        }

        protected void btn_them_Click(object sender, EventArgs e)
        {
            try
            {
                /*Response.Write("<script>alert('Bạn đã thêm được'); </script>");*/
                String maSV = txt_maSV.Text;
                String hoten = txt_tenSV.Text;
                String ngaysinh = txt_ngaysinh.Text;
                String gioitinh = "";
                if (rdo_Nam.Checked)
                {
                    gioitinh = "Nam";
                }
                else
                {
                    gioitinh = "Nữ";
                }
                String quequan = txt_quequan.Text;
                String tenanh = "";
                if (FileUpload1.HasFile)
                {
                    tenanh = FileUpload1.FileName;
                    String filepath = MapPath("~/Images/" + tenanh);
                    FileUpload1.SaveAs(filepath);

                }
                if (!db.Check_Ma(maSV))
                {
                    Sinhvien sv = new Sinhvien(maSV, hoten, ngaysinh, gioitinh, quequan, tenanh);
                    db.insert(sv);
                    LoadLuoi();
                }
            }
            catch
            {
                Response.Write("<script>alert('Bạn chưa thêm được'); </script>");
            }
        }

        protected void gvSinhVien_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvSinhVien.EditIndex = -1;
            LoadLuoi();
        }

        protected void gvSinhVien_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvSinhVien.EditIndex = e.NewEditIndex;
            LoadLuoi();
        }

        protected void gvSinhVien_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            String maSV = gvSinhVien.DataKeys[e.RowIndex].Value.ToString();
            String hoten = ((TextBox)gvSinhVien.Rows[e.RowIndex].Cells[2].Controls[0]).Text;
           
            String ngaysinh = ((TextBox)gvSinhVien.Rows[e.RowIndex].Cells[3].Controls[0]).Text;
            String gioitinh = ((TextBox)gvSinhVien.Rows[e.RowIndex].Cells[4].Controls[0]).Text;
            String quequan = ((TextBox)gvSinhVien.Rows[e.RowIndex].Cells[5].Controls[0]).Text;
            FileUpload ha = (FileUpload)gvSinhVien.Rows[e.RowIndex].FindControl("FileUpload2");
            String tenanh = "";
            if (ha.HasFile)
            {
                tenanh = ha.FileName;
                String filepath = MapPath("~/Images/" + tenanh);
                ha.SaveAs(filepath);
            }
            Sinhvien sv = new Sinhvien(maSV, hoten, ngaysinh, gioitinh, quequan, tenanh);
            db.update(sv);
            gvSinhVien.EditIndex = -1;
            LoadLuoi();

        }

        protected void check_all_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox ck_all = (CheckBox)gvSinhVien.HeaderRow.FindControl("check_all");
            if(ck_all.Checked )
            {
                foreach(GridViewRow row in gvSinhVien.Rows)
                {
                    CheckBox ck = (CheckBox)row.FindControl("check");
                    if(!ck.Checked )
                    {
                        ck.Checked = true;
                    }
                }
            }else
            {
                foreach (GridViewRow row in gvSinhVien.Rows)
                {
                    CheckBox ck = (CheckBox)row.FindControl("check");
                    if (ck.Checked)
                    {
                        ck.Checked = false;
                    }
                }
            }
        }

        protected void btn_xoa_Click(object sender, EventArgs e)
        {
            foreach(GridViewRow row in gvSinhVien.Rows)
            {
                CheckBox ck = (CheckBox)row.FindControl("check");
                if(ck.Checked)
                {
                    db.delete(row.Cells[1].Text);
                }
            }
            LoadLuoi();
        }
    }
}