using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QLQuanAo.Models;

namespace QLQuanAo
{
    public partial class ShopQuanAo : System.Web.UI.Page
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
            gvQuanAo.DataSource = db.Get_AllQuanAo();
            gvQuanAo.DataBind();
            db.CloseData();
        }

        protected void btn_them_Click(object sender, EventArgs e)
        {
            try
            {
                String maQA = txt_maQA.Text.Trim();
                String tenQA = txt_tenQA.Text.Trim();
                String thuonghieu = txt_thuonghieu.Text.Trim();
                String kichthuoc = cbo_kichthuoc.Text.Trim();
                float dongia = float.Parse(txt_dongia.Text.Trim());
                String mota = txt_mota.Text.Trim();
                String tenanh = "";
                if (maQA.Equals("") || tenQA.Equals("") || thuonghieu.Equals("") || kichthuoc.Equals("") || dongia.Equals("") || mota.Equals(""))
                {
                    Response.Write("<script>alert('Bạn cần phải điền thông tin đầy đủ!!!'); </script>");
                }
                else
                {
                    if (!db.checkMa(maQA))
                    {
                        if (FileUpload1.HasFile)
                        {
                            tenanh = FileUpload1.FileName;
                            String pathha = MapPath("~/Images/" + tenanh);
                            FileUpload1.SaveAs(pathha);
                        }

                        QuanAo qa = new QuanAo(maQA, tenQA, thuonghieu, kichthuoc, dongia, tenanh, mota);
                        db.insert(qa);
                        Response.Write("<script>alert('Bạn đã thêm thành công!!!'); </scripts>");
                        LoadLuoi();
                    }
                    else
                    {
                        Response.Write("<script>alert('Bạn nhập trùng mã'); </scripts>");
                    }
                }
            }
            catch
            {
                Response.Write("<script>alert('Bạn không thêm được'); </scripts>");
            }
        }

        protected void gvQuanAo_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvQuanAo.EditIndex = -1;
            LoadLuoi();
        }

        protected void gvQuanAo_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvQuanAo.EditIndex = e.NewEditIndex;
            LoadLuoi();
        }

        protected void gvQuanAo_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                String maQA = gvQuanAo.DataKeys[e.RowIndex].Value.ToString();
                String tenQA = ((TextBox)gvQuanAo.Rows[e.RowIndex].Cells[2].Controls[0]).Text;
                String thuonghieu = ((TextBox)gvQuanAo.Rows[e.RowIndex].Cells[3].Controls[0]).Text;
                String kichthuoc = ((TextBox)gvQuanAo.Rows[e.RowIndex].Cells[4].Controls[0]).Text;
                float dongia =float.Parse( ((TextBox)gvQuanAo.Rows[e.RowIndex].Cells[5].Controls[0]).Text);
                FileUpload ha = (FileUpload)gvQuanAo.Rows[e.RowIndex].FindControl("FileUpload2");
                String mota = ((TextBox)gvQuanAo.Rows[e.RowIndex].Cells[7].Controls[0]).Text;
                if (ha.HasFile)
                {
                    String tenanh = ha.FileName;
                    String filepath = MapPath("~/Images/" + tenanh);
                    ha.SaveAs(filepath);
                    QuanAo qa = new QuanAo(maQA,tenQA,thuonghieu,kichthuoc,dongia,tenanh,mota);
                    db.update(qa);
                    gvQuanAo.EditIndex = -1;
                    LoadLuoi();
                }

            }catch
            {

            }
        }

        protected void ck_all_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox ck = (CheckBox)gvQuanAo.HeaderRow.FindControl("ck_all");
            if(ck.Checked)
            {
                foreach(GridViewRow row in gvQuanAo.Rows)
                {
                    CheckBox check = (CheckBox)row.FindControl("checkbox");
                    if(!check.Checked)
                    {
                        check.Checked = true;
                    }
                }
            }
            else
            {
                foreach(GridViewRow row in gvQuanAo.Rows)
                {
                    CheckBox check = (CheckBox)row.FindControl("checkbox");
                    if (check.Checked)
                    {
                        check.Checked = false;
                    }
                }
            }
        }

        protected void btn_xoa_Click(object sender, EventArgs e)
        {
            foreach(GridViewRow row in gvQuanAo.Rows)
            {
                CheckBox ck = (CheckBox)row.FindControl("checkbox");
                if (ck.Checked)
                {
                    db.Delete(row.Cells[1].Text);
                }
            }
            LoadLuoi();
        }

        protected void btn_nhaplai_Click(object sender, EventArgs e)
        {
            txt_maQA.Text = "";
            txt_tenQA.Text = "";
            txt_thuonghieu.Text = "";
            cbo_kichthuoc.Text = "";
            txt_dongia.Text = "";
            txt_mota.Text = "";
        }
    }
}