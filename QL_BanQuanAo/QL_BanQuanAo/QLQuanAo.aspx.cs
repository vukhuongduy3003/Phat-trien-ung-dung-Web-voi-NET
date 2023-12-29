using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QL_BanQuanAo.Models;

namespace QL_BanQuanAo
{
    public partial class QLQuanAo : System.Web.UI.Page
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
            gvQuanAo.DataSource = db.get_AllQA();
            gvQuanAo.DataBind();
            db.CloseData();
        }

        protected void btn_them_Click(object sender, EventArgs e)
        {
            String maQA = txt_maqa.Text.Trim();
            String tenQA = txt_tenqa.Text.Trim();
            String thuonghieu = txt_thuonghieu.Text.Trim();
            String kichthuoc = txt_kichthuoc.Text.Trim();
            float dongia = float.Parse(txt_dongia.Text.Trim());
            String tenanh = "";
            if (FileUpload1.HasFile)
            {
             tenanh = FileUpload1.FileName;
                String filepath = MapPath("~/Images/" + tenanh);
                FileUpload1.SaveAs(filepath);
            }
            String mota = txt_mota.Text.Trim();
            QuanAo qa = new QuanAo(maQA, tenQA, thuonghieu, kichthuoc, dongia, tenanh, mota);
            db.insert(qa);
            LoadLuoi();
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
            String maQA = gvQuanAo.DataKeys[e.RowIndex].Value.ToString();
            String tenQA = ((TextBox)gvQuanAo.Rows[e.RowIndex].Cells[2].Controls[0]).Text.Trim();
            String thuonghieu = ((TextBox)gvQuanAo.Rows[e.RowIndex].Cells[3].Controls[0]).Text.Trim();
            String kichthuoc = ((TextBox)gvQuanAo.Rows[e.RowIndex].Cells[4].Controls[0]).Text.Trim();
            float dongia =float.Parse( ((TextBox)gvQuanAo.Rows[e.RowIndex].Cells[5].Controls[0]).Text.Trim());
            FileUpload ha = (FileUpload)gvQuanAo.Rows[e.RowIndex].FindControl("FileUpload2");
            String mota = ((TextBox)gvQuanAo.Rows[e.RowIndex].Cells[7].Controls[0]).Text.Trim();
            String tenanh = "";
            if (ha.HasFile)
            {
                tenanh = ha.FileName;
                String filepath = MapPath("~/Images/" + tenanh);
                ha.SaveAs(filepath);
            }
            QuanAo qa = new QuanAo(maQA,tenQA,thuonghieu,kichthuoc,dongia,tenanh,mota);
            db.update(qa);
            gvQuanAo.EditIndex = -1;
            LoadLuoi();
        }
    }
}