using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Bai1.Models;
namespace Bai1
{
    public partial class QLSach : System.Web.UI.Page
    {
        DataBase db = new DataBase();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadLuoi();
            }
        }
        public void LoadLuoi()
        {
            db.OpenData();
            gvSach.DataSource= db.Get_AllSach();
            gvSach.DataBind();
            db.CloseData();
        }

        protected void gvSach_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvSach.EditIndex = -1;
            LoadLuoi();
        }

        protected void gvSach_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvSach.EditIndex = e.NewEditIndex;
            LoadLuoi();
        }

        protected void btn_Them_Click(object sender, EventArgs e)
        {
            String Masach = txt_masach.Text.Trim();
            
            String Tensach = txt_tensach.Text.Trim();
            String NhaXB = txt_nhaXB.Text.Trim();
            int NamXB = int.Parse( txt_namXB.Text.Trim());
            String Tacgia = txt_tacgia.Text.Trim();
            decimal Dongia = Decimal.Parse( txt_masach.Text.Trim());
           
            if(FileUpload1.HasFile)
            {
                String tenAnh = FileUpload1.FileName;
                String filepath = MapPath("~/Images/" + tenAnh);
                FileUpload1.SaveAs(filepath);
                if (!db.CheckMa(Masach))
                {
                    db.OpenData();
                    Books b = new Books(Masach, Tensach, NhaXB, NamXB, Tacgia, Dongia, tenAnh);
                    db.insert(b);
                    db.CloseData();
                    LoadLuoi();
                }
            }
        }

        protected void gvSach_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            String maSach = gvSach.DataKeys[e.RowIndex].Value.ToString();
            String tenSach = ((TextBox)gvSach.Rows[e.RowIndex].Cells[2].Controls[0]).Text;
            String NhaXB = ((TextBox)gvSach.Rows[e.RowIndex].Cells[3].Controls[0]).Text;
            int namXB =int.Parse( ((TextBox)gvSach.Rows[e.RowIndex].Cells[4].Controls[0]).Text);
            
            String tacgia = ((TextBox)gvSach.Rows[e.RowIndex].Cells[5].Controls[0]).Text;
            decimal Dongia = Decimal.Parse(((TextBox)gvSach.Rows[e.RowIndex].Cells[6].Controls[0]).Text);
            FileUpload ha = (FileUpload)gvSach.Rows[e.RowIndex].FindControl("FileUpload2");
            if (ha.HasFile)
            {
                
                String tenanh = ha.FileName;
                String pathha = MapPath("~/Images/" + tenanh);
                ha.SaveAs(pathha);
                Books b = new Books(maSach, tenSach, NhaXB, namXB, tacgia, Dongia, tenanh);
                db.update(b);
                gvSach.EditIndex = -1;
                LoadLuoi();
            }
        }

        protected void ck_all_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox ck_all = (CheckBox)gvSach.HeaderRow.FindControl("ck_all");
            if(ck_all.Checked)
            {
                foreach(GridViewRow row in gvSach.Rows)
                {
                    CheckBox ck = (CheckBox)row.FindControl("ckb_ma");
                    if (!ck.Checked)
                    {
                        ck.Checked= true;
                    }
                }
            }
            else
            {
                foreach (GridViewRow row in gvSach.Rows)
                {
                    CheckBox ck = (CheckBox)row.FindControl("ckb_ma");
                    if (ck.Checked)
                    {
                        ck.Checked = false;
                    }
                }
            }
        }

        protected void btn_xoa_Click(object sender, EventArgs e)
        {
            foreach(GridViewRow row in gvSach.Rows)
            {
                CheckBox check = (CheckBox)row.FindControl("ckb_ma");
                if (check.Checked)
                {
                    db.delete(row.Cells[1].Text);
                }
            }
            LoadLuoi();
        }
    }
}